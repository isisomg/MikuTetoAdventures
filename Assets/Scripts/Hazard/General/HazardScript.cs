using UnityEngine;

public class HazardScript : MonoBehaviour
{
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
