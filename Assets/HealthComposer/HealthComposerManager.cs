using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComposerManager : MonoBehaviour
{
    [Header("Heart")]
    [SerializeField] private ClampValue Heart;
    [SerializeField] private GameObject HeartPrefab;
    [SerializeField] private HealthComposerUIData HeartData;

    [Header("Armor")]
    [SerializeField] private ClampValue Armor;
    [SerializeField] private GameObject ArmorPrefab;
    [SerializeField] private HealthComposerUIData ArmorData;

    [Header("Health Bar")]
    [SerializeField] private Transform HealthBarParent;
    [SerializeField] private GameObject HealthComposerGroupPrefab;

    private HealthComposerUIGroup HeartGroup;
    private HealthComposerUIGroup ArmorGroup;


    private void Awake()
    {
        Heart.OnValueChanged += HeartValueChanged;
        Armor.OnValueChanged += ArmorValueChanged;
    }
    private void Start()
    {
        HeartGroup = CreateHeathComposerGroup(HeartPrefab, Heart, HeartData);
        ArmorGroup = CreateHeathComposerGroup(ArmorPrefab, Armor, ArmorData);
    }
    private void Update()
    {
        HeartValueChanged(Heart.Value);
        ArmorValueChanged(Armor.Value);
    }
    private HealthComposerUIGroup NewHealthComposerGroup()
    {
        GameObject o = Instantiate(HealthComposerGroupPrefab, HealthBarParent);
        return o.GetComponent<HealthComposerUIGroup>();
    }
    private HealthComposerUIGroup CreateHeathComposerGroup(GameObject Prefab, ClampValue Value, HealthComposerUIData Data)
    {
        HealthComposerUIGroup HCG = NewHealthComposerGroup();

        foreach (GameObject HealthComposerInstance in HCG.AddItems(Prefab, Value, Data))
        {
            HealthComposerUI h = HealthComposerInstance.GetComponent<HealthComposerUI>();
            h.Data = Data;
        }

        return HCG;
    }

    private void HeartValueChanged(int v) { HeartGroup.SetHealthComposerGroupTo(v); }
    private void ArmorValueChanged(int v) { ArmorGroup.SetHealthComposerGroupTo(v); }
}
