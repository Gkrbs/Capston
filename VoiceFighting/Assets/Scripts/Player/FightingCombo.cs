using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum AttackType { LeftHand = 0, RightHand = 1, LeftLeg = 2, RightLeg = 3 }

public class FightingCombo : MonoBehaviour
{
    [Header("Inputs")]
    public KeyCode LeftHandKey;   //LeftHandKey
    public KeyCode RightHandKey;   //RightHandKey
    public KeyCode LeftLegKey;   //LeftLegKey
    public KeyCode RightLegKey;   //RightLegKey

    [Header("Attacks")]
    public Attack LeftPunch;
    public Attack RightPunch;
    public Attack LeftKick;
    public Attack RightKick;
    public List<Combo> combos;
    public float comboLeeway = 0.2f;

    [Header("Components")]
    Animator ani;

    Attack curAttack = null;
    ComboInput lastInput = null;
    List<int> currentCombos = new List<int>();

    float timer = 0;
    float leeway = 0;
    bool skip = false;

    public float cooldown = 1.2f;
    private float lastAttackedAt = -9999f;

    void Start()
    {
        ani = GetComponent<Animator>();
        PrimeCombos();
    }

    void PrimeCombos()
    {
        for (int i = 0; i < combos.Count; i++)
        {
            Combo c = combos[i];
            c.onInputted.AddListener(() =>
            {
                skip = true;
                Attack(c.comboAttack);
                ResetCombos();
            });
        }
    }

    void Update()
    {

        if (curAttack != null)
        {
            if (timer > 0)
                timer -= Time.deltaTime;
            else
                curAttack = null;

            return;
        }

        if (currentCombos.Count > 0)
        {
            leeway += Time.deltaTime;
            if (leeway >= comboLeeway)
            {
                if (lastInput != null)
                {
                    Attack(getAttackFromType(lastInput.type));
                    lastInput = null;
                }
                ResetCombos();
            }
        }
        else
            leeway = 0;

        ComboInput input = null;

        if (Input.GetKeyDown(LeftHandKey))
            input = new ComboInput(AttackType.LeftHand);
        if (Input.GetKeyDown(RightHandKey))
            input = new ComboInput(AttackType.RightHand);
        if (Input.GetKeyDown(LeftLegKey))
            input = new ComboInput(AttackType.LeftLeg);
        if (Input.GetKeyDown(RightLegKey))
            input = new ComboInput(AttackType.RightLeg);

        if (input == null) return;
        lastInput = input;

        List<int> remove = new List<int>();
        for (int i = 0; i < currentCombos.Count; i++)
        {
            Combo c = combos[currentCombos[i]];
            if (c.continueCombo(input))
                leeway = 0;
            else
                remove.Add(i);
        }

        if (skip)
        {
            skip = false;
            return;
        }

        for (int i = 0; i < combos.Count; i++)
        {
            if (currentCombos.Contains(i)) continue;
            if (combos[i].continueCombo(input))
            {
                currentCombos.Add(i);
                leeway = 0;
            }
        }

//        foreach (int i in remove)
//            currentCombos.RemoveAt(i);

        if (Time.time > lastAttackedAt + cooldown)
        {
            if (currentCombos.Count <= 0)
                Attack(getAttackFromType(input.type));
            lastAttackedAt = Time.time;
        }
    }

    void ResetCombos()
    {
        leeway = 0;
        for (int i = 0; i < currentCombos.Count; i++)
        {
            Combo c = combos[currentCombos[i]];
            c.ResetCombo();
        }

        currentCombos.Clear();
    }


    void Attack(Attack att)
    {
        curAttack = att;
        timer = att.length;
        ani.Play(att.name, -1, 0);
    }

    Attack getAttackFromType(AttackType t)
    {
        if (t == AttackType.LeftHand)
            return LeftPunch;
        if (t == AttackType.RightHand)
            return RightPunch;
        if (t == AttackType.LeftLeg)
            return LeftKick;
        if (t == AttackType.RightLeg)
            return RightKick;
        return null;
    }
}

[System.Serializable]
public class Attack
{
    public string name;
    public float length;
}

[System.Serializable]
public class ComboInput
{
    public AttackType type;

    public ComboInput(AttackType t)
    {
        type = t;
    }

    public bool isSameAs(ComboInput test)
    {
        return (type == test.type);
    }
}

[System.Serializable]
public class Combo
{
    public string name;
    public List<ComboInput> inputs;
    public Attack comboAttack;
    public UnityEvent onInputted;
    int curInput = 0;

    public bool continueCombo(ComboInput i)
    {
        if (inputs[curInput].isSameAs(i))
        {
            curInput++;
            if (curInput >= inputs.Count)
            {
                onInputted.Invoke();
                curInput = 0;
            }
            return true;
        }
        else
        {
            curInput = 0;
            return false;
        }
    }

    public ComboInput currentComboInput()
    {
        if (curInput >= inputs.Count) return null;
        return inputs[curInput];
    }

    public void ResetCombo()
    {
        curInput = 0;
    }
}
