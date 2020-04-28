using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComposerUIGroup : MonoBehaviour
{
    private void ResizeRect(float w)
    {
        this.GetComponent<RectTransform>().SetWidth(w);

        print(w);
    }
    
    public IEnumerable<GameObject> AddItems(GameObject Prefab, ClampValue Base, HealthComposerUIData Data)
    {
        int HealthComposerAmount = Base.MaxValue / Data.Value;

        ResizeRect(HealthComposerAmount * (100+10));

        for (int i = 0; i < HealthComposerAmount; i++)
            yield return Instantiate(Prefab, this.transform);
    }
    public void SetHealthComposerGroupTo(int hv)
    {
        ResetBar();

        int Chv = hv;
        foreach (Transform h in this.transform)
        {
            HealthComposerUI H_ = h.GetComponent<HealthComposerUI>();

            int HearthValue = H_.Data.Value;

            if (Chv >= HearthValue)
            {
                Chv -= HearthValue;
                H_.CurrentState = HealthComposerUI.State.On;
            }

            
            if (Chv <= 0) break;
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
