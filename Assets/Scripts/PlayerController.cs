using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tommy Tran
//6/06/2022
//Version 2019.4.29
public class PlayerController : MonoBehaviour
{
    private GameObject focalPoint;
    public GameObject powerupIndicator;
    public GameObject PowerUpJump;
    private float powerupPushStrength = 15.0f;
    public float speed = 1.0f;
    public bool hasPowerupPush;
    public bool hasPowerupJump;
    public Rigidbody playerRb;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;

    //Activates the Push powerup
    IEnumerator PowerupCountdownPushRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerupPush = false;
        powerupIndicator.gameObject.SetActive(false);
    }
    //Activates the Jump powerup
    IEnumerator PowerupCountdownJumpRoutine()
    {
        yield return new WaitForSeconds(16);
        hasPowerupJump = false;
        PowerUpJump.gameObject.SetActive(false);
    }

    //checks for collision and triggers each powerup coroutines
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerupPush"))
        {
            hasPowerupPush = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownPushRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }

        if (other.CompareTag("PowerupJump"))
        {
            hasPowerupJump = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownJumpRoutine());
            PowerUpJump.gameObject.SetActive(true);

        }
    }

    // the Force of the Push powerup
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerupPush)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            Debug.Log("Collided With" + collision.gameObject.name + "with powerup set to" + hasPowerupPush);
            enemyRigidBody.AddForce(awayFromPlayer * powerupPushStrength, ForceMode.Impulse);
        }
    }

    //checks if the Player is on ground
    void OnCollisionStay()
    {
        isGrounded = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //moves the player
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(new Vector3(Input.GetAxis("Vertical") * speed, 0, -horizontalInput * speed), ForceMode.Impulse);
        //checks for variables and allows the player to jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && hasPowerupJump)
        {

            playerRb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
