using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearUI : MonoBehaviour
{

    enum ButtonType
    {
        Start,
        Score,
        Back,
    }

    public Button[] _buttons;
    public Text[] _texts;
    int highScore;

    private void Start()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            if (PlayerPrefs.HasKey("BestScore"))
                highScore = PlayerPrefs.GetInt("BestScore");
        }
        else
            highScore = 0;
    }

    void SetFalseButton()
    {
        foreach (Button bt in _buttons)
        {
            bt.gameObject.SetActive(false);
        }

        _buttons[(int)ButtonType.Back].gameObject.SetActive(true);
    }
    void SetTrueButton()
    {
        for (int i = 0; i < 2; i++)
        {
            _buttons[i].gameObject.SetActive(true);
        }
        _buttons[(int)ButtonType.Back].gameObject.SetActive(false);
    }

    public void StartButton()
    {
        SceneManager.LoadScene(1);// main ¾À
    }

    void SetFalseText()
    {
        _texts[0].gameObject.SetActive(false);
    }

    public void BestScoreButton()
    {
        SetFalseButton();
        _texts[0].text = "BestScore:\n" + highScore.ToString();
        _texts[0].gameObject.SetActive(true);
    }


    public void BackButton()
    {
        SetFalseText();
        SetTrueButton();
    }
}
