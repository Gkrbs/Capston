using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliderDetection : MonoBehaviour
{
    private CharacterAnimation player_Anim;

    private PlayerMovement player_Move;

    public bool touch = false;

    void Start()
    {
        player_Anim = GameObject.Find("Player").GetComponent<CharacterAnimation>();
        player_Move = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1f);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "PlayerHitbox")
        {
            DoDamage();
            HitAnim();
            touch = false;
            player_Move.enabled = true;
        }
    }

    void HitAnim()
    {
        FindObjectOfType<AudioManager>().Play("Hit");
        player_Anim.Hit();
        Invoke("ExampleCoroutine", 1f);
    }
    void DoDamage()
    {
        player_Move.enabled = false;
        touch = true;
        GameController.instance.playerHealth -= 5f;
    }
}
