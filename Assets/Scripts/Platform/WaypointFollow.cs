using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollow : MonoBehaviour
{
    private SpriteRenderer sprite;
    [SerializeField] private GameObject[] waypoints;
    //khởi tạo vị trí hiện tại đang tiến đến

    private int currentWaypointIndex = 0;

    //tốc độ di chuyển của platform
    [SerializeField] private float speed = 2f;


    //thoi gian dung khi cham waypoint
    [SerializeField] private float timedelay = 0f;
    [SerializeField] private int khongquaylamot = 1;// 1 la đối tượng ko cần quay đầu , n là đối tượng có quay


    public void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (khongquaylamot != 1)
        {
            if (currentWaypointIndex % 2 == 0)
            {
                sprite.flipX = false;
            }
            else
            {
                sprite.flipX = true;
            }
        }
        
        
        //distance trả về khoản cách giữa 2 điểm

        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f){
            currentWaypointIndex++;
            StartCoroutine(delay());

            if (currentWaypointIndex>= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        
        //movetoward di chuyển đối tượng đến đối tượng chỉ định
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }

   
        IEnumerator delay() //dung doi tuong  1 time thì bat dau di chuyen tiep
        {
            float temp = speed;
            speed = 0;
            yield return new WaitForSeconds(timedelay);
            speed = temp;
        }
    
}
