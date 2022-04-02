using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControll : MonoBehaviour
{

    public enum CurrentState {idle,trace,attack,dead};
    public CurrentState curState = CurrentState.idle;

    private Transform _transform;
    private Transform playerTransform;
    private NavMeshAgent nvAgent;
    private Animator _animator;

    public float traceDist = 30.0f;
    public float attackDist = 3.0f;


    
    void Start()
    {
        _transform = this.gameObject.GetComponent<Transform>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
        _animator = thils.gameObject.GetComponent<Animator>();
        nvAgent.destination = playerTransform.position;
        _animator.Setbool("istrace",true);

        StartCoroutine(this.CheckState());
        StartCoroutine(this.CheckStateForAction());
    }
/*
    IEnumerator CheckState()
    {
        float dist = Vector3.Distance(playerTransform.position, _transform.position);

        if (dist <= attackDist)
        {
            curState = CurrentState.attack;
        }
    }

    IEnumerator CheckStateForAction()
    {
        switch (curState)
        {
            
            case CurrentState.trace:
                nvAgent.destination = playerTransform.position;
                nvAgent.Resume();
                _animator.Setbool("istrace",true);
                break;
            case CurrentState.attack:
                break;
        }
    }
*/
   
    void Update()
    {
        direction = playerTransform - this.transform.position;
        direction.y = 0;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction),0.3f);
    }
}
