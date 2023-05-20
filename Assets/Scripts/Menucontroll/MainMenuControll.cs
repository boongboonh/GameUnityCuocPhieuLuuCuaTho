using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuControll : MonoBehaviour
{

  public void PlayGame()
    {
        //load màn hình game
        SceneManager.LoadScene("LevelsSelect");
    }
    public void QuitGame()
    {
        //thoát game
        Debug.Log("thoát game");
        Application.Quit();
    }

 

}

