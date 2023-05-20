using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField] public int dame_player = 1;
    [SerializeField] public float strong_Jump = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        //kiểm tra có chạm vào điểm yếu của quái không? nếu có  xóa đối tượng
        if (collision.gameObject.CompareTag("enemy"))
        {
            var enemy = collision.gameObject.GetComponent<EnemyController>();
            enemy.TakeDame(dame_player);
            
            jump_ani();
            
        }

    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //kiểm tra có chạm vào điểm yếu của quái không? nếu có  xóa đối tượng
        if (collision.gameObject.CompareTag("enemy"))
        {
            var enemy = collision.gameObject.GetComponent<EnemyController>();
            enemy.TakeDame(dame_player);
            
            jump_ani();

        }
    }
    private void jump_ani()
    {

        //nảy nên khi nhảy trúng đầu kẻ thù

       PlayerMovement pm =gameObject.GetComponent<PlayerMovement>();
        pm.player_jump_acti(strong_Jump);
        
        

    }
}
