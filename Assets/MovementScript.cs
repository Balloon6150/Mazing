using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float xspeed = 0f;
    public float yspeed = 0f;
    public float movementSpeed = 1.0f;
    public float deceleration = 0.1f;


    public float maxSpeed = 10.0f;
    public float minSpeed = 0.0f;

    public float bottomYWallCordinates = -4.5f;
    public float topYWallCordinates = 4.5f;
    public float leftXWallCordinates = -7.5f;
    public float rightXWallCordinates = 7.5f;

    public float testVar = 5f;


    // Start is called before the first frame update
    void Start()
    {
        testVar = 5f;
    }


    // Update is called once per frame
    void Update()
    {
        if (xspeed > maxSpeed) {
            xspeed = maxSpeed;
        }
        if (xspeed < minSpeed) {
            xspeed = minSpeed;
        }
        if (yspeed > maxSpeed) {
            yspeed = maxSpeed;
        }
        if (yspeed < minSpeed) {
            yspeed = minSpeed;
        }
        // Get speed to decrease every second rather than every frame
        if (xspeed > 0) {
            xspeed -= deceleration * Time.deltaTime;
        }
        if (yspeed > 0) {
            yspeed -= deceleration * Time.deltaTime;
        }

        // Controls with WASD
        if (Input.GetKey(KeyCode.W))
        {
            yspeed += movementSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            yspeed -= movementSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            xspeed -= movementSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            xspeed += movementSpeed;
        }
        
        // Object movement

        transform.Translate(new Vector3(xspeed * Time.deltaTime, yspeed * Time.deltaTime, 0));

        // Wall collision
        if (transform.position.y < bottomYWallCordinates) {
            transform.position = new Vector3(transform.position.x, bottomYWallCordinates, transform.position.z);
            yspeed = 0;
        }
        if (transform.position.y > topYWallCordinates) {
            transform.position = new Vector3(transform.position.x, topYWallCordinates, transform.position.z);
            yspeed = 0;
        }
        if (transform.position.x < leftXWallCordinates) {
            transform.position = new Vector3(leftXWallCordinates, transform.position.y, transform.position.z);
            xspeed = 0;
        }
        if (transform.position.x > rightXWallCordinates) {
            transform.position = new Vector3(rightXWallCordinates, transform.position.y, transform.position.z);
            xspeed = 0;
        }
    }
}