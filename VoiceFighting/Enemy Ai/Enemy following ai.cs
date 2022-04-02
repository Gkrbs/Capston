using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControll : MonoBehaviour
{


    private Transform _transform;
    private Transform playerTransform;
    private NavMeshAgent nvAgent;
    static Animator anim2;
    private Vector3 direction;
    
    void Start()
    {
        anim2 = GetComponent<Animator>();
        
        // 적이 플레이어의 위치를 파악후 플레이어에게 다가가는 코드
        _transform = this.gameObject.GetComponent<Transform>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();

        nvAgent.destination = playerTransform.position;
    }

   
    void Update()
    {
        //적이 플레이어를 바라보게 하는 
        direction = playerTransform - this.transform.position;
        direction.y = 0;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction),0.3f);
    }
}
