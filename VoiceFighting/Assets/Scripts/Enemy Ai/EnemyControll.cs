using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControll : MonoBehaviour
{

    public enum CurrentState { idle, trace, kick, punch, dead };
    public CurrentState curState = CurrentState.idle;
    private CharacterAnimation enemy_Anim;

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
        enemy_Anim = GameObject.Find("Enemy").GetComponent<CharacterAnimation>();

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
        while (!isDead)
        {
            if(GameController.instance.enemyHealth <= 0f)
            {
                isDead = true;
            }
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
        while (!isDead)
        {
            switch (curState)
            {
                case CurrentState.idle:
                    nvAgent.isStopped = true;
                    _animator.SetBool("IsTrace", false);
                    yield return new WaitForSeconds(3.5f);
                    break;
                case CurrentState.trace:
                    nvAgent.destination = playerTransform.position;
                    nvAgent.isStopped = false;
                    _animator.SetBool("IsTrace", true);

                    break;
                case CurrentState.kick:
                    int a = Random.Range(0, 2);

                    switch (a)
                    {
                        case 0:
                            _animator.SetBool("Isleftkick", true);
                            yield return new WaitForSeconds(1.2f);
                            _animator.SetBool("Isleftkick", false);
                            _animator.SetBool("IsTrace", false);
                            break;
                        case 1:
                            _animator.SetBool("Isrightkick", true);

                            yield return new WaitForSeconds(1.2f);

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
                            yield return new WaitForSeconds(1.2f);
                            _animator.SetBool("Islefthook", false);
                            _animator.SetBool("IsTrace", false);
                            break;
                        case 1:
                            _animator.SetBool("Isrightpunch", true);

                            yield return new WaitForSeconds(1.2f);

                            _animator.SetBool("Isrightpunch", false);

                            _animator.SetBool("IsTrace", false);

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
