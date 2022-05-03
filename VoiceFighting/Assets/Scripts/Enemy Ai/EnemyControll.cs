using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControll : MonoBehaviour
{

    public enum CurrentState { idle, trace, attack, dead };
    public CurrentState curState = CurrentState.trace;

    private Transform _transform;
    private Transform playerTransform;
    private NavMeshAgent nvAgent;
    private Animator _animator;

    public float traceDist = 15.0f;
    public float attackDist = 3.2f;
    private bool isDead = false;

    void Start()
    {


    }

    IEnumerator CheckState()
    {
        while(!isDead)
        {
            yield return new WaitForSeconds(0.2f);

            float dist = Vector3.Distance(playerTransform.position, _transform.position);

            if (dist <= attackDist)
            {
                curState = CurrentState.attack;

            }

            else if (dist <= traceDist)
            {
                curState = CurrentState.trace;
            }
            else
            {
                curState = CurrentState.idle;
            }
            
        }
    }
    
    IEnumerator CheckStateForAction()
    {
        while(!isDead)
        {
            switch(curState)
            {
                case CurrentState.idle:
                    nvAgent.Stop();
                    _animator.SetBool("IsTrace", false);
                    break;
                case CurrentState.trace:
                    nvAgent.destination = playerTransform.position;
                    nvAgent.Resume();
                    _animator.SetBool("IsTrace", true);
                    break;
                case CurrentState.attack:
                    _animator.SetBool("IsTrace", false);
                    _animator.SetBool("IsAttack", true);
                    break;
            }

            yield return null;
        }
    }

    void Update()
    {
        if (GameController.instance.gamePlaying)
        {
            _transform = this.gameObject.GetComponent<Transform>();
            playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
            nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
            _animator = this.gameObject.GetComponent<Animator>();

            StartCoroutine(this.CheckState());
            StartCoroutine(this.CheckStateForAction());
        }
    }
}

