using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Leva : MonoBehaviour, IState
{
    public int Id => id;
    public int levaOn;
    public Vector3 pushStartRotation;
    public Vector3 pullStartRotation;

    public AudioSource sound;

    public UnityEvent onPushed;
    public UnityEvent onPulled;

    [SerializeField] private int id;

    private void Start()
    {
        if (levaOn == 1)
        {
            transform.eulerAngles = pushStartRotation;
            return;
        }

        transform.eulerAngles = pullStartRotation;
    }

    public void Activate()
    {
        if(levaOn == 1)
        {
            Push();
            return;
        }

        Pull();
    }

    public void Push()
    {
        sound.Play();
        levaOn = 0;
        onPushed?.Invoke();
    }

    public void Pull()
    {
        sound.Play();
        levaOn = 1;
        onPulled?.Invoke();
    }
    public object GetValue()
    {    
        return levaOn;
    }
}
