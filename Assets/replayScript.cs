using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class replayScript : MonoBehaviour
{
    public void replayButton()
    {

        float background = PlayerPrefs.GetFloat("BackgroundPref");
        float effect = PlayerPrefs.GetFloat("SoundEffectsPref");

        PlayerPrefs.DeleteAll();        //xoa toan bo du lieu game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        PlayerPrefs.SetFloat("BackgroundPref", background);
        PlayerPrefs.SetFloat("SoundEffectsPref", effect);
    }
    
    public void OpentAllButton()
    {

        PlayerPrefs.SetInt("level1point", 1);
        PlayerPrefs.SetInt("level2point", 1);
        PlayerPrefs.SetInt("level3point", 1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
