using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnionValue))]
public class Armor : MonoBehaviour
{
    [SerializeField] private UnionValue Reduction;
    
    public float Reduce(Damage d)
    {
        return Reduction.Value * d.Value;
    }
}
