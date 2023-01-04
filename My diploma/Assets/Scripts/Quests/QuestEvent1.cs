using UnityEngine;

public class QuestEvent1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("test", 1);
        }
    }      
}
