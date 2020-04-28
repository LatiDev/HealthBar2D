using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampValue : MonoBehaviour
{
    [SerializeField] private int _Value = 100;
    [HideInInspector] public int Value 
    { 
        get 
        { 
            return _Value; 
        } 
        set 
        { 
            _Value = Mathf.Clamp(value, 0, _MaxValue); 
        }
    }
    [SerializeField] private int _MaxValue = 100;
    [HideInInspector] public int MaxValue
    {
        get
        {
            return _MaxValue;
        }
        set
        {
            _MaxValue = value;
        }
    }
    public float Proportion()
    {
        return _MaxValue / _Value;
    }
}
