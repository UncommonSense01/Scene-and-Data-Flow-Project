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
    public TMP_InputField nameInput;

    // Start is called before the first frame update
    void Start()
    {
        
        start = GetComponent<Button>();
        exit = GetComponent<Button>();

        var gm = GameDataManager.Instance;
        highScore.text = $"High Score: {gm.HighScore} by {gm.HighScorePlayer}";
        
    }

    public void StartGame()
    {
        GameDataManager.Instance.PlayerName = nameInput.text;
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

    /*public void ReadPlayerName(string i)
    {
        PlayerName = i;
        GameDataManager.Instance.name = PlayerName;
        GameDataManager.Instance.SaveName();
    }*/
}
