using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _pauseMenuUI;
    [SerializeField]
    private GameObject _optionsUI;

    public int Health = 5;
    public int Blocks = 0;
    public bool GameIsPaused = false;

    public void SetBlocks(int block)
    {
        Blocks += block;
        if (Blocks <= 0)
        {
            EndGame();
        }
    }

    public void ChangeHealth(int life)
    {
        if (Health > 0)
        {
            Health -= life;
        }
        else
        {
            EndGame();
        }
    }

    public void Pause()
    {
        if (GameIsPaused)
        {
            _pauseMenuUI.SetActive(false);
            Options();
            Time.timeScale = 1f;
            GameIsPaused = false;
        }
        else
        {
            _pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
    }

    public void Options()
    {
        if (_optionsUI.activeSelf)
        {
            _optionsUI.SetActive(false);
        }
    }

    public void EndGame()
    {
        Debug.Log("����� ����!");
        EditorApplication.isPaused = true;
    }
}
