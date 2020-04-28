using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Transform Hearts;

    public IEnumerable<GameObject> AddItems(GameObject Prefab, ClampValue cv, int v)
    {
        int HeartAmount = cv.MaxValue / v;

        for (int i = 0; i < HeartAmount; i++) 
            yield return Instantiate(Prefab, Hearts);
    }
    public void SetHealthBar(int hv)
    {
        ResetBar();

        int Chv = hv;
        foreach (Transform h in Hearts)
        {
            Heart H_ = h.GetComponent<Heart>();
            
            int HearthValue = H_.Data.Value;

            if (Chv >= HearthValue)
            {
                Chv -= HearthValue;
                H_.SetState(Heart.State.On);
            }

            if (Chv <= 0) break;
        }
    }
    public void ResetBar()
    {
        foreach (Transform h in Hearts)
        {
            Heart _h = h.GetComponent<Heart>();
            _h.SetState(Heart.State.Off);
        }
    }
}
