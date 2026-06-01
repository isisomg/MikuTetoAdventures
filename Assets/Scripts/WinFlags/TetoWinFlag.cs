using UnityEngine;

public class TetoWinFlag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Try to get TetoVariables from the object that touched the flag
        TetoVariables teto = collision.GetComponent<TetoVariables>();

        // Only proceed if the object is actually Teto
        if (teto != null)
        {
            teto.winCondition = true;
            if (teto.winCondition)
            {
                Debug.Log("Teto has reached her win flag!");
            }
        }
    }
}