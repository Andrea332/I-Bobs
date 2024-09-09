using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Keypad : MonoBehaviour, IState
{
    public int Id => id;
    [SerializeField] private int id;

    private List<int> Code = new List<int>();
    public TMP_Text charHolder;

    public void B1()
     {
        if (Check())
        {
            Code.Add(1);
            charHolder.text = string.Join("", Code);
        }
    }

    public void B2()
     {
        if (Check())
        {
            Code.Add(2);
            charHolder.text = string.Join("", Code);
        }
    }

    public void B3()
     {
        if (Check())
        {
            Code.Add(3);
            charHolder.text = string.Join("", Code);
        }
    }

    public void B4()
     {
        if (Check())
        {
            Code.Add(4);
            charHolder.text = string.Join("", Code);
        }
    }

    public void B5()
    {
               if (Check())
        {
            Code.Add(5);
            charHolder.text = string.Join("", Code);
        }
    }

    public void B6()
    {
        if (Check())
        {
            Code.Add(6);
            charHolder.text = string.Join("", Code);
        }
    }

    public void B7()
    {
        if (Check())
        {
            Code.Add(7);
            charHolder.text = string.Join("", Code);
        }
    }

    public void B8()
    {
        if (Check())
        {
            Code.Add(8);
            charHolder.text = string.Join("", Code);
        }
    }

    public void B9()
    {
        if (Check())
        {
            Code.Add(9);
            charHolder.text = string.Join("", Code);
        }
    }

    public void B0()
    {
        if (Check())
        {
            Code.Add(0);
            print(string.Join("",Code));
            charHolder.text = string.Join("", Code);
        }

    }

    public void BX()
    {
        Code = new List<int>();
        charHolder.text = "";
    }


    private bool Check()
    {
        return !(Code.Count == 4);
    }

    public object GetValue()
    {
        return int.Parse(string.Join("", Code));
    }
}
