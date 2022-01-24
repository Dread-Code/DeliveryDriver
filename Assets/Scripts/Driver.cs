 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 25f;
    [SerializeField] float slowSpeed = 20f;
    [SerializeField] float boostSpeed = 30f;

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float steerMoveSpeed = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, steerMoveSpeed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        moveSpeed = slowSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "SpeedUp") {
            moveSpeed = boostSpeed;
        }
    }

}
