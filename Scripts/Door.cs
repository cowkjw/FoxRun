using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
           if( collision.gameObject.GetComponent<Player>().isOpenDoor)
            {
                GameObject.FindObjectOfType<MainUI>().KeyImage.gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
