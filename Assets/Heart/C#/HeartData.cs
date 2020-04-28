using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HeathData", menuName = "HeathData")]
public class HeartData : ScriptableObject
{
    public int Value;
    
    [Header("Sprite")]
    public Sprite HeartOn;
    public Sprite HeartOff;
}
