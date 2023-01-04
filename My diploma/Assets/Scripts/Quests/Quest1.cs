using UnityEngine;
using UnityEngine.UI;

public class Quest1 : MonoBehaviour
{
    public GameObject textPanel, questPanel, completedPanel;
    public GameObject questPoint, nextQuestPoint;
    public Text questPanelText;
    public Button acceptBtn, declineBtn;
    public int test;

    private void Update() 
    {
       test = PlayerPrefs.GetInt("test");

        if (test == 1)
        {
            questPanelText.text = "Activate portal. 1/1";
            questPoint.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            textPanel.SetActive(true);           
        }
        if (other.gameObject.tag == "Player" && test == 1)
        {
           completedPanel.SetActive(true);

        }
    }


    private void OnTriggerExit(Collider other)
    {
       
        if (other.gameObject.tag == "Player")
        {
            textPanel.SetActive(false);
        }
        if (other.gameObject.tag == "Player" && test == 1)
        {
            completedPanel.SetActive(false);
            questPoint.SetActive(false);
            nextQuestPoint.SetActive(true);
        }
    }
    public void Accept()
    {
        questPoint.SetActive(false);
        textPanel.SetActive(false);
        questPanel.SetActive(true);
    }
    public void Decline()
    {
        textPanel.SetActive(false);
    }
        

}
