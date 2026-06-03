using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public MikuVariables mikuVariables;
    public TetoVariables tetoVariables;

    public GameObject gameOverScreen;
    public TMP_Text deadChar;

    public GameObject winScreen;

    private AudioSource audioSource;

    public AudioClip firstClip;
    public AudioClip secondClip;

    private bool hasWon = false;
    private bool hasLost = false;
    void WinGame()
    {
        hasWon = true;

        Debug.Log("You Win!");

        winScreen.SetActive(true);

        audioSource = winScreen.GetComponent<AudioSource>();

        audioSource.PlayOneShot(firstClip);
        audioSource.PlayOneShot(secondClip);

        Time.timeScale = 0f; // pauses the game
    }

    void LoseGame()
    {
        gameOverScreen.SetActive(true);
        deadChar.text = mikuVariables.isAlive == false ? "Miku is dead!" : "Teto is dead!";
    }

    public void ResetLevel()
    {
        Debug.Log("Trying to reset level...");
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        gameOverScreen.SetActive(false);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("StartScene");
        gameOverScreen.SetActive(false);
    }

    public void GoToNextLevel()
    {
        winScreen.SetActive(false);
        Time.timeScale = 1f;

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("No more levels in Build Settings! Going to main menu instead.");
            GoToMainMenu();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hasWon || hasLost) return;

        if (mikuVariables.winCondition == true && tetoVariables.winCondition == true)
        {
            WinGame();
        }

        if (mikuVariables.isAlive == false | tetoVariables.isAlive == false)
        {
            LoseGame();
        }
    }

    private void Start()
    {
        winScreen.SetActive(false);
        gameOverScreen.SetActive(false);
    }

}
