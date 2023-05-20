using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class WeaponCarrot : MonoBehaviour
{
    public Transform carrotPoint;
    public GameObject bulletPrefab;
    public GameObject skillPrefab;

    // lay so dan
    public Text NumberBulletText;


    public AudioSource bullet_audio;
    public AudioSource skill_audio;

    //tạo thời chờ đạn
    public float cooldownBullet = 3f;

    private bool checkCooldownBullet = false;
   
    private float timeCooldownBullet = 0f; //thoi gian hoi thuc te



    //tạo thời gian chờ ball
    public float cooldownBall = 2f;
    private bool checkCooldownBall = false;
    private float timeCooldownBall = 0f;


    //biến cooldown bullet ui
    [SerializeField] private Image imageCooldownBullet;
    [SerializeField] private TMP_Text textCooldownBullet;
    [SerializeField] private Image imageEdgeBullet;

    //biến cooldown ball ui
    [SerializeField] private Image imageCooldownBall;
    [SerializeField] private TMP_Text textCooldownBall;
    [SerializeField] private Image imageEdgeBall;

    private void Start()
    {
        textCooldownBullet.gameObject.SetActive(false);
        imageEdgeBullet.gameObject.SetActive(false);
        imageCooldownBullet.fillAmount = 0.0f;

        textCooldownBall.gameObject.SetActive(false);
        imageEdgeBall.gameObject.SetActive(false);
        imageCooldownBall.fillAmount = 0.0f;
    }


    void Update()
    {

        //bắn đạn

        //kiểm tra ân nut, thời gian hồi , số đạn
        if (Input.GetMouseButtonDown(0) && !checkCooldownBullet && checkBullet()==true)
        {
            Shoot();
           
            timeCooldownBullet = cooldownBullet; //dat lại thời gian hồi chiêu
            checkCooldownBullet = true;
            NumberBulletText.text = (int.Parse(NumberBulletText.text)-1).ToString();

        }


        if(checkCooldownBullet)
        {
            applyCooldownBulletUI();

        }
        else
        {
            textCooldownBullet.gameObject.SetActive(false);
            imageEdgeBullet.gameObject.SetActive(false);
        }




        //skill
        if (Input.GetMouseButtonDown(1)&& !checkCooldownBall)
        {
            Skill();
            checkCooldownBall = true;
            timeCooldownBall = cooldownBall;
        }
        if (checkCooldownBall)
        {
            applyCooldownBallUI();

        }
        else
        {
            textCooldownBall.gameObject.SetActive(false);
            imageEdgeBall.gameObject.SetActive(false);
        }



    }

    void Shoot()
    {
       
        //tạo đối tượng đạn
        Instantiate(bulletPrefab, carrotPoint.position, carrotPoint.rotation);
        //âm thanh
        bullet_audio.Play();
    }


    void Skill()
    {
        //tạo đối tượng bóng
        Instantiate(skillPrefab, carrotPoint.position, carrotPoint.rotation);
        //âm thanh
        skill_audio.Play();
    }

    void FixedUpdate()
    {
        if (timeCooldownBullet > 0 && checkCooldownBullet)
        {
            timeCooldownBullet -= Time.deltaTime;
        }
        else
        {
            checkCooldownBullet = false;
            
        }

        //kiểm tra thời gian hồi skill
        checkBallSkill();
    }


//kiem tra cooldown đạn
    void applyCooldownBulletUI()
    {
        if (checkCooldownBullet == false)
        {
            textCooldownBullet.gameObject.SetActive(false);
            imageCooldownBullet.gameObject.SetActive(false);
            imageCooldownBullet.fillAmount = 0.0f;
        }
        else
        {
            textCooldownBullet.gameObject.SetActive(true);
            imageEdgeBullet.gameObject.SetActive(true);
            textCooldownBullet.text = Math.Round(timeCooldownBullet,1).ToString();
            imageCooldownBullet.fillAmount = timeCooldownBullet / cooldownBullet;

            imageEdgeBullet.transform.localEulerAngles = new Vector3(0f, 0f, 360f * (timeCooldownBullet / cooldownBullet));

            
        }
       
    }

    //kiem tra cooldown đạn
    void applyCooldownBallUI()
    {
        if (checkCooldownBall == false)
        {
            textCooldownBall.gameObject.SetActive(false);
            imageCooldownBall.gameObject.SetActive(false);
            imageCooldownBall.fillAmount = 0.0f;
        }
        else
        {
            textCooldownBall.gameObject.SetActive(true);
            imageEdgeBall.gameObject.SetActive(true);
            textCooldownBall.text = Math.Round(timeCooldownBall, 1).ToString();
            imageCooldownBall.fillAmount = timeCooldownBall / cooldownBall;

            imageEdgeBall.transform.localEulerAngles = new Vector3(0f, 0f, 360f * (timeCooldownBall / cooldownBall));


        }

    }
    //kiem tra cooldown ball
    void checkBallSkill()
    {
        if (timeCooldownBall>0&& checkCooldownBall)
        {
            timeCooldownBall -= Time.deltaTime;
            
        }
        else
        {

            checkCooldownBall = false;
        }
    }



    //kiểm tra số đạn còn không
    bool checkBullet()
    {
        int sodan = int.Parse(NumberBulletText.text);
        if (sodan > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

}
