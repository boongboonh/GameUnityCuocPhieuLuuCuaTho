using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotBullet : MonoBehaviour
{
    //toc do bay cua dan
    public float speed = 10f;
    public int dame_carrotBullet = 1;
    public Rigidbody2D rb;

    public GameObject impactEffect;//hieu ung dan

    private GameObject instan;

    void Start()
    {
        rb.velocity = transform.right * speed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            EnemyController enemy = collision.GetComponent<EnemyController>();
            if (enemy != null)
            {
               
                enemy.TakeDame(dame_carrotBullet);
            }

            instan = Instantiate(impactEffect, transform.position, transform.rotation);


            //phá hủy đạn
            Destroy(gameObject);


            //phá hủy hiệu ứng đạn nổ 
            Destroy(instan, 0.35f);
        }
    }

    private void Update()
    {
        //phá hủy đạn sau 1.5s;
        Destroy(gameObject, 1.5f);
    }




}
