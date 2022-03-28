using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private InputField nameField;
    [SerializeField] private Text highScoreText;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        if (DataManager.instance != null)
        {
            nameField.text = DataManager.instance.userName;
            highScoreText.text = "Highscore - " + DataManager.instance.highScoreUserName + ": " + DataManager.instance.highScore;
        }
    }

    public void StartNew()
    {
        if (string.IsNullOrEmpty(nameField.text))
        {
            DataManager.instance.userName = "NoName";
        }
        else
        {
            DataManager.instance.userName = nameField.text;
        }
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
