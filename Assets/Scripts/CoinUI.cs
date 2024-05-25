using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    public Text coinText;
    private int totalCoins;
    private int collectedCoins;
    private int coinsToAdvance;

    private void Start()
    {
        if (CoinManager.instance != null)
        {
            CoinManager.instance.OnCoinCollected += UpdateCoinUI;
            totalCoins = CoinManager.instance.GetTotalCoins();
            coinsToAdvance = CoinManager.instance.coinsToAdvance;
            UpdateCoinUI(0);
            Debug.Log("CoinUI started. Total coins: " + totalCoins);
        }
        else
        {
            Debug.LogError("CoinManager.instance is null. Ensure CoinManager is initialized before accessing it.");
        }
    }

    private void OnDestroy()
    {
        if (CoinManager.instance != null)
        {
            CoinManager.instance.OnCoinCollected -= UpdateCoinUI;
        }
    }

    private void UpdateCoinUI(int collected)
    {
        collectedCoins = collected;
        coinText.text = "Monedas: " + collectedCoins + "/" + coinsToAdvance;
        Debug.Log("Updated CoinUI: " + collectedCoins + "/" + coinsToAdvance);
    }
}
