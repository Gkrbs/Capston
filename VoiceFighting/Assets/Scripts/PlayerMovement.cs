using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody myBody;

    public float walk_Speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        //player_Animation = GetComponentInChildren<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        DetectMovement();
    }

    void DetectMovement()
    {
        myBody.velocity = new Vector2(Input.GetAxis(Axis.HORIZONTAL_AXIS) * (walk_Speed),
            myBody.velocity.y);
    }
}
