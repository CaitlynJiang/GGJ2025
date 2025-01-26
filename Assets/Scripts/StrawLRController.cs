using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrawLRCOntroller : MonoBehaviour
{
    public float x_speed = 5.0f;
    public float amplitude = 1.0f;  // Amplitude (the distance of the motion)
    //public float downDistance = 1.0f;
    //public float downSpeed = 2.0f;
    public Vector2 startPosition;

    private bool stopXMovement = false;  // Flag to stop X movement
    //private bool isMovingDown = false; // Flag Flag for vertical movement
    private float frozenXPosition;       // Store the X position when 'Space' is pressed
    //private float currentYPosition;      // Track the current Y position

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        frozenXPosition = startPosition.x;  // Initialize frozenXPosition to the starting X position
        //currentYPosition = startPosition.y; // Initialize the current Y position
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stopXMovement = true;
            frozenXPosition = transform.position.x;  // Store the current X position
            //isMovingDown = true;
        }

        // Calculate the X position, or freeze it if X movement is stopped
        float x = stopXMovement ? frozenXPosition : (amplitude * Mathf.Cos(Time.time * x_speed) * -1 + startPosition.x);
        /*
        if(isMovingDown)
        {
            currentYPosition = Mathf.Lerp(currentYPosition, startPosition.y - downDistance, downSpeed * Time.deltaTime);
            if (Mathf.Abs(currentYPosition - (startPosition.y - downDistance)) < 0.01f)
            {
                currentYPosition = startPosition.y - downSpeed;  // Ensure it's exactly at the final position
                isMovingDown = false; // Stop the downward movement once it's done
            }
        }
        */
        transform.position = new Vector3(x, startPosition.y);
    }

}

