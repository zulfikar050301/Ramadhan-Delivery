using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 1f; //ngatur kecepatan putar
    [SerializeField] float moveSpeed = 20f; //ngatur movement speed
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;
    void Start()
    {
        
    }

    
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime; //input mekanis untuk belok
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; //input mekanis untuk maju
        transform.Rotate(0, 0, -steerAmount); //untuk belok atau memutar pada sumbu z
        transform.Translate(0, moveAmount, 0); //untuk maju pada sumbu y
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowSpeed;
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Boost")
        {
            moveSpeed = boostSpeed;
        }
    }
}
