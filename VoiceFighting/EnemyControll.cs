using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControll : MonoBehaviour
{

    public enum CurrentState { idle, trace, kick, punch, dead };
    public CurrentState curState = CurrentState.trace;
  

    private Transform _transform;
    private Transform playerTransform;
    private NavMeshAgent nvAgent;
    private Animator _animator;
    private Vector3 direction;

    public float traceDist = 15.0f;
    public float kickDist = 2.0f;
    public float punchDist = 1.0f;
    private bool isDead = false;

    void Start()
    {

        _transform = this.gameObject.GetComponent<Transform>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
        _animator = this.gameObject.GetComponent<Animator>();

        direction = playerTransform.position - this.transform.position;
        direction.y = 0;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.3f);

        StartCoroutine(this.CheckState());
        StartCoroutine(this.CheckStateForAction());


    }

    IEnumerator CheckState()
    {
        while(!isDead)
        {
            yield return new WaitForSeconds(0.2f);

            float dist = Vector3.Distance(playerTransform.position, _transform.position);

            if (dist <= punchDist)
            {
                curState = CurrentState.punch;

            }
            else if (dist <= kickDist)
            {
                curState = CurrentState.kick;
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
                case CurrentState.kick:
                    int a= Random.Range(0, 2);

                    switch(a)
                    {
                        case 0:
                            _animator.SetBool("Isleftkick", true);
                            yield return new WaitForSeconds(2.5f);
                            _animator.SetBool("Isleftkick", false);
                            break;
                        case 1:
                            _animator.SetBool("Isrightkick", true);

                            yield return new WaitForSeconds(2.5f);

                            _animator.SetBool("Isrightkick", false);

                            break;
                        
                    }
                    break;
                case CurrentState.punch:
                    int b = Random.Range(0, 2);

                    switch (b)
                    {
                        case 0:
                            _animator.SetBool("Islefthook", true);
                            yield return new WaitForSeconds(2.5f);
                            _animator.SetBool("Islefthook", false);
                            break;
                        case 1:
                            _animator.SetBool("Isrightpunch", true);

                            yield return new WaitForSeconds(2.5f);

                            _animator.SetBool("Isrightpunch", false);

                            break;

                    }
                    break;

            }
            

            yield return null;
        }
    }

    void Update()
    {
       
    }
}
