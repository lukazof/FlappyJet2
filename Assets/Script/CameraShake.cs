using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;
    public Transform cameraTransform;
    public float shakeDuration = 0.2f;
    public float shakeMagnitude = 0.4f;

    private Vector3 originalPosition;
    private float currentShakeDuration = 0f;
    private float currentShakeMagnitude = 0f;

    private void Awake()
    {
        Instance = this;
        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;

        originalPosition = cameraTransform.localPosition; // Salva a posição original da câmera no Awake
    }

    private void Update()
    {
        if (currentShakeDuration > 0)
        {
            cameraTransform.localPosition = originalPosition + Random.insideUnitSphere * currentShakeMagnitude;

            currentShakeDuration -= Time.deltaTime;
        }
        else
        {
            currentShakeDuration = 0f;
            cameraTransform.localPosition = originalPosition;
        }
    }

    public void ShakeCamera(float magnitude, float duration)
    {
        shakeDuration = duration;
        shakeMagnitude  = magnitude;

        originalPosition = cameraTransform.localPosition;
        currentShakeDuration = shakeDuration;
        currentShakeMagnitude = shakeMagnitude;
    }
}
