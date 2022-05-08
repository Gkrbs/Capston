using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{

    public Transform targetTrasform;

    public float dist = 7.0f;
    public float height = 2.0f;
    public float dampTrace = 20.0f;

    private Transform _transform;


   
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        _transform.position = Vector3.Lerp(_transform.position, targetTrasform.position - (targetTrasform.forward * dist) + (Vector3.up * height), Time.deltaTime * dampTrace);
        _transform.LookAt(targetTrasform.position);
        
    }
}
