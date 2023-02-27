using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float rotateSpeed = 5f;
    [SerializeField] private Vector2 inputAxes = new Vector2(1f, 0f);
    [SerializeField] private float minRotation = -90f;
    [SerializeField] private float maxRotation = 90f;
    [SerializeField] private Vector3 rotationAxis = Vector3.up;

    private float horizontalInput;
    private float verticalInput;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Mouse X") * inputAxes.x;
        verticalInput = Input.GetAxis("Mouse Y") * inputAxes.y;

        Vector3 newRotation = transform.rotation.eulerAngles;
        newRotation += new Vector3(verticalInput * rotateSpeed, horizontalInput * rotateSpeed, 0f);
        newRotation.x = Mathf.Clamp(newRotation.x, minRotation, maxRotation);

        transform.rotation = Quaternion.Euler(newRotation);
        transform.position = target.position - transform.rotation * Vector3.forward;
    }
}