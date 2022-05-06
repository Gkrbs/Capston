using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliderDetection : MonoBehaviour
{
    private CharacterAnimation player_Anim;
    bool isHit = false;

    void Start()
    {
        player_Anim = GameObject.Find("Player").GetComponent<CharacterAnimation>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "PlayerHitbox")
        {
            DoDamage();
            player_Anim.Hit(true);

        }
        else
        {
            player_Anim.Hit(false);
        }
    }
    void DoDamage()
    {
        GameController.instance.playerHealth -= 1f;
    }
}
