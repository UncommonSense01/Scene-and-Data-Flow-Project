using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance;

    public int CurrentScore;
    public string PlayerName;

    public int HighScore;
    public string HighScorePlayer;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }
    public void ResetCurrentScore()
    {
        CurrentScore = 0;
    }

    [System.Serializable]
    class HighScoreData
    {
        public string playerName;
        public int score;
    }

    public void SaveHighScore()
    {
        HighScoreData data = new HighScoreData
        {
            playerName = HighScorePlayer,
            score = HighScore
        };
        

        string json = JsonUtility.ToJson(data);

        System.IO.File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/highscore.json";
        if (System.IO.File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            HighScoreData data = JsonUtility.FromJson<HighScoreData>(json);

            HighScorePlayer = data.playerName;
            HighScore = data.score;
            
        }
    }


}
