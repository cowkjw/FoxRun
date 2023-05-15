using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{


    public Material mat;
    void Start()
    {
        StartCoroutine(Changing());
    }

    
    IEnumerator Changing()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
            float randR = Random.Range(0, 1.1f);
            float randG = Random.Range(0, 1.1f);
            float randB = Random.Range(0, 1.1f);
            float randA = Random.Range(0,1.1f);
            mat.color = new Color(randR, randG, randB, randA);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            MainUI ui = GameObject.FindObjectOfType<MainUI>();
            ui.score += (Mathf.FloorToInt(ui.time))*10;
            Invoke("ChangeSceneToClear", 1f);  
        }
    }
    void ChangeSceneToClear()
    {

            Destroy(gameObject);
            SceneManager.LoadScene(2);
    }
}
