using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IncrementScript : MonoBehaviour, IState
{
    public TMP_Text CharHolder;
    private int Value = 0;

    [SerializeField] private int id;
    public int Id => id;

    public void Increase()
    {
        Value++;
        if(Value >= 0 && Value < 9)
        {
            CharHolder.text = Value.ToString();
        }
        else if (Value >= 9)
        {
            Value = 9;
            CharHolder.text = Value.ToString();
        }
    }

    public void Decrease()
    {
        Value--;
        if (Value > 0 && Value <= 9)
        {
            CharHolder.text = Value.ToString();
        }
        else if (Value <= 0)
        {
            Value = 0;
            CharHolder.text = Value.ToString();
        }
    }

    public object GetValue()
    {
        return Value;
    }
}
