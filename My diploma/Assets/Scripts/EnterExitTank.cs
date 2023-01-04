using UnityEngine;

public class EnterExitTank : MonoBehaviour
{
    public GameObject player, tank, playerCamera, tankCamera, exitPoint;
    public bool isPlayer, inCar;


    
    void Start()
    {
        GetComponent<TankController>().enabled = false;
        GetComponent<Shooting>().enabled = false;
        playerCamera.SetActive(true);
        tankCamera.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isPlayer = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayer = false;
        }
    }
    
    void Update()
    {
        if(isPlayer == true)
        {
            if(Input.GetKeyUp(KeyCode.E))
            {
                player.SetActive(false);
                inCar = true;
                tankCamera.SetActive(true);
                playerCamera.SetActive(false);
                GetComponent<TankController>().enabled = true;
                GetComponent<Shooting>().enabled = true;

            }
        }

        if(inCar == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                player.SetActive(true);
                
                inCar = false;
                GetComponent<TankController>().enabled = false;
                GetComponent<Shooting>().enabled = false;
                tankCamera.SetActive(false);
                playerCamera.SetActive(true);
                player.transform.position = exitPoint.transform.position;
            }
        }
    }
}
