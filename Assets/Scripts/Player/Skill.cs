using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    public GameObject skill_destroy;

    private GameObject instan;
    public float timeMaintain = 5f;
    public float speed = 4f;
    public float hightBall = 0.5f;
    public float strongJump = 14f;
    public float timeToStop = 0.3f;


    [SerializeField] private LayerMask SkillLayer;

   
    private float timeToScale=0.2f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        coll = GetComponent<BoxCollider2D>();
        rb.velocity = transform.right * speed;
        gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        gameObject.GetComponent<Collider2D>().isTrigger = true;
        StartCoroutine(MoveBall());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(outBall());
        }
        
    }
    IEnumerator outBall() //ra khoi bong 1 time thì khôi phục colision
    {

        yield return new WaitForSeconds(0.1f);

        gameObject.GetComponent<Collider2D>().enabled = true; //bật lại collision


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       

        if (collision.gameObject.CompareTag("Player"))
        {
            
            var player = collision.gameObject.GetComponent<PlayerMovement>();

            player.player_jump_acti(strongJump);

            CreateAndDestroyBall(0f);
        }

       
    }


    //Update is called once per frame
    void Update()
    {



        timeToScale += Time.deltaTime + 0.1f;
        
        scaleBall(timeToScale);
       
        
        StartCoroutine(DestroyBall());
    }
    //xét khoảng cách bóng với player để nó dừng lại. 

    IEnumerator MoveBall()
    {
        
        yield return new WaitForSeconds(timeToStop);
       
        rb.velocity = Vector2.zero; //dừng bóng lại

        gameObject.GetComponent<Collider2D>().isTrigger = false;

    }

    IEnumerator DestroyBall()
    {
        yield return new WaitForSeconds(timeMaintain);

        instan = Instantiate(skill_destroy, transform.position, transform.rotation);//tạo hiệu ứng vỡ 
        instan.GetComponent<Collider2D>().enabled = false;

        Destroy(gameObject); //phá hủy bóng
        Destroy(instan, 0.5f); //phá hủy hiệu ứng nổ
    }

   

    void CreateAndDestroyBall(float time)
    {
        instan = Instantiate(skill_destroy, transform.position, transform.rotation);//tạo hiệu ứng vỡ

        instan.GetComponent<Collider2D>().enabled = false;

        Destroy(gameObject,time); //phá hủy bóng
        Destroy(instan, 0.5f); //phá hủy hiệu ứng nổ
    }

    void scaleBall(float timeScale)
    {
        if (timeScale <= 1)
        {
            gameObject.transform.localScale = new Vector3(timeScale, timeScale, timeScale);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+0.04f, 0f);
        }
        
    }
}
