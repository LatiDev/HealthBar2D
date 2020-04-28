using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private ClampValue Value;
        
    [SerializeField] private GameObject HeartPrefab;
    [SerializeField] private HeartData HeartData;

    [SerializeField] private HealthBar Bar;

    private void Start()
    {
        foreach(GameObject Item in Bar.AddItems(HeartPrefab, Value, HeartData.Value))
        {
            Heart heart = Item.GetComponent<Heart>();
            heart.Data = HeartData;
        }
    }
    private void Update()
    {
        Bar.SetHealthBar(Value.Value);
    }
}
