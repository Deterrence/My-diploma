using UnityEngine;

public class TankCamera : MonoBehaviour
{

    private const float Y_ANGLE_MIN = 20.0f;
    private const float Y_ANGLE_MAX = 20.0f;

    public float sensitivity = .3f;
    public Transform lookAt;
    public Transform camTransform;
    public float distance = 5.0f;



    private float currentX = 0.0f;
    private float currentY = 20.0f;


    private void Start()
    {
        camTransform = transform;
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void Update()
    {

        currentX += Input.GetAxis("Mouse X") * sensitivity;
        currentY += Input.GetAxis("Mouse Y") * sensitivity;
        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);


    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);


    }
}