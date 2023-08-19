using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    private void Awake()
    {
        Instance = this;
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
    
    public void ExitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
