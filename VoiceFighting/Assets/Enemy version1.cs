using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControll : MonoBehaviour
{


    private Transform _transform;
    private Transform playerTransform;
    private NavMeshAgent nvAgent;
    static Animator Eaim;
    private Vector3 direction;
    
    void Start()
    {
        Eaim = GetComponent<Animator>();
        
        // 적이 플레이어의 위치를 파악후 플레이어에게 다가가는 코드
        _transform = this.gameObject.GetComponent<Transform>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();

        nvAgent.destination = playerTransform.position;
    }

   
    void Update()
    {
        if (Eaim.GetCurrentAnimatorStateInfo(0).IsName("플레이어 기본상태")){   //플레이어쪽을 바라보게 하는 코드
            direction = playerTransform - this.transform.position;
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction),0.3f);
        }
    }
}
