using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClampValue : MonoBehaviour
{
    public event UnityAction<float> OnValueChanged;


    [SerializeField] private float _Value = 100;
    [HideInInspector] public float Value 
    { 
        get 
        { 
            return _Value; 
        } 
        set 
        { 
            _Value = Mathf.Clamp(value, 0, _MaxValue);
            OnValueChanged(_Value);
        }
    }
    [SerializeField] private float _MaxValue = 100;
    [HideInInspector] public float MaxValue
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

    public void ResetValueTo(float v)
    {
        this._Value = v;
        this._MaxValue = v;
    }
    public float Proportion()
    {
        print($"{_MaxValue}, {_Value}");
        return _MaxValue / _Value;
    }
}
