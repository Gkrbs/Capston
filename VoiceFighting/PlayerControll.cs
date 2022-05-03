using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControll : MonoBehaviour
{
    private Animator _animator;


    private Transform _transform;
    private float _horizontal = 0.0f;
    private float _vertical = 0.0f;

    public float moveSpd = 5.0f;
    public float rotateSpd = 100.0f;

    


    void Start()
    {
        _transform = GetComponent<Transform>();
        _animator = GetComponentInChildren<Animator>();
    }

 
    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        Vector3 moveDirect = (Vector3.forward * _vertical) + (Vector3.right * _horizontal);

        _transform.Translate(moveDirect.normalized * Time.deltaTime * moveSpd, Space.Self);

        _transform.Rotate(Vector3.up * Time.deltaTime * rotateSpd * Input.GetAxis("Mouse X"));

        if(_vertical >= 0.1f)
        {
            _animator.SetBool("IsWalk", true);
        }
        else if(_vertical <= -0.1f)
        {
            _animator.SetBool("IsWalk", true);
        }
        else if (_horizontal >= -0.1f)
        {
            _animator.SetBool("IsWalk", true);
        }
        else if (_horizontal <= -0.1f)
        {
            _animator.SetBool("IsWalk", true);
        }
        else
        {
            _animator.SetBool("IsWalk", false);
        }
    }
}
