using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    private int totalCoins;
    private int collectedCoins;
    public int coinsToAdvance = 3;  // Número de monedas necesarias para avanzar

    public delegate void CoinCollected(int collected);
    public event CoinCollected OnCoinCollected;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ResetCoins();
        CountCoinsInScene();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ResetCoins();
        CountCoinsInScene();
    }

    private void ResetCoins()
    {
        collectedCoins = 0;
    }

    private void CountCoinsInScene()
    {
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        OnCoinCollected?.Invoke(collectedCoins);
    }

    public int GetTotalCoins()
    {
        return totalCoins;
    }

    public void CollectCoin()
    {
        collectedCoins++;
        OnCoinCollected?.Invoke(collectedCoins);

        if (collectedCoins >= coinsToAdvance)
        {
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("You have completed all levels!");
        }
    }
}
