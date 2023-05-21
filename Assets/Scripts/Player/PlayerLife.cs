using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//thư viện quản lý scene
using UnityEngine.SceneManagement;


public class PlayerLife : MonoBehaviour
{
    public AudioSource death_audio;
    public AudioSource hurt_audio;

    private Animator animator;

    private Rigidbody2D rb;

    private static readonly string Level1Point = "level1point";
    private static readonly string Level2Point = "level2point";
    private static readonly string Level3Point = "level3point";

    //menu gameover
    [SerializeField] private GameObject GameOverMenuUI;
    [SerializeField] private GameObject GameWinUI;

    [SerializeField] private Text temptNumberCarrots;
    [SerializeField] private GameObject zeroStar;
    [SerializeField] private GameObject oneStar;
    [SerializeField] private GameObject twoStar;
    [SerializeField] private GameObject threeStar;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // thua ngay khi rơi xuống vực hoặc nước
        if (collision.gameObject.CompareTag("Kill"))
        {
            //âm thanh 
            death_audio.Play();
            GameOverMenuUI.SetActive(true);
            Die();
        }


        //khi chạm vào quái
        if (collision.gameObject.CompareTag("trap") || collision.gameObject.CompareTag("enemy"))
        {
            HealthManager.Instance.health--;
            HealthManager.Instance.ResetUIHealth();
            if (HealthManager.Instance.health <= 0)
            {
                //âm thanh 
                death_audio.Play();
                GameOverMenuUI.SetActive(true);
                Die();

            }
            else
            {
                //âm thanh
                hurt_audio.Play();

                StartCoroutine(GetHurt());
            }
        }




        //khi chạm vào đích win game
        if (collision.gameObject.CompareTag("end"))
        {

            rb.bodyType = RigidbodyType2D.Static;
            GetComponent<PlayerMovement>().enabled = false;

            //lưu điểm cao nhất
            checkMaxPointMap();

            GameWinUI.SetActive(true);

            //hiển thị số sao đạt được
            starScoreUI();

        }

    }


    //kiểm tra điểm cao nhất truyền về menulevel
    private void checkMaxPointMap()
    {
        if (SceneManager.GetActiveScene().name.CompareTo("Map1") == 0)
        {
            int temp = carrotScore(PlayerPrefs.GetInt(Level1Point));
            PlayerPrefs.SetInt(Level1Point, temp);                    // Cập nhật lại điểm cao nhất
        }
        else if(SceneManager.GetActiveScene().name.CompareTo("Map2") == 0)
        {
            int temp = carrotScore(PlayerPrefs.GetInt(Level2Point));
            PlayerPrefs.SetInt(Level2Point, temp);                  // Cập nhật lại điểm cao nhất
        }
        else if(SceneManager.GetActiveScene().name.CompareTo("Map3") == 0)
        {
            int temp = carrotScore(PlayerPrefs.GetInt(Level3Point));
            PlayerPrefs.SetInt(Level3Point, temp);                   // Cập nhật lại điểm cao nhất
        }
    }

    //hien thi so sao khi win
    private void starScoreUI()
    {
        int carrots = int.Parse(temptNumberCarrots.text);
        if (carrots <=3)
        {
            zeroStar.SetActive(true);
        }else if (carrots > 3 && carrots <= 10)
        {
            oneStar.SetActive(true);
        }else if(carrots>10 && carrots < 19)
        {
            twoStar.SetActive(true);
        }else if (carrots == 20)
        {
            threeStar.SetActive(true);
        }
    }

    //so sanh ket qua cux
    private int carrotScore(int maxPointOld)
    {
        int carrots = int.Parse(temptNumberCarrots.text);
        if (carrots > maxPointOld)
        {
            return carrots;
        }
        else
        {
            return maxPointOld;
        }
    }

  
    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(10,11);
        Physics2D.IgnoreLayerCollision(10, 12);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(2);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(10, 11, false);
        Physics2D.IgnoreLayerCollision(10, 12,false);

    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        GetComponent<PlayerMovement>().enabled = false;
        animator.SetTrigger("death");
    }


}
