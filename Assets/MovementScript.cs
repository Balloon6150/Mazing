using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public int xspeed = 0;
    public int yspeed = 0;
    public int movementSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        // Get speed to decrease every second rather than every frame
        if (xspeed > 0) {
            xspeed -= 1;
        }
        if (yspeed > 0) {
            yspeed -= 1;
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
    }
}
