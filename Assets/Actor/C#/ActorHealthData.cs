using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu()]
public class ActorHealthData : ScriptableObject
{
    [Header("Heart")]
    public HealthComposerData Heart;
    public uint HeartNumber;

    [Header("Armor")]
    public HealthComposerData Armor;
    public uint ArmorNumber;
}
