using UnityEngine;

public class StrawLRControllerVertical : MonoBehaviour
{
    public float y_speed = 0.0f;
    public float amplitude = 20.0f;  
    public Vector2 startPosition;
    private bool stopYMovement = false;  
    private float frozenYPosition;       

    void Start()
    {
        startPosition = transform.position;
        frozenYPosition = startPosition.y;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stopYMovement = true;
            frozenYPosition = transform.position.y;
        }

      
        float y = stopYMovement ? frozenYPosition :
            (amplitude * Mathf.Sin(Time.time * y_speed) + startPosition.y);

        transform.position = new Vector3(startPosition.x, y, transform.position.z);
    }
}