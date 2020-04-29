using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthComposerUIGroup : MonoBehaviour
{
    private void ResizeRect(float w)
    {
        this.GetComponent<RectTransform>().SetWidth(w);
    }
    
    public IEnumerable<GameObject> AddItems(GameObject Prefab, uint HealthComposerAmount)
    {
        ResizeRect(HealthComposerAmount * (100+10));

        for (int i = 0; i < HealthComposerAmount; i++)
            yield return Instantiate(Prefab, this.transform);
    }
    public void AddItems(HealthComposerData HealthData, uint HealthComposerAmount)
    {
        foreach (GameObject HealthComposerUIInstance in this.AddItems(HealthData.Prefab, HealthComposerAmount))
        {
            HealthComposerUI Hcuii = HealthComposerUIInstance.GetComponent<HealthComposerUI>();
            Hcuii.Data = HealthData.Data;            
        }
           
    }
    public void SetHealthComposerGroupTo(int HealthComposerValue)
    {
        ResetBar();

        int HCA_Round = (int)HealthComposerValue;

        for (int i = 0; i < HCA_Round; i++)
        {
            Transform H_ = this.transform.GetChild(i);
            HealthComposerUI Hc = H_.GetComponent<HealthComposerUI>();

            Hc.CurrentState = HealthComposerUI.State.On;
        }



        /*

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
            else if (Chv < HealthComposerValue)
            {
                H_.CurrentState = HealthComposerUI.State.On;
                h.GetComponent<Image>().fillAmount = H_.Data.Value / Cv;
            }
            
            if (Chv < 0) break;
        }

        */
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
