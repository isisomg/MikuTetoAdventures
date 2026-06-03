using UnityEngine;
using UnityEngine.UI;

public class MovingElevator : MonoBehaviour
{

    public Transform pointA;
    public Transform pointB;
    
    public PressureButton button;

    public float speed = 2f;

    public Vector3 startPos;
    private Vector3 nextPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextPos = pointB.position;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // if the button is pressed the elevator moves betwen the two points
        if(button.isPressed)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);

            if (transform.position == nextPos)
            {
                nextPos = (nextPos == pointA.position) ? pointB.position : pointA.position;
            }
        }
        
        else if (!button.isPressed)
        {
            // if the elevator isn't pressed, it starts moving back to its original position
            if (transform.position != startPos)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
            }
            // if the elevator is back at its original position, it stops moving
            if (transform.position == startPos)
            {
                return;
            }
        }
    }

    // if the player is on the elevator, they become a child of the elevator so they move with it
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    // If the player leaves the elevator, they are no longer a child of the elevator so they stop moving with it
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
