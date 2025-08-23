using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private Text scoreText; // UI Text to display the score
    [SerializeField] private GameObject gameOverUI;
    private bool isGameOver = false;
    [SerializeField] private GameObject gameWinUI;
    private bool isGameWin = false;

    void Start()
    {
        gameOverUI.SetActive(false); // Hide game over UI at the start
        UpdateScore();
        gameOverUI.SetActive(false); // Hide game over UI at the start
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddScore(int points)
    {
        if (!isGameOver && !isGameWin) // Only add score if the game is not over or won
        {
            score += points;
            Debug.Log("Score: " + score);
            UpdateScore();
        }

    }

    private void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        isGameOver = true;
        score = 0; // Reset score on game over
        Time.timeScale = 0; // Pause the game
        gameOverUI.SetActive(true); // Show game over UI
        Debug.Log("Game Over! Final Score: " + score);
    }

    public void RestartGame()
    {
        isGameOver = false;
        score = 0; // Reset score on restart
        UpdateScore();
        Time.timeScale = 1; // Resume the game
        gameOverUI.SetActive(false); // Hide game over UI
        SceneManager.LoadScene("Game");
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1; // Resume the game
    }

    public void GameWin()
    {
        isGameWin = true;
        Time.timeScale = 0; // Pause the game
        gameWinUI.SetActive(true); // Show game win UI
        Debug.Log("You Win! Final Score: " + score);
    }

    public bool IsGameWin()
    {
        return isGameWin;
    }
}
