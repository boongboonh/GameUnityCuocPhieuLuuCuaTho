using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelSelect : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";

    private static readonly string Level1Point = "level1point";
    private static readonly string Level2Point = "level2point";
    private static readonly string Level3Point = "level3point";
    [SerializeField] private GameObject LV2;
    [SerializeField] private GameObject LV3;

  
    [SerializeField] private GameObject level1_s0;
    [SerializeField] private GameObject level1_s1;
    [SerializeField] private GameObject level1_s2;
    [SerializeField] private GameObject level1_s3;

    [SerializeField] private GameObject level2_lock;
    [SerializeField] private GameObject level2_s0;
    [SerializeField] private GameObject level2_s1;
    [SerializeField] private GameObject level2_s2;
    [SerializeField] private GameObject level2_s3;

    [SerializeField] private GameObject level3_lock;
    [SerializeField] private GameObject level3_s0;
    [SerializeField] private GameObject level3_s1;
    [SerializeField] private GameObject level3_s2;
    [SerializeField] private GameObject level3_s3;

    //luu diem max cua moi level
    private int level1Score;
    private int level2Score;
    private int level3Score;

    private int firstPlayInt;


   
    private void Start()
    {

        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0)
        {
            PlayerPrefs.SetInt(Level1Point, 0);
            PlayerPrefs.SetInt(Level2Point, 0);
            PlayerPrefs.SetInt(Level3Point, 0);

            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            level1Score = PlayerPrefs.GetInt(Level1Point);
            level2Score = PlayerPrefs.GetInt(Level2Point);
            level3Score = PlayerPrefs.GetInt(Level3Point);
        }


        checkStars(20,level1Score,null, level1_s0, level1_s1, level1_s2, level1_s3);
        checkStars(PlayerPrefs.GetInt(Level1Point),level2Score,level2_lock, level2_s0, level2_s1, level2_s2, level2_s3);
        checkStars(PlayerPrefs.GetInt(Level2Point),level3Score,level3_lock, level3_s0, level3_s1, level3_s2, level3_s3);
        
    }

  


    private void checkStars(int diemtruoc,int diem, GameObject lockmap, GameObject khongsao, GameObject motsao, GameObject haisao, GameObject basao)
    {
        if (diemtruoc>0)
        {
            if (diem <= 3)
            {
                khongsao.SetActive(true);
            }
            else if (diem > 3 && diem <= 10)
            {
                motsao.SetActive(true);
            }
            else if (diem > 10 && diem <= 19)
            {
                haisao.SetActive(true);
            }
            else if (diem == 20)
            {
                basao.SetActive(true);
            }
            else
            {
                khongsao.SetActive(true);
            }
        }
        else
        {
            lockmap.SetActive(true);
        }
    }
    
    public void Level1Load()
    {
        SceneManager.LoadScene("Map1");
    }
    public void Level2Load()
    {
        SceneManager.LoadScene("Map2");
    }
    public void Level3Load()
    {
        SceneManager.LoadScene("Map3");
    }
    public void MenuLoad()
    {
        SceneManager.LoadScene("Menu");
    }


 
}
