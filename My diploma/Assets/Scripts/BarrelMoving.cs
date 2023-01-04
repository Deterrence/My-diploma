using UnityEngine;

public class BarrelMoving : MonoBehaviour
{

    public float sensitivity = .3f;
    private Vector2 turn;
    private const float Y_BARREL_MIN = -10.0f;
    private const float Y_BARREL_MAX = 5.0f;

    void Update()
    {
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        turn.y = Mathf.Clamp(turn.y, Y_BARREL_MIN, Y_BARREL_MAX);
        transform.localRotation = Quaternion.Euler(turn.y, 0, 0);
    }

}