using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform target; // Ссылка на объект, вокруг которого будет вращаться камера
    public float rotationSpeed = 1.0f; // Скорость вращения камеры
    public float minRotationX = 0f; // Минимальный угол вращения по оси X
    public float maxRotationX = 90f; // Максимальный угол вращения по оси X

    private Vector3 lastTouchPosition;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 newTouchPosition = touch.position;

                if (lastTouchPosition != Vector3.zero)
                {
                    Vector2 deltaPosition = newTouchPosition - lastTouchPosition;
                    float rotationZ = deltaPosition.x * rotationSpeed * Time.deltaTime;
                    float rotationX = -deltaPosition.y * rotationSpeed * Time.deltaTime;

                    // Ограничиваем угол вращения по оси X
                    float currentRotationX = transform.rotation.eulerAngles.x;
                    if (currentRotationX + rotationX > maxRotationX)
                    {
                        rotationX = maxRotationX - currentRotationX;
                    }
                    else if (currentRotationX + rotationX < minRotationX)
                    {
                        rotationX = minRotationX - currentRotationX;
                    }

                    transform.RotateAround(target.position, Vector3.up, rotationZ);
                    transform.RotateAround(target.position, transform.right, rotationX);
                }

                lastTouchPosition = newTouchPosition;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                lastTouchPosition = Vector3.zero;
            }
        }
    }
}