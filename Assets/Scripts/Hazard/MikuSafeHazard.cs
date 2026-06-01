using UnityEngine;

public class MikuSafeHazard : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Try to get TetoVariables from the object that touched the hazard
        TetoVariables teto = collision.GetComponent<TetoVariables>();

        // Only proceed if the object is actually Teto
        if (teto != null)
        {
            if (teto != null)
            {
                teto.isAlive = false;
            }
        }
    }
}
