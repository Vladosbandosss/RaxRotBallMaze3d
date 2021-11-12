using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;

    public float speed;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var gravity = new Vector3(Input.acceleration.x,Input.acceleration.z,Input.acceleration.y)*9.8f;

        rb.AddForce(gravity * rb.mass, ForceMode.Acceleration);

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);

        rb.AddForce(movement * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            Debug.Log("проиграл");
        }

        if (collision.gameObject.tag == "Target")
        {
            Debug.Log("выйграл");
        }
    }
}
