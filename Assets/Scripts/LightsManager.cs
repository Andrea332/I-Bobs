using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsManager : MonoBehaviour
{
    public List<Light> lights;

    public void SetLights(int errors)
    {
        for (int i = 0; i < lights.Count; i++) 
        {          
            lights[i].enabled = i < errors;          
        }
    }

    public void SetLightsOff()
    {
        foreach (Light light in lights)
        {
            light.enabled = false;
        }
    }
}
