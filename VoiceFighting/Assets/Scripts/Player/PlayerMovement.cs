using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterAnimation player_Anim;
    private Rigidbody myBody;

    public float intervalOfDoubleTap = 0.2f;
    public float lastTapTime;

    public float move_Speed;
    public float walk_Speed = 2f;
    public float run_Speed = 4f;

    bool runnig = false;
    bool walking = false;

    public new bool enabled = true;
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        player_Anim = GetComponent<CharacterAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.gamePlaying && !EnemyColliderDetection.instance.touch)
        {
            AnimatePlayerWalk();
        }
    }

    void FixedUpdate()
    {
        if (GameController.instance.gamePlaying && !EnemyColliderDetection.instance.touch)
        {
            DetectMovement();
        }
    }

    void DetectMovement()
    {
        if (walking && !EnemyColliderDetection.instance.touch)
        {
            myBody.velocity = new Vector2(Input.GetAxis(Axis.HORIZONTAL_AXIS) * (walk_Speed),
            myBody.velocity.y);
        }

        if (runnig && !EnemyColliderDetection.instance.touch)
        {
            myBody.velocity = new Vector2(Input.GetAxis(Axis.HORIZONTAL_AXIS) * (run_Speed),
            myBody.velocity.y);
        }


    }



    void AnimatePlayerWalk()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            float timeSinceLastClick = Time.time - lastTapTime;

            if (timeSinceLastClick <= intervalOfDoubleTap)
            {
                walking = false;
                runnig = true;
                player_Anim.Idle(false);
                player_Anim.Walk(false);
                player_Anim.Run(true);
            }
            else
            {
                walking = true;
                runnig = false;
                player_Anim.Idle(false);
                player_Anim.Walk(true);
            }
            lastTapTime = Time.time;
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            walking = true;
            runnig = false;
            player_Anim.Idle(false);
            player_Anim.Back(true);
        }

        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            player_Anim.Idle(true);
            player_Anim.Walk(false);
            player_Anim.Run(false);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            player_Anim.Idle(true);
            player_Anim.Back(false);
        }
    }

}
