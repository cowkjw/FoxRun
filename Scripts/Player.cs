using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public enum FoxState
    {
        Attack,
        Jump,
        Idle,
        Die,
        Run,
        Left,
        Right,
        Back
    }


    public bool isGameOver = false;
    GameObject enemy = null;
    public Vector3[] _spawnPos;
    public int _spawnIdx = 0;
    public Material _material;
    [SerializeField]
    FoxState _state = FoxState.Idle;
    float _speed = 8f;
    bool isJump = false;
    AudioSource audioSource;
    Heart heart;

    public bool isOpenDoor = false;
    public bool isCheck4 = false;
    public bool isAttack = false;
    bool isDead = false;
    bool isHurt = false;
    public AudioClip audioJumpClip;
    public AudioClip audioDeathClip;
    public AudioClip audioInjuredClip;

    public int _countEnemy = 0;

    public FoxState State
    {
        get { return _state; }

        set
        {
            _state = value;
            Animator anim = GetComponent<Animator>();
            switch (_state)
            {
                case FoxState.Idle:
                    anim.CrossFade("Idle", 0.1f);
                    break;
                case FoxState.Jump:
                    anim.CrossFade("Jump", 0.1f);
                    break;
                case FoxState.Left:
                    anim.CrossFade("Left", 0.1f);
                    break;
                case FoxState.Right:
                    anim.CrossFade("Right", 0.1f);
                    break;
                case FoxState.Back:
                    anim.CrossFade("Back", 0.1f);
                    break;
                case FoxState.Attack:
                    anim.CrossFade("Attack", 0.1f);
                    break;
                case FoxState.Die:
                    anim.CrossFade("Die", 0.1f);
                    break;
                case FoxState.Run:
                    anim.CrossFade("Run", 0.1f);
                    break;

            }

        }
    }
    void Init()
    {
        transform.position = _spawnPos[_spawnIdx];
        heart = GameObject.FindObjectOfType<Heart>();
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        Init();
    }

    void Update()
    {

        switch (State)
        {
            case FoxState.Idle:
                MovingOrJumping();
                break;
            case FoxState.Run:
                MovingOrJumping();
                break;
            case FoxState.Back:
                MovingOrJumping();
                break;
            case FoxState.Left:
                MovingOrJumping();
                break;
            case FoxState.Right:
                MovingOrJumping();
                break;
            case FoxState.Jump:
                MovingOrJumping();
                break;
            case FoxState.Attack:
                MovingOrJumping();
                break;
        }
    }

    void MovingOrJumping()
    {


        float trans = Input.GetAxisRaw("Vertical") * _speed * Time.deltaTime;
        float rot = Input.GetAxisRaw("Horizontal") * 350 * Time.deltaTime;


        if (State == FoxState.Attack)
        {
            Attacking();
            return;
        }

        if (!isJump)
        {

            if (Input.GetAxisRaw("Vertical") == -1 && State != FoxState.Back)
            {
                State = FoxState.Back;
            }
            else if (Input.GetAxisRaw("Vertical") == 1 && State != FoxState.Run && Input.GetAxisRaw("Horizontal") == 0)
            {
                State = FoxState.Run;
            }
            else if (Input.GetAxisRaw("Horizontal") == -1 && State != FoxState.Left)
            {
                State = FoxState.Left;
            }
            else if (Input.GetAxisRaw("Horizontal") == 1 && State != FoxState.Right)
            {
                State = FoxState.Right;
            }
            else if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0 && State != FoxState.Idle)
            {
                State = FoxState.Idle;
            }


            if (Input.GetKeyDown(KeyCode.Space) && !isJump)
            {
                isJump = true;
                State = FoxState.Jump;
                audioSource.clip = audioJumpClip;
                audioSource.Play();
                GetComponent<Rigidbody>().AddForce(Vector3.up * 300f);
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                isAttack = true;
                   State = FoxState.Attack;
            }
        }


        transform.Translate(0, 0, trans);
        Vector3 dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        if (dir.sqrMagnitude > 0.01f)
            transform.Rotate(0, rot, 0);


    }
    void Attacking()
    {
        if (Input.anyKey && !Input.GetKey(KeyCode.Z))
        {
            isAttack = false;
            State = FoxState.Idle;
        }
    }

    public void HitEvent()
    {
        if (enemy != null)
        {
            Debug.Log("Hit");
            enemy.GetComponent<Enemy>()._hp--;
        
        }
        else
            return;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("MoveObs"))
        {
            if (collision.transform.position.y < transform.position.y)
            {
                isJump = false;
            }
            else if (collision.gameObject.CompareTag("MoveObs"))
            {
                isJump = false;
            }
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {

            OnDamaged();

        }

        else if (collision.gameObject.CompareTag("DeadZone"))
        {
            State = FoxState.Die;
            isDead = true;
            audioSource.clip = audioDeathClip;
            audioSource.Play();
            Invoke("SetSpawnPos", 1f);
        }
        else if (collision.gameObject.CompareTag("OpenKey"))
        {
            if (isOpenDoor)
            {

                
                Destroy(collision.gameObject);
            }
        }
        else if(collision.gameObject.CompareTag("GoldKey"))
        {
            GameObject.FindObjectOfType<MainUI>().KeyImage.gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.CompareTag("Monster")||collision.gameObject.CompareTag("Key"))
        {
            enemy = collision.gameObject;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("MoveObs"))
        {
            transform.SetParent(collision.transform);
        }
        else if(collision.gameObject.CompareTag("Key")||collision.gameObject.CompareTag("Monster"))
        {
            enemy = collision.gameObject;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("MoveObs"))
        {
            transform.SetParent(null);
        }

        enemy = null; 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))//∑π¿Ã¿˙
        {
            if (!isHurt)
            {
                isHurt = true;
                this.GetComponent<Rigidbody>().AddForce(Vector3.right * 300f);
                OnDamaged();

            }
        }
        else if (other.gameObject.CompareTag("CheckPoint"))
        {
            if (other.gameObject.name == "CheckPoint4")
            {
                isCheck4 = true;
            }
            else
            {

                _spawnIdx++;
            }
            other.gameObject.tag = "Untagged";
        }
    }

    public void OnDamaged()
    {

        if (!isDead)
        {
            audioSource.clip = audioInjuredClip;
            audioSource.Play();
        }
        heart.Hurting();
        _material.color = new Color(0, _material.color.g, _material.color.b);

        if (heart.countHeart <= 0)
        {
            State = FoxState.Die;

        }
        Invoke("OffDamaged", 1f);
    }

    void OffDamaged()
    {
        _material.color = new Color(1, 1, 1);
        if (heart.countHeart <= 0)
        {
            isDead = true;
            audioSource.clip = audioDeathClip;
            audioSource.Play();
            Invoke("SetSpawnPos", 1f);
        }
        isHurt = false;
    }

    void SetSpawnPos()
    {

        isDead = false;
        heart.countHeart = 3;
        heart.ResetHeart();
        transform.position = _spawnPos[_spawnIdx];
        transform.rotation = Quaternion.Euler(0, -90, 0);
        State = FoxState.Idle;
    }
}

