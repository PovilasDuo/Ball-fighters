using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_Text p1Hp;
    public TMP_Text p2Hp;
    public TMP_Text victoryText;
    public Button restartButton;

    public GameObject P1;
    public GameObject P2;

    private void Update()
    {
        p1Hp.text = "P1 HP: " + P1.GetComponent<Stats>().health.ToString();
        p2Hp.text = "P2 HP: " + P2.GetComponent<Stats>().health.ToString();
        GameOver();
    }

    public void GameOver()
    {
        if (P1.GetComponent<Stats>().health == 0 || P2.GetComponent<Stats>().health == 0)
        {
            victoryText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            if (P1.GetComponent<Stats>().health == 0)
            {
                victoryText.text = "Player one wins";
            }
            else if (P2.GetComponent<Stats>().health == 0)
            {
                victoryText.text = "Player two wins";
            }
            P1.GetComponent<Movement>().enabled = false;
            P2.GetComponent<Movement>().enabled = false;
        }
    }
}
