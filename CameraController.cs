using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraDistance = 10f;
    public float cameraHeight = 5f;
    public float cameraSmoothness = 0.1f;
    public Transform playerTransform;

    private Camera mainCamera;
    private Vector3 cameraOffset;

    void Start()
    {
        mainCamera = Camera.main;
        cameraOffset = mainCamera.transform.position - playerTransform.position;
    }

    void LateUpdate()
    {
        Vector3 cameraPosition = playerTransform.position + cameraOffset.normalized * cameraDistance;
        RaycastHit hit;
        if (Physics.Raycast(playerTransform.position, cameraPosition - playerTransform.position, out hit, cameraDistance))
        {
            cameraPosition = hit.point;
        }
        cameraPosition.y = playerTransform.position.y + cameraHeight;

        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, cameraPosition, cameraSmoothness);
    }
}