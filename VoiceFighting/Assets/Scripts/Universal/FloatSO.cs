using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatSO : ScriptableObject
{
    public float m_Value;

    public float Value
    {
        get { return m_Value; }
        set { m_Value = value; }
    }
}
