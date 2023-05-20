using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickyPlatform : MonoBehaviour
{
   
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
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
    IEnumerator outBall() //ra khoi thanh truot 1 time thì khôi phục colision
    {

        yield return new WaitForSeconds(0.1f);

        gameObject.GetComponent<Collider2D>().enabled = true; //bật lại collision


    }

}
