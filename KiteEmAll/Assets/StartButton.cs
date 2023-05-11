using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartButton : MonoBehaviour
{
    public void StarGameplay()
    {
        SceneManager.LoadScene("Gameplay");
        if (Time.timeScale == 0)
            Time.timeScale = 1;
    }
    private void Update()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;


    }


}
