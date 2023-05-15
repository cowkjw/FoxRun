using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayer : MonoBehaviour
{


    enum FoxState
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

    [SerializeField]
    FoxState _state = FoxState.Idle;
    //bool isJump = false;
    public bool toutorial = false;
    FoxState State
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


    void Update()
    {
        if (toutorial)
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
        else
        {
            State = FoxState.Idle;
        }
    }

    void MovingOrJumping()
    {



        if (State == FoxState.Attack)
        {
            Attacking();
            return;
        }


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

        else if (Input.GetKeyDown(KeyCode.Space))
        {
            // isJump = true;
            State = FoxState.Jump;

        }

        if (Input.GetKeyDown(KeyCode.Z))
        {

            State = FoxState.Attack;
        }


    }
    void Attacking()
    {
        if (Input.anyKey && !Input.GetKey(KeyCode.Z))
        {
            State = FoxState.Idle;
        }
    }
}
