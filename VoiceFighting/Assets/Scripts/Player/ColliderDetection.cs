using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetection : MonoBehaviour
{
    private CharacterAnimation enemy_Anim;

    void Start()
    {
        enemy_Anim = GameObject.Find("Enemy").GetComponent<CharacterAnimation>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "EnemyHitbox")
        {
            DoDamage();
            enemy_Anim.Hit(true);

        }
        else
        {
            enemy_Anim.Hit(false);
        }
    }
    void DoDamage()
    {
        GameController.instance.enemyHealth -= 1f;
    }
}
