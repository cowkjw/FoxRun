using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    NavMeshAgent nma;

    public GameObject key;
    public Transform targetPos;
    // Animator animator;
    float range = 10;
    public Animator animator;
    Vector3 point;
    [SerializeField]
    Vector3 randomPoint;
    [SerializeField]
    public int _hp = 3;
    bool isDead = false;
    void Start()
    {

        nma = gameObject.GetComponent<NavMeshAgent>();

        animator = gameObject.GetComponent<Animator>();


        StartCoroutine(Checking());
    }


    private void Update()
    {
        if(_hp<=0&&!isDead)
        {
            isDead = true;
            GameObject.FindObjectOfType<MainUI>().score += 100;
            GameObject.FindObjectOfType<Player>()._countEnemy += 1;
            if (transform.tag == "Key")
            {
                Instantiate(key, transform.position, Quaternion.identity);
                GameObject.FindObjectOfType<Player>().isOpenDoor = true;
            }
                animator.CrossFade("Die", 1f);
            Destroy(gameObject, 2f);
        }
    }


    IEnumerator Checking()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if ((transform.position - targetPos.position).magnitude <= 7f)
            {
                nma.SetDestination(targetPos.position);
                StopCoroutine(Moving());
            }

            else
            {
                StartCoroutine(Moving());
            }

        }
    }

    IEnumerator Moving()
    {
        while (true)
        {

            randomPoint = transform.position + Random.insideUnitSphere * range;
            yield return new WaitForSeconds(1f);
            nma.SetDestination(randomPoint);

        }
    }

}
