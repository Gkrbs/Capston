using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator anim;
    
    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    public void Idle(bool idle)
    {
        anim.SetBool(AnimationTags.IDLE_ANIMATION, idle);
    }

    public void Run(bool run)
    {
        anim.SetBool(AnimationTags.RUN, run);
    }

    public void Walk(bool walk)
    {
        anim.SetBool(AnimationTags.MOVEMENT, walk);
    }

    public void Back(bool back)
    {
        anim.SetBool(AnimationTags.BACK, back);
    }

    public void Jump(bool jump)
    {
        anim.SetBool(AnimationTags.JUMP, jump);
    }

    public void Defend(bool defend)
    {
        anim.SetBool(AnimationTags.DEFEND, defend);
    }
    
    public void Hit()
    {
        anim.SetTrigger(AnimationTags.HIT_TRIGGER);
    }

    public void KnockDown()
    {
        anim.SetTrigger(AnimationTags.KNOCK_DOWN_TRIGGER);
    }

    public void Death(bool death)
    {
        anim.SetBool(AnimationTags.DEATH_TRIGGER, death);
    }

} // class