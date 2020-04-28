using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ClampValue), typeof(Image))]
public class HealthComposerUI : MonoBehaviour
{
    public ClampValue Value;
    public HealthComposerUIData Data;
    public Image Image;

    public enum State
    {
        On,
        Off
    }

    [HideInInspector] private State _CurrentState = State.On;
    public State CurrentState
    {
        get
        {
            return _CurrentState;
        }
        set
        {
            this.SetState(value);
        }
    }

    private void SetState(State s)
    {
        if (s == State.On) Image.sprite = Data.On;
        else if (s == State.Off) Image.sprite = Data.Off;

        this._CurrentState = s;
    }
}
