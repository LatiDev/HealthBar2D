using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComposerUIGroup : MonoBehaviour
{
    private void ResizeRect(float w)
    {
        this.GetComponent<RectTransform>().SetWidth(w);
    }
    
    public IEnumerable<GameObject> AddItems(GameObject Prefab, ClampValue Base, HealthComposerUIData Data)
    {
        float HealthComposerAmount = Base.MaxValue / Data.Value;

        ResizeRect(HealthComposerAmount * (100+10));

        for (int i = 0; i < HealthComposerAmount; i++)
            yield return Instantiate(Prefab, this.transform);
    }
    public void SetHealthComposerGroupTo(float hv)
    {
        ResetBar();

        float Chv = hv;
        foreach (Transform h in this.transform)
        {
            HealthComposerUI H_ = h.GetComponent<HealthComposerUI>();

            int HealthComposerValue = (int) H_.Value.Value;
            
            if (Chv >= HealthComposerValue) 
            { 
                Chv -= HealthComposerValue; 
                H_.CurrentState = HealthComposerUI.State.On;
            }
            else if (Chv <= 0) break;
        }
    }
    public void ResetBar()
    {
        foreach (Transform h in this.transform)
        {
            HealthComposerUI _h = h.GetComponent<HealthComposerUI>();
            _h.CurrentState = HealthComposerUI.State.Off;
        }
    }

}
