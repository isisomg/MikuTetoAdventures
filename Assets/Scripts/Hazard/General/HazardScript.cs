using UnityEngine;

public class HazardScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Try to get TetoVariables from the object that touched the hazard
        TetoVariables teto = collision.GetComponent<TetoVariables>();
        MikuVariables miku = collision.GetComponent<MikuVariables>();

        // Only proceed if the object is actually Teto or Miku
        if (teto != null || miku != null)
        {
            if (teto != null)
            {
                teto.isAlive = false;
            }
            if (miku != null)
            {
                miku.isAlive = false;
            }
        }
    }
}
