using UnityEngine;

public class BulletExplosion : MonoBehaviour
{

    public float radius = 5f, force = 700f;

    public GameObject explosionEffect;

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Triggered");
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in collidersToMove)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
        Destroy(gameObject);
        

    }
}
