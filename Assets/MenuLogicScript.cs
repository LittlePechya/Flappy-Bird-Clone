using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLogicScript : MonoBehaviour
{
    public void startGame() {
        SceneManager.LoadSceneAsync("Game");
    }

    public void quitGame() {
        Application.Quit();
    }
}
