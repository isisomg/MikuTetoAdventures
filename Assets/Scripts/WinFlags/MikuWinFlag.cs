using UnityEngine;

public class MikuWinFlag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Try to get MikuVariables from the object that touched the flag
        MikuVariables miku = collision.GetComponent<MikuVariables>();

        // Only proceed if the object is actually Miku
        if (miku != null)
        {
            miku.winCondition = true;
            if (miku.winCondition)
            {
                Debug.Log("Miku has reached her win flag!");
            }
        }
    }
}