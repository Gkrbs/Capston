//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

//public class EnemyControll : MonoBehaviour
//{

//    public enum CurrentState { idle, trace, attack, dead };
//    public CurrentState curState = CurrentState.trace;


//    private Transform _transform;
//    private Transform playerTransform;
//    private NavMeshAgent nvAgent;
//    private Animator _animator;

//    public float traceDist = 15.0f;
//    public float attackDist = 2.5f;
//    private bool isDead = false;

//    public new bool enabled = true;

//    void Update()
//    {
//        if (GameController.instance.gamePlaying && enabled)
//        {
//            _transform = this.gameObject.GetComponent<Transform>();
//            playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
//            nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
//            _animator = this.gameObject.GetComponent<Animator>();

//            StartCoroutine(this.CheckState());
//            StartCoroutine(this.CheckStateForAction());
//        }
//    }


//    IEnumerator CheckState()
//    {
//        while (!isDead)
//        {
//            yield return new WaitForSeconds(0.2f);

//            float dist = Vector3.Distance(playerTransform.position, _transform.position);

//            if (dist <= traceDist)
//            {
//                curState = CurrentState.trace;
//            }
//            else
//            {
//                curState = CurrentState.idle;
//            }

//            yield return new WaitForSeconds(0.2f);

//            if (dist <= attackDist)
//            {
//                curState = CurrentState.attack;

//            }

//        }
//    }

//    IEnumerator CheckStateForAction()
//    {
//        while (!isDead)
//        {
//            switch (curState)
//            {
//                case CurrentState.idle:
//                    nvAgent.Stop();
//                    _animator.SetBool("IsTrace", false);
//                    break;
//                case CurrentState.trace:
//                    nvAgent.destination = playerTransform.position;
//                    nvAgent.Resume();
//                    _animator.SetBool("IsTrace", true);

//                    break;
//                case CurrentState.attack:
//                    int a = Random.Range(0, 4);
//                    yield return new WaitForSeconds(2f);
//                    Debug.Log("random");
//                    switch (a)
//                    {
//                        case 0:
//                            {
//                                _animator.SetBool("Islefthook", true);
//                                yield return new WaitForSeconds(2.5f);
//                                _animator.SetBool("Islefthook", false);
//                                break;
//                            }
//                        case 1:
//                            {
//                                _animator.SetBool("Isrightkick", true);

//                                yield return new WaitForSeconds(1.8f);

//                                _animator.SetBool("Isrightkick", false);

//                                break;
//                            }
//                        case 2:
//                            {
//                                _animator.SetBool("Isleftkick", true);

//                                yield return new WaitForSeconds(1.8f);

//                                _animator.SetBool("Isleftkick", false);

//                                break;
//                            }
//                        case 3:
//                            {
//                                _animator.SetBool("Isrightpunch", true);
//                                yield return new WaitForSeconds(2.5f);
//                                _animator.SetBool("Isrightpunch", false);
//                                break;
//                            }
//                    }
//                    break;

//            }


//            yield return null;
//        }
//    }

//}
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

    public new bool enabled = true;

    void Start()
    {


    }

    IEnumerator CheckState()
    {
        while (!isDead)
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
        while (!isDead)
        {
            switch (curState)
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
                    _animator.SetBool("Islefthook", true);
                    yield return new WaitForSeconds(4f);
                    _animator.SetBool("Islefthook", false);
                    yield return new WaitForSeconds(2f);
                    break;
            }


            yield return null;
        }
    }

    void Update()
    {
        if (GameController.instance.gamePlaying && enabled)
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


