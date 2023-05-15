using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public float time = 180f;
    public Text timer;
    public Text CheckPoint;
    public Text Score;
    public Text MonsterCheck;
    public Image KeyImage;

    public int score = 0;
    int highScore;
    Player _player;
    void Start()
    {
      
        if (PlayerPrefs.HasKey("BestScore"))
        {
            if (PlayerPrefs.HasKey("BestScore"))
                highScore = PlayerPrefs.GetInt("BestScore");
        }
        else
            highScore = 0;
            _player = GameObject.FindObjectOfType<Player>();
    }


    void Update()
    {
        if (Mathf.FloorToInt(time) <= 0)
        {
            _player.isGameOver = true;
            SceneManager.LoadScene(3);//½ÇÆÐ
        }
        if (!_player.isGameOver)
        {
            time -= Time.deltaTime;
            int t = Mathf.FloorToInt(time);
            timer.text = "Time: " + t.ToString();
            Score.text = "Score: " + score.ToString();
            if(highScore<score)
            {
                PlayerPrefs.SetInt("BestScore", score);
            }
            
            CheckPoint.text = "CheckPoint\n" + _player._spawnIdx.ToString() + "/" + 2.ToString();
        }
        if (_player._spawnIdx >= 2)
        {
            CheckPoint.color = new Color(1, 0, 0);
        }
        if(_player.isCheck4)
        {
            if(!MonsterCheck.gameObject.activeSelf)
            {
                MonsterCheck.gameObject.SetActive(true);
            }
            
            MonsterCheck.text = "Monster\n" + _player._countEnemy.ToString() + "/" + 3.ToString();

            if (_player._countEnemy >=3)
            {
                MonsterCheck.color = new Color(1, 0, 0);
            }
        }
    }
}
