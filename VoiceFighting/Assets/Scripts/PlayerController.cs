using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float moveDir;
    
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

        if (moveDir > 0)
            AN.SetBool("front", true);
        else if (moveDir < 0)
            AN.SetBool("back", true);
        else
        {
            AN.SetBool("front", false);
            AN.SetBool("back", false);
        }

    }
}
