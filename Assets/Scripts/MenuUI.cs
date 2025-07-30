using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    public Button start;
    public Button exit;
    public string playerName;

    // Start is called before the first frame update
    void Start()
    {
        start = GetComponent<Button>();
        exit = GetComponent<Button>();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);  
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
    EditorApplication.ExitPlaymode();
#else
Application.Quit();
#endif
    }

    public void ReadPlayerName(string i)
    {
        playerName = i;
    }
}
