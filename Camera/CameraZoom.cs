using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Transform target; // Ссылка на трансформ автомобиля
    public float zoomSpeed = 0.1f; // Скорость приближения/отдаления
    public float minZoomDistance = 2.0f; // Минимальное расстояние приближения
    public float maxZoomDistance = 10.0f; // Максимальное расстояние приближения

    private Camera cam;
    private Vector2 touchStart;
    private float initialDistance;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            if (touchZero.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began)
            {
                touchStart = (touchZero.position + touchOne.position) / 2;
                initialDistance = Vector2.Distance(touchZero.position, touchOne.position);
            }
            else if (touchZero.phase == TouchPhase.Moved || touchOne.phase == TouchPhase.Moved)
            {
                Vector2 touchCurrent = (touchZero.position + touchOne.position) / 2;
                float currentDistance = Vector2.Distance(touchZero.position, touchOne.position);

                float deltaDistance = initialDistance - currentDistance;
                float zoomAmount = deltaDistance * zoomSpeed;

                // Определяем направление от камеры до автомобиля
                Vector3 direction = target.position - cam.transform.position;

                // Рассчитываем новое расстояние до цели
                float distance = direction.magnitude;
                distance += zoomAmount;
                distance = Mathf.Clamp(distance, minZoomDistance, maxZoomDistance);

                // Обновляем позицию камеры
                cam.transform.position = target.position - direction.normalized * distance;
            }
        }
    }
}