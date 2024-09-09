using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractComponent : MonoBehaviour, IInteractable
{
    public UnityEvent onActivated;

    public void Activate()
    {
        //Debug.Log("Interagito");
        onActivated?.Invoke();
    }

}
