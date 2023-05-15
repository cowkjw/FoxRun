using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{
    enum ButtonType
    {
        Start,
        Tutorial,
        GameGoal,
        Back,
    }

    public Button[] _buttons;
    public Text[] _texts;

    private void Start()
    {
        PlayerPrefs.DeleteAll(); 
    }

    void SetFalseButton()
    {
        foreach(Button bt in _buttons)
        {
            bt.gameObject.SetActive(false);
        }

        _buttons[(int)ButtonType.Back].gameObject.SetActive(true);
    }
    void SetTrueButton()
    {
        for(int i = 0;i<3;i++)
        {
            _buttons[i].gameObject.SetActive(true);
        }
        _buttons[(int)ButtonType.Back].gameObject.SetActive(false);
    }

    void SetFalseText()
    {
        for(int i = 0;i<2;i++)
        {
            _texts[i].gameObject.SetActive(false);
        }
    }

    public void StartButton()
    {
        SceneManager.LoadScene(1);// main ¾À
    }

    public void TutorialButton()
    {
        GameObject.FindObjectOfType<TutorialPlayer>().toutorial = true;
        SetFalseButton();
        _texts[0].gameObject.SetActive(true);
    }

    public void GameGoalButton()
    {
        SetFalseButton();
        _texts[1].gameObject.SetActive(true);
    }
    public void BackButton()
    {
        GameObject.FindObjectOfType<TutorialPlayer>().toutorial = false;
        SetFalseText();
        SetTrueButton();
    }
}
