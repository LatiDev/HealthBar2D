using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private ClampValue Health;
    
    [Header("Armor")]
    [SerializeField] private ClampValue Armor;
    [SerializeField] private Armor ArmorReduction;

    [ContextMenu("Test")]
    public void Test()
    {
        Damage d = new Damage();
        d.Value = 100;

        TakeDamage(d);
    }

    public void TakeDamage(Damage d)
    {
        float ReducedDamage = ArmorReduction.Reduce(d);
        float DeltaDamage = d.Value - ReducedDamage;

        Health.Value -= ReducedDamage;
        Armor.Value -= 50 * Mathf.Log10(DeltaDamage);        
    }
}
