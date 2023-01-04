using UnityEngine;
using UnityEngine.SceneManagement;

public class HomePortal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            SceneManager.LoadScene("Main");
    }
}
