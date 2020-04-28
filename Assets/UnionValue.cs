using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnionValue : MonoBehaviour
{
    [SerializeField] private Union Union = new Union();
    public float Value
    {
        get
        {
            return Union._Value;
        }
    }
}
