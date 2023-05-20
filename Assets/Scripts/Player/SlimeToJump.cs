using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeToJump : MonoBehaviour
{
    [SerializeField] public float strong_Jump = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("slime"))
        {
           
            jump_ani();
        }
    }
    private void jump_ani()
    {

        //nảy nên khi nhảy trúng đầu kẻ thù

        PlayerMovement pm = gameObject.GetComponent<PlayerMovement>();
        pm.player_jump_acti(strong_Jump);

    }
}
