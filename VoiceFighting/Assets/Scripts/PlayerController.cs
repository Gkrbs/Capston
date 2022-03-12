using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float moveDir;

    private Rigidbody RB;
    
    // Start is called before the first frame update
    void Start()
    {
        RB = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDir = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        RB.velocity = new Vector2(moveDir * moveSpeed, RB.velocity.y);
    }
}
