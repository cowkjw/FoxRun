using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public Image[] _hearts;
    //public dameHeart;
    public int idx = 0;

    public int countHeart = 3;

    public void Hurting()
    {
        countHeart--; //�÷��̾�� �ٽ� üũ�ؼ� 3���� �ٲ������
        _hearts[idx].gameObject.SetActive(false);
        if(idx<2)
        {
            idx++;
        }
      
    }

    public void ResetHeart()
    {
        if (countHeart == 3)
        {
            idx = 0;
            for (int i = 0; i < 3; i++)
            {
                _hearts[i].gameObject.SetActive(true);
            }
        }
    }

}
