using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseToInteractable : MonoBehaviour
{
    //public float interval = 0.1f; // Intervallo di tempo desiderato in secondi
   // private float timer = 0.0f;   // Timer per tenere traccia del tempo trascorso

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            RayCastFromMouseInput();
        }

        // Aggiorna il timer con il tempo trascorso dall'ultimo frame
        /*timer += Time.deltaTime;

        // Controlla se � trascorso l'intervallo desiderato
        if (timer >= interval)
        {
            // Esegui la tua funzione qui
            RayCastFromMouseAlways();

            // Resetta il timer sottraendo l'intervallo
            timer -= interval;
        }
        RayCastFromMouseAlways();*/
    }

    public void RayCastFromMouseInput()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider != null && hit.collider.TryGetComponent(out IInteractable interactable)) 
            {
                interactable.Activate();
            }
        }
    }

    /*public void RayCastFromMouseAlways()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null && hit.collider.TryGetComponent(out Outline outline))
            {
                if (!outline.IsOutlineEnabled)
                    outline.IsOutlineEnabled = true;
            }
        }
        else
        {
            // Se non c'� collisione con un oggetto, disattiva l'outline di tutti gli oggetti
            DisableAllOutlines();
        }
    }

    void DisableAllOutlines()
    {
        // Trova tutti gli oggetti con componente Outline e disattiva l'outline
        Outline[] outlines = FindObjectsOfType<Outline>();
        foreach (Outline outline in outlines)
        {
            outline.IsOutlineEnabled = false;
        }
    }*/
}
