using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    private bool faceRight = true;
    private float index = 0; //vị trí bụi vừa sinh ra

    //âm thanh
    public AudioSource run_audio;
    public AudioSource jump_audio;

    //biến lưu hiệu ứng jump
    public GameObject instan_jump;
    private GameObject instan_jump_old;


    //biến lưu hiệu ứng run
    public GameObject instan_run;
    private GameObject instan_run_old;
    public float timeDelay = 1.3f;


    [SerializeField] private LayerMask jumpableGround;
    

    //chỉ số di chuyển
    private float dirX = 0f;


    //tốc độ di chuyển 
    [SerializeField] private float speedMove = 7f;


    //sức nhảy
    [SerializeField] private float jumpStrong = 7f;


    //biến trạng thái
    private enum MovementState{idle, run, jump, fall}



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        animator= GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
      

    }

    // Update is called once per frame
    private void Update()
    {

      
    }

    private void FixedUpdate()
    {
        //di chuyển trái phải
        dirX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(dirX * speedMove, rb.velocity.y);

        //điều khiển nhảy bằng nút space => trong edit> project setting
        if (Input.GetButtonDown("Jump") && IsGround())
        {

            player_jump_acti(jumpStrong);

            //tạo hiệu ứng bụi khi nhảy của player
            instan_jump_old = Instantiate(instan_jump, new Vector3(transform.position.x, transform.position.y - 0.3f, 0f), transform.rotation);

            Destroy(instan_jump_old, 0.5f);
        }

        //gọi hàm điều khiển animation
        updateAnimation();

    }

    public void player_jump_acti(float strong)
    {
        //âm thanh
        jump_audio.Play();

        rb.velocity = new Vector3(0, strong, 0);
    }


    //Điều khiển animation
    private void updateAnimation()
    {

        MovementState state;


        // check quay dau
        if (dirX > 0 && !faceRight)
        {
            //state = MovementState.run;
            //sprite.flipX = false;
            flip();
        }
        else if (dirX < 0 && faceRight)
        {
            //state = MovementState.run;
            //sprite.flipX = true;
            flip();
        }


        //chay animation
        if (dirX != 0 && IsGround())
        {
            state = MovementState.run;
            effect_run();
        }
        else
        {
            state = MovementState.idle;
            
        }

       

        //animation jump
        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jump;
        } else if (rb.velocity.y <= -0.1f)
        {
            state = MovementState.fall;
        }



        animator.SetInteger("state", (int)state);
    }

    //check mặt đất 
    private bool IsGround()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f,jumpableGround);
    }

    private void flip()
    {
        faceRight = !faceRight;

        transform.Rotate(0f, 180f, 0f);

    }


    // hiệu ứng bụi 
    private void effect_run()
    {
        // nếu nhân vật di chuyển khoảng cách nhất định thì sinh hiệu ứng bụi
        if (dirX != 0 && IsGround() && Mathf.Abs(index - transform.position.x) > 0.7f)
        {
            instan_run_old = Instantiate(instan_run, new Vector3(transform.position.x, transform.position.y - 0.8f, 0f), transform.rotation);
            
            index = instan_run_old.transform.position.x;
            Destroy(instan_run_old, 0.5f);

            //âm thanh

            run_audio.Play();
        }
    }


   
}
