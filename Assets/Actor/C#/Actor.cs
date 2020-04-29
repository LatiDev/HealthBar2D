using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Anything that can be damagable
[RequireComponent(typeof(DamageManager))]
public class Actor : MonoBehaviour
{
    [SerializeField] private DamageManager Dm;
}
