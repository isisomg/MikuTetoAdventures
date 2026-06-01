using UnityEngine;

public class TetoSafeHazard : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Try to get TetoVariables from the object that touched the hazard
        MikuVariables miku = collision.GetComponent<MikuVariables>();

        // Only proceed if the object is actually Miku
        if (miku != null)
        {
            if (miku != null)
            {
                miku.isAlive = false;
            }
        }
    }
}
