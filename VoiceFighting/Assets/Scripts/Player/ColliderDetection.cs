using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetection : MonoBehaviour
{
    private CharacterAnimation enemy_Anim;
    private CharacterAnimation player_Anim;

    private EnemyControll enemy_Move;

    public bool touch = false;

    void Start()
    {
        enemy_Anim = GameObject.Find("Enemy").GetComponent<CharacterAnimation>();
        enemy_Move = GameObject.Find("Enemy").GetComponent<EnemyControll>();
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1f);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "EnemyHitbox")
        {
            DoDamage();
            HitAnim();
            touch = false;
            enemy_Move.enabled = true;
        }
    }

    void HitAnim()
    {
        if (GameController.instance.enemyHealth <= 0f)
        {
            enemy_Anim.Death();
            FindObjectOfType<AudioManager>().Play("playerDeath");
        }
        FindObjectOfType<AudioManager>().Play("Hit");
        enemy_Anim.Hit();
        Invoke("ExampleCoroutine", 1f);
    }
    void DoDamage()
    {
        enemy_Move.enabled = false;
        touch = true;
        GameController.instance.enemyHealth -= 5f;
    }
}
