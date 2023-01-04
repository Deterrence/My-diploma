using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    private float mouseX = 0f;
    private float mouseY = 0f;
    private float xRotation;

    public Transform player;
    public float sensivityMouse = 200f;
    

    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensivityMouse * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensivityMouse * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation =  Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
       
    }
    
}
