using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypointforenemy : MonoBehaviour
{
    private SpriteRenderer sprite;

    [SerializeField] private GameObject[] waypoints;
    //khởi tạo vị trí hiện tại đang tiến đến

    private int currentWaypointIndex = 0;

    //tốc độ di chuyển của platform
    [SerializeField] private float speed = 2f;



    public void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    public void Update()
    {
        //distance trả về khoản cách giữa 2 điểm

        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f)
        {
            currentWaypointIndex++;
           
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        //movetoward di chuyển đối tượng đến đối tượng chỉ định
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);

        if (currentWaypointIndex % 2 == 0)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }

    }
}
