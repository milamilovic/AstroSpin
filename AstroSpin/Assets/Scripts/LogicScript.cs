using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{

    public GameObject gameOverScreen;
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverScreen.SetActive(false);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

}
