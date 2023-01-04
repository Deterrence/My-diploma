using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TankController : MonoBehaviour
{


    public float speed = 0f, rotateSpeedX = 10;
    [Range(0, 25000)] public float maxSpeed = 7500f;
    [Range(0, 50)] public float rotateSpeed = 30f;
    public bool allowed = true;

    private Rigidbody rb;
    public float xAnglece;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        xAnglece = transform.eulerAngles.x;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        transform.Rotate(0f, Time.deltaTime * rotateSpeed * moveHorizontal, 0f);
        if (moveHorizontal != 0f)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);
        }

        speed = rb.velocity.magnitude;
        speed = Mathf.Clamp(speed, 0, 15);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.W) && allowed)
            {
                forwardMove();
                forwardRotate();
            }

            else if (Input.GetKey(KeyCode.S))
            {
                backMove();
                backRotate();          
                allowed = false;
            }
            else
            {
                allowed = true;
            }
        }


        else
        {
            if (transform.eulerAngles.x > 0f && transform.eulerAngles.x < 5f)
            {
                rb.transform.Rotate(-20 * Time.fixedDeltaTime, 0f, 0f);
            }
            if (transform.eulerAngles.x > 355f)
            {
                rb.transform.Rotate(20 * Time.fixedDeltaTime, 0f, 0f);
            }
        }
        void forwardMove()
        {
            rb.AddRelativeForce(new Vector3(0f, 0f, moveVertical) * maxSpeed * 0.8f);

        }

        void backMove()
        {
            rb.AddRelativeForce(new Vector3(0f, 0, moveVertical) * maxSpeed * 0.6f);
            Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
            localVelocity.x = 0;
            rb.velocity = transform.TransformDirection(localVelocity);
            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }

        }

        void forwardRotate()
        {
            
            if (transform.eulerAngles.x > 356f || transform.eulerAngles.x < 4f)
            {
                rb.transform.Rotate(-10f * Time.fixedDeltaTime, 0f, 0f);

            }
            if (transform.eulerAngles.x > 0 && transform.eulerAngles.x < 5)
            {
                rb.transform.Rotate(-20f * Time.fixedDeltaTime, 0f, 0f);
            }
        }

        void backRotate()
        {

          
            if (transform.eulerAngles.x < 4f || transform.eulerAngles.x > 356f)
            {
                rb.transform.Rotate(10f * Time.fixedDeltaTime, 0f, 0f);

            }
            if (transform.eulerAngles.x > 355f && transform.eulerAngles.x < 360)
            {
                rb.transform.Rotate(20f * Time.fixedDeltaTime, 0f, 0f);
            }
        }
    }
}