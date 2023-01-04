using UnityEngine;

public class TurretMoving : MonoBehaviour
{
    public Transform cam;
    public float diff;
    private float dir;
    public float rotationSpeed;
    public float luft = 2;

    void FixedUpdate()
    {
        diff = Vector3.SignedAngle(transform.forward, cam.forward, Vector3.up);
        if (Mathf.Abs(diff - 20) < luft)
        {
            dir = 0;
            //Debug.Log("1");
        }
        else
        {
            dir = Mathf.Sign(diff);
            //Debug.Log("2");
        }
        transform.Rotate(0, Time.fixedDeltaTime * rotationSpeed * dir, 0);
    }
}