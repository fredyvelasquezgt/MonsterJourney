using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI; // Referencia al Canvas que contiene el menú de Game Over

    // Método para reanudar el juego
    public void ResumeGame()
    {
        // Reanudar el tiempo del juego
        Time.timeScale = 50f;

        // Desactivar el menú de Game Over
        gameOverUI.SetActive(false);
    }

     public void gameOver()
    {

        // Desactivar el menú de Game Over
        gameOverUI.SetActive(true);
    }
     public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

