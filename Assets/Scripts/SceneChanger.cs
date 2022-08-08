using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        Debug.Log("Load - " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
    
    public void Exit()
    {
        Debug.Log("EXIT");
        EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
