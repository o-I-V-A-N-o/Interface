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
        Health -= life;
        if (Health <= 0)
        {
            EndGame();
        }
    }

    public void Pause()
    {
        if (GameIsPaused)
        {
            _pauseMenuUI.GetComponent<Animator>().SetTrigger("Close");
            Time.timeScale = 1f;
            GameIsPaused = false;
        }
        else
        {
            Time.timeScale = 0f;
            _pauseMenuUI.GetComponent<Animator>().SetTrigger("Open");
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

    private void EndGame()
    {
        Debug.Log("Конец игры!");
        EditorApplication.isPaused = true;
    }
}
