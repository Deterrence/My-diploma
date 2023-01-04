using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform fireStart;
    public GameObject explosionFireEffect;
    private bool isAvaliable = true;

    private Rigidbody rb;
    public int fireForce = 600;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        FireBullet();
    }

    void FireBullet()
    {
        if (Input.GetMouseButton(0) && isAvaliable)
        {
            Instantiate(explosionFireEffect, fireStart.position, fireStart.rotation);
            Vector3 SpawnPoint = fireStart.transform.position;
            Quaternion SpawnRoot = fireStart.transform.rotation;
            GameObject Pula_for_faer = Instantiate(bullet, SpawnPoint, SpawnRoot) as GameObject;
            Rigidbody Run = Pula_for_faer.GetComponent<Rigidbody>();
            Run.AddForce(Pula_for_faer.transform.forward * 100, ForceMode.Impulse);
            Destroy(Pula_for_faer, 5f);
            rb.AddRelativeForce(0, 0, -100000);
            StartCoroutine(ShootCooldown());
        }

    }
    IEnumerator ShootCooldown()
    {
        isAvaliable = false;
        yield return new WaitForSeconds(3);
        isAvaliable = true;
    }
}
