using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance { get; private set; }
    public string userName;
    public string highScoreUserName;
    public int highScore;
    
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    private void Start()
    {
        LoadHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [System.Serializable]
    class User
    {
        public string userName;
        public int score;
    }

    public void SaveHighScore(int points)
    {
        User user = new User();
        user.userName = highScoreUserName = userName;
        user.score = highScore = points;

        string json = JsonUtility.ToJson(user);

        File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/highscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            User user = JsonUtility.FromJson<User>(json);
            highScoreUserName = user.userName;
            highScore = user.score;
        }
        else
        {
            highScoreUserName = "Unknown";
            highScore = 0;
        }
    }
}
