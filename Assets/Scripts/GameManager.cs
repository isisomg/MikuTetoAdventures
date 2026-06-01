using UnityEngine;

public class GameManager : MonoBehaviour
{

    public MikuVariables mikuVariables;
    public TetoVariables tetoVariables;

    private bool hasWon = false;
    private bool hasLost = false;
    void WinGame()
    {
        hasWon = true;

        Debug.Log("You Win!");

        Time.timeScale = 0f; // pauses the game
    }

    void LoseGame()
    {
        hasLost = true;

        Debug.Log("You Lose!");
    }

    // Update is called once per frame
    void Update()
    {
        if (hasWon || hasLost) return;

        if (mikuVariables.winCondition == true && tetoVariables.winCondition == true)
        {
            WinGame();
        }

        if (mikuVariables.isAlive == false || tetoVariables.isAlive == false)
        {
            LoseGame();
        }
    }


}
