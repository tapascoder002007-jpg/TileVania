
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] Image[] hearts;
    int score = 0;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    void Awake()
    {
        //create our singleton
        int numberGameSessions = FindObjectsByType<GameSession>().Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        UpdateLive();
        scoreText.text = score.ToString();
    }
    public void ProcessPlayerDeath()
    {
        if(playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }
    void ResetGameSession()
    {
        FindAnyObjectByType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
    public void AddToScore(int scoreValue)
    {
        score = score+scoreValue;
        scoreText.text = score.ToString();
    }
    void TakeLife()
    {
        playerLives --;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        UpdateLive();
    }
    void UpdateLive()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            hearts[i].gameObject.SetActive(i<playerLives);
        }
    }
    //When player. dies do certain things
    //reduce number of lives
    //if we have no lives left hen restart the whole game
    

}
