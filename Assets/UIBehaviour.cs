using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class UIBehaviour : MonoBehaviour
{
    TMP_Text coinText;
    TMP_Text timerText;

    void Start()
    {
        coinText = GameObject.Find("lblCoins").GetComponent<TMPro.TMP_Text>();
        timerText = GameObject.Find("lblTime").GetComponent<TMPro.TMP_Text>();

        timerText.text = "Time :" + GameVariables.currentTime.ToString();
        coinText.text = "Coins: " + GameVariables.nbCoins;
        StartCoroutine(TimerTick());
    }
    void Update()
    {
    }
    public void AddHit()
    {
        GameVariables.nbCoins++;
        coinText.text = "Coins: " + GameVariables.nbCoins;
    }

    IEnumerator TimerTick()
    {
        while (GameVariables.currentTime > 0)
        {
            // attendre une seconde
            yield return new WaitForSeconds(1);
            GameVariables.currentTime--;
            timerText.text = "Time :" + GameVariables.currentTime.ToString();
        }
        // game over
        SceneManager.LoadScene("TP2-level1"); // le nom de votre scene
        GameVariables.currentTime = 10;
    }


}