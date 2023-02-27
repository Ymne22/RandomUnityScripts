using UnityEngine;

public class CameraFOV : MonoBehaviour
{
    [SerializeField] private float minFOV = 20f;
    [SerializeField] private float maxFOV = 100f;
    [SerializeField] private float sensitivity = 10f;
    [SerializeField] private float smoothness = 5f;

    private Camera cam;

    private float targetFOV;
    private float currentFOV;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        currentFOV = cam.fieldOfView;
        targetFOV = currentFOV;
    }

    private void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0)
        {
            targetFOV -= scrollInput * sensitivity;
            targetFOV = Mathf.Clamp(targetFOV, minFOV, maxFOV);
        }

        currentFOV = Mathf.Lerp(currentFOV, targetFOV, Time.deltaTime * smoothness);
        cam.fieldOfView = currentFOV;
    }
}