using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tommy Tran
//6/06/2022
//Version 2019.4.29
public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
