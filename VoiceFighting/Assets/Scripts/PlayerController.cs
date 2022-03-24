using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float moveDir;
    public float walkSpeed = 2;
    public float runSpeed = 4;
    public float backSpeed = 2;

    private Animator AN;
    private Rigidbody RB;
    
    // Start is called before the first frame update
    void Start()
    {
        AN = GetComponent<Animator>();
        RB = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDir = Input.GetAxis("Horizontal");
        RB.velocity = new Vector2(moveDir * moveSpeed, RB.velocity.y);

        moveSpeed = walkSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
            moveSpeed = runSpeed;
        if (Input.GetKeyDown(KeyCode.C))
            AN.SetBool("jump", true);

        if (moveDir > 0 && moveSpeed == walkSpeed)
        {
            AN.SetBool("run", false);
            AN.SetBool("walk", true);
        }
        else if (moveDir > 0 && moveSpeed == runSpeed)
        {
            AN.SetBool("walk", false);
            AN.SetBool("run", true);
        }
        else if (moveDir < 0)
        {
            moveSpeed = backSpeed;
            AN.SetBool("back", true);
        }
        else
        {
            AN.SetBool("run", false);
            AN.SetBool("walk", false);
            AN.SetBool("back", false);
            AN.SetBool("jump", false);
        }

    }
}
