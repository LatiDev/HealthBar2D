using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageManager : MonoBehaviour
{
    [SerializeField] private int _Heart = 5;
    [SerializeField] private int _Armor = 3;

    private int Heart
    {
        get
        {
            return _Heart;
        }
        set
        {
            _Heart = Mathf.Clamp(value, 0, 1000);
            OnHeartTakeDamage?.Invoke(value);
        }
    }
    private int Armor
    {
        get
        {
            return _Armor;
        }
        set
        {
            _Armor = Mathf.Clamp(value, 0, 1000);
            OnArmorTakeDamage?.Invoke(value);
        }
    }


    public event UnityAction<int> OnHeartTakeDamage;
    public event UnityAction<int> OnArmorTakeDamage;

    public void TakeDamage(Damage d)
    {
        int Damage = d.Value;
        int ArmorLeft = Armor - Damage;

        //Has enought armor to fully take the damage
        if (ArmorLeft >= 0)
        {
            //And so fully take the damage
            Armor -= Damage;
        }
        else //ArmorLeft < 0 --- Can't fully take the damage
        {
            Armor -= Damage;
            
            int DamageToHeart = (int) Mathf.Abs((float)ArmorLeft);
            Heart -= DamageToHeart;
        }        
    }
    [ContextMenu("Show Example")]
    public void TakeDamageExample()
    {
        Damage d = new Damage();
        d.Value = 4;
        
        TakeDamage(d);
    }
}
