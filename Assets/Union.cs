using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Union
{
    public float _Value;
    private float Value
    {
        get
        {
            return _Value;
        }        
        set
        {
            _Value = Mathf.Clamp(value, 0f, 1f);
        }
    }
}
