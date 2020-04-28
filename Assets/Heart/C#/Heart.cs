using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public enum State { On, Off }
        
    public HeartData Data;
    
    [SerializeField] private Image Image;
    [HideInInspector] public State HeartState = State.Off;

    public void SetState(State s)
    {
        if (s == State.Off) Image.sprite = Data.HeartOff;
        else if (s == State.On) Image.sprite = Data.HeartOn;

        this.HeartState = s;
    }
}
