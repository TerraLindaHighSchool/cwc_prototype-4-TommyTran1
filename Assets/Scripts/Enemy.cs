using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tommy Tran
//6/06/2022
//Version 2019.4.29
public class Enemy : MonoBehaviour
{
    Rigidbody enemyRb;
    public int jumpForce = 2;
    GameObject player;
    public float speed;
    public bool jump;
    public bool jumped;
    public float jumpCooldown = 2.0f;
    private float nextJump = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        //assigns the Rb and player object for variables
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Destroys the enemy if it falls of the map
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }

        //Adds rigid Ai that follows player in a line
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);

        //Special code for jumping variant of enemy
        if(jump == true)
        {
            if (jumped == true)
            {
                Jump();
            }
        }


    }
    public void Jump()
    {
        float compareTime = Time.time + jumpCooldown;

        if (compareTime > Time.time)
        {
        }
        {
            enemyRb.AddForce(Vector3.up * jumpForce);
            Debug.Log("AMONG");
        }
    }
}
