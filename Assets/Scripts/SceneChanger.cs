using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        Debug.Log("Load scene - " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
    
    public void Exit()
    {
        Debug.Log("EXIT");
        EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
