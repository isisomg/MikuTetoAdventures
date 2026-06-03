using UnityEngine;
using UnityEngine.UI;

public class MovingPlatform : MonoBehaviour
{

    public Transform pointA;
    public Transform pointB;

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
        
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);

        if (transform.position == nextPos)
        {
            nextPos = (nextPos == pointA.position) ? pointB.position : pointA.position;
        }

    }

    // if the player is on the platform, they become a child of the elevator so they move with it
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    // If the player leaves the platform, they are no longer a child of the platform so they stop moving with it
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
