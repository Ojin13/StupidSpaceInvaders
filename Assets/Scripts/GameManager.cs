using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI enemiesText;
    public TextMeshProUGUI endGameText;
    public TextMeshProUGUI freeLaserText;
    public GameObject endGamePanel;
    public static GameManager gameManager;
    public string status = "playing";
    public int numberOfEnemies = 15;
    public int freeLaser = 3;


    void Awake()
    {
        gameManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(numberOfEnemies <= 0 && status == "playing"){
            status = "win";
            AudioManager.audioManager.PlayYouWinSound();
        }

        if(status == "lost"){
            endGameText.SetText("You lose!\nClick here to\ntry again");
        }

        if(status == "win"){
            endGameText.SetText("You win!\nClick here to\nplay again");
        }

        enemiesText.SetText("Enemies: "+numberOfEnemies.ToString());


        if(status != "playing"){
            endGamePanel.SetActive(true);
        }else{
            endGamePanel.SetActive(false);
        }

        freeLaserText.SetText("Press 'F' to fire laser "+freeLaser.ToString()+"/3");
    }


    public void RestartGame(){
        AudioManager.audioManager.PlayButtonClickSound();
        SceneManager.LoadScene("SampleScene");
    }
}
