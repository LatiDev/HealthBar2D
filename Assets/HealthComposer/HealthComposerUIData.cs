using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "", menuName = "")]
public class HealthComposerUIData : ScriptableObject
{
    public int Value;

    [Header("Sprite")]
    public Sprite On;
    public Sprite Off;
}
