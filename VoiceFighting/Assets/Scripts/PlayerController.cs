using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;

    [SerializedFeild]
    private float moveSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            anim.Play("Idle");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.Play("Run");
        }
    }
    void Move()
    {
        float DirX = Input.GetAxis("Horizontal");
        float DirZ = Input.GetAxis("Vertical");

        Vector3 _moveHorizontal = transform.right * DirX;
        Vector3 _moveVertical = transform.forward * DirZ;

        Vector3 _vel = (_moveHorizontal + _moveVertical).normalized;



    }
}
