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
    private float powerupPushStrength = 15.0f;
    public float speed = 1.0f;
    public bool hasPowerup;
    public Rigidbody playerRb;

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            Debug.Log("Collided With" + collision.gameObject.name + "with powerup set to" + hasPowerup);
            enemyRigidBody.AddForce(awayFromPlayer * powerupPushStrength, ForceMode.Impulse);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(new Vector3(Input.GetAxis("Vertical") * speed, 0, -horizontalInput * speed), ForceMode.Impulse);
    }
}
