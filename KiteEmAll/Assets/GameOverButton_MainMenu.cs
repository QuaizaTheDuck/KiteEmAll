using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButton_MainMenu : MonoBehaviour
{
    public void BackToMenu()
    {
        Debug.Log("Back to Main menu");
        SceneManager.LoadScene("MainMenu");
    }
}
