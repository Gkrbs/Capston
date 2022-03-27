using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterAnimation player_Anim;
    private Rigidbody myBody;

    public float move_Speed;
    public float walk_Speed = 2f;
    public float run_Speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        player_Anim = GetComponent<CharacterAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatePlayerWalk();
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

    void AnimatePlayerWalk()
    {
        if(Input.GetAxis(Axis.HORIZONTAL_AXIS) > 0)
        {
            player_Anim.Walk(true);
        }
        else if(Input.GetAxis(Axis.HORIZONTAL_AXIS) < 0)
        {
            player_Anim.Back(true);
        }
        else
        {
            player_Anim.Walk(false);
            player_Anim.Back(false);
        }
    }
}
