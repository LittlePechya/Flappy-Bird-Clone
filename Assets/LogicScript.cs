using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public int highscore;

    public TextMeshProUGUI score;
    public TextMeshProUGUI highscoreText;

    public GameObject gameOverScreen;
    public AudioSource scoreSFX;

    void Awake()
    {
        if (!PlayerPrefs.HasKey("highscore"))
        {
            PlayerPrefs.SetInt("highscore", 0);
        }
        
        highscore = PlayerPrefs.GetInt("highscore");
        setHighscore();
    }

    [ContextMenu("Increase score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreSFX.Play();
        score.text = playerScore.ToString();

        if (playerScore > highscore)
        {
            highscore = playerScore;
            PlayerPrefs.SetInt("highscore", highscore);
            setHighscore();
        }
    }

    public void restartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver() 
    {
        gameOverScreen.SetActive(true);
    }

    private void setHighscore() 
    {
        highscoreText.text = "Highscore: " + highscore.ToString();
    }
}
