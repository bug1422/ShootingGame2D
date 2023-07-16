using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Tank tank;
    public Text heatlhText;
    public Text scoreText;
    public Text gameOverScore;
    public GameObject scoreBoard;
    public GameObject gameStartScreen;
    public GameObject gameOverScreen;

    [ContextMenu("Subtract Health")]
    public void subHealth(int healthPoint)
    {
        tank.health -= healthPoint;
        if (tank.health <= 0)
        {
            tank.isAlive = false;
            gameOver();
        }
        else
        {
            heatlhText.text = "Health: " + tank.health.ToString();
        }
    }

    [ContextMenu("Add Point")]
    public void addScore(int score)
    {
        tank.score += score;
        scoreText.text = "Score: " + tank.score.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameStart()
    {
        tank.isAlive = true;
        Cursor.visible = false;
        scoreBoard.SetActive(true);
        gameStartScreen.SetActive(false);
    }

    public void gameOver()
    {
        gameOverScore.text = "Score :" + tank.score;
        Cursor.visible = true;
        scoreBoard.SetActive(false);
        gameOverScreen.SetActive(true);
    }
}
