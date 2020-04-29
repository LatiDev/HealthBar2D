using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthComposerManager : MonoBehaviour
{
    [SerializeField] private DamageManager Dm;
    
    [Header("Player Data")]
    [SerializeField] private ActorHealthData ActorHealth;

    [Header("Health Bar")]
    [SerializeField] private Transform HealthBarParent;
    [SerializeField] private GameObject HealthComposerGroupPrefab;

    private HealthComposerUIGroup HealthBar;
    private HealthComposerUIGroup ArmorBar;


    private void Start()
    {
        CreateActorHealthUI(ActorHealth);
    }
    private void CreateActorHealthUI(ActorHealthData Ahd)
    {
        HealthBar = CreateHeathComposerGroup(Ahd.Heart, Ahd.HeartNumber);
        Dm.OnHeartTakeDamage += HealthBar.SetHealthComposerGroupTo;

        ArmorBar = CreateHeathComposerGroup(Ahd.Armor, Ahd.ArmorNumber);
        Dm.OnArmorTakeDamage += ArmorBar.SetHealthComposerGroupTo;
    }
    private HealthComposerUIGroup NewHealthComposerGroup()
    {
        GameObject o = Instantiate(HealthComposerGroupPrefab, HealthBarParent);
        return o.GetComponent<HealthComposerUIGroup>();
    }
    private HealthComposerUIGroup CreateHeathComposerGroup(HealthComposerData HealthData, uint HealthComposerAmount)
    {
        HealthComposerUIGroup HCG = NewHealthComposerGroup();
        HCG.AddItems(HealthData, HealthComposerAmount);

        //OnCreatedHealthComposerGroup?.Invoke(HCG);
        return HCG;
    }
}
