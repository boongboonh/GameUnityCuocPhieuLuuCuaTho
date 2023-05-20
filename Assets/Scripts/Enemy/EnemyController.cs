using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public AudioSource enemy_hurt_audio;

    private Animator animator;
    public int health = 1;
    public GameObject DieEffect;
    private GameObject instan;
    public void Start()
    {
        animator = GetComponent<Animator>();

    }
    public void TakeDame(int damege)
    {
        
        health -= damege;
       
        if (health <= 0)
        {
            
            Die();
        }
        //âm thanh
        enemy_hurt_audio.Play();
    }

    public void Die()
    {

 
        //animator.SetTrigger("EnemyDie");

        
        try
        {
            //dung di chuyen
            GetComponent<Waypointforenemy>().enabled = false;
        }
        catch (System.Exception)
        {

           
        }

        //pha huy enemy trong sau 0.5s;


        Destroy(gameObject);
        instan = Instantiate(DieEffect, transform.position, Quaternion.identity);
        Destroy(instan, 0.5f);
    }
}
