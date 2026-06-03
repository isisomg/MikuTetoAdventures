using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    private AudioSource audioSource;

    [Header("Configurações")]
    [SerializeField] private string nomeDoMenu = "StartScene";
    void Awake()
    {
        // Padrão Singleton para manter o objeto vivo
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        // Avisa o Unity para chamar a função OnSceneLoaded sempre que uma cena mudar
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Essa função roda automaticamente toda vez que uma fase carrega
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == nomeDoMenu)
        {
            // Se o jogador foi para o Menu, a música do jogo para
            audioSource.Stop();
        }
        else
        {
            // Se entrou em qualquer outra cena (Level 1, 2, 3...)
            // Só dá Play se ela já não estiver tocando. Isso garante o som SEM CORTES!
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}