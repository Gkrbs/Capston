using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float walkSpeed;

    [SerializeField]
    private float cameraRotationLimit;
    private float currentCameraRotationX = 0;

    [SerializeField]
    private Camera theCamera;

    private Rigidbody myRidgid;

    // Start is called before the first frame update
    void Start()
    {
        myRidgid = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 _moveHorizontal = transform.right * x;
        Vector3 _moveVertical = transform.forward * z;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * walkSpeed;

        myRidgid.MovePosition(transform.position + _velocity * Time.deltaTime);

    }
}
