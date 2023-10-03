using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{   
    [SerializeField] TMP_Text gameOverText;
    [SerializeField] ScoreSystem scoreSystem;
    [SerializeField] GameObject gameOverDisplay;
    [SerializeField] Spawner spawner;

    public void EndGame()
    {
        spawner.enabled = false;
        
        int finalScore = scoreSystem.EndScoreTime();

        gameOverText.text = $"Your Score: {finalScore}";

        gameOverDisplay.gameObject.SetActive(true);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
