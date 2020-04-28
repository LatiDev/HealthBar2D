using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComposerUIData : ScriptableObject
{
    public int Value;

    [Header("Sprite")]
    public Sprite HeartOn;
    public Sprite HeartOff;
}
