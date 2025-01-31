using UnityEngine;

public class ShakeEffect : MonoBehaviour
{
    public float shakeSpeed = 50f; // Скорость тряски
    public float shakeAmount = 0.1f; // Интенсивность тряски
    private bool shaking = true;
    private Quaternion initialLocalRotation;

    void Start()
    {
        initialLocalRotation = transform.localRotation;
    }

    void Update()
    {
        if (shaking)
        {
            float shakeOffsetX = Mathf.Sin(Time.time * shakeSpeed) * shakeAmount;
            float shakeOffsetY = Mathf.Sin(Time.time * shakeSpeed) * shakeAmount;
            float shakeOffsetZ = Mathf.Sin(Time.time * shakeSpeed) * shakeAmount;

            transform.localRotation = initialLocalRotation * Quaternion.Euler(shakeOffsetX, shakeOffsetY, shakeOffsetZ);
        }
    }

    public void StartShaking()
    {
        shaking = true;
    }

    public void StopShaking()
    {
        shaking = false;
        transform.localRotation = initialLocalRotation;
    }
}