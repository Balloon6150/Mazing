using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float xspeed = 0f;
    public float yspeed = 0f;
    public float movementSpeed = 4.0f;
    public float deceleration = 0.005f;


    public float maxSpeed = 10.0f;
    public float minSpeed = -10.0f;

    public float bottomYWallCordinates = -6.5f;
    public float topYWallCordinates = 6.5f;
    public float leftXWallCordinates = -12.5f;
    public float rightXWallCordinates = 12.5f;


    // Start is called before the first frame update
    void Start()
    {
        print("Movement Script Initialized");
    }


    // Update is called once per frame
    void Update()
    {
        //TODO Optimise code
        //TODO Remove test variable
        //TODO Make it get collison from colliders instead of cordinates


        // Controls with WASD
        if (Input.GetKey(KeyCode.W))
        {
            yspeed += movementSpeed*Time.deltaTime;
            print("yspeed is increasing positively");
        }
        if (Input.GetKey(KeyCode.S))
        {
            yspeed -= movementSpeed*Time.deltaTime;
            print("yspeed is decreasing negatively");
        }
        if (Input.GetKey(KeyCode.A))
        {
            xspeed -= movementSpeed*Time.deltaTime;
            print("xspeed is decreasing negatively");
        }
        if (Input.GetKey(KeyCode.D))
        {
            xspeed += movementSpeed*Time.deltaTime;
            print("xspeed is increasing positively");
        }

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

         // Deceleration
        if (xspeed >= 0.05f) {
            xspeed -= deceleration;
            print("XSpeed is decreasing negatively");
        }
        if (xspeed <= -0.05f)
            {
                xspeed += deceleration;
                print("XSpeed is decreasing positively");
            }
        if (yspeed >= 0.05f) {
            yspeed -= deceleration;
            print("YSpeed is decreasing negatively");
        }
        if (yspeed <= -0.05f)
            {
                yspeed += deceleration;
                print("YSpeed is decreasing positively");
            }
       
        
        // Object movement

        transform.Translate(new Vector3(xspeed * Time.deltaTime, yspeed * Time.deltaTime, 0));

        // Wall collision
        if (transform.position.y < bottomYWallCordinates) {
            transform.position = new Vector3(transform.position.x, bottomYWallCordinates, transform.position.z);
            yspeed = 0f;
        }
        if (transform.position.y > topYWallCordinates) {
            transform.position = new Vector3(transform.position.x, topYWallCordinates, transform.position.z);
            yspeed = 0f;
        }
        if (transform.position.x < leftXWallCordinates) {
            transform.position = new Vector3(leftXWallCordinates, transform.position.y, transform.position.z);
            xspeed = 0f;
        }
        if (transform.position.x > rightXWallCordinates) {
            transform.position = new Vector3(rightXWallCordinates, transform.position.y, transform.position.z);
            xspeed = 0f;
        }
    }
}