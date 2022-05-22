using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class VoiceControl : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>();
    private CharacterAnimation anim;

    private CharacterAnimation enemy_Anim;
    private EnemyControll enemy_Move;

    public bool touch = false;

    void Start()
    {
        enemy_Anim = GameObject.Find("Enemy").GetComponent<CharacterAnimation>();
        enemy_Move = GameObject.Find("Enemy").GetComponent<EnemyControll>();

        anim = GameObject.Find("Player").GetComponent<CharacterAnimation>();

        actions.Add("smash", skill1);
        actions.Add("punch", skill2);
        actions.Add("combo", skill3);
        actions.Add("turn", skill4);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();

    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void skill1()
    {
        anim.Skill1();
    }

    private void skill2()
    {
        anim.Skill2();
    }

    private void skill3()
    {
        anim.Skill3();
    }
    private void skill4()
    {
        anim.Skill4();
    }
}
