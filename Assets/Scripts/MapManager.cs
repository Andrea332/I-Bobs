using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public List<MapPart> mapParts;

    private void Start()
    {
        ActivateMapPart(3);
    }

    public void ActivateMapPart(int mapNumber)
    {
        for (int i = 0; i < mapParts.Count; i++) 
        {
            MapPart mapPart = mapParts[i];
         
            if (i == mapNumber)
            {
                mapPart.SetMapOn();
                continue;
            }

            mapPart.SetMapOff();
        }
    }

    public void ActivateEmergencyPart(Sequence sequence)
    {
        for (int i = 0; i < mapParts.Count; i++)
        {
            MapPart mapPart = mapParts[i];

            if (i == sequence.mapSlice)
            {
                mapPart.SetEmergencyOn(sequence.emergencySprite);
                continue;
            }

            mapPart.SetEmergencyOff();
        }
    }

    public void ActivateNextMapPart()
    {
        for(int i = 0;i < mapParts.Count;i++) 
        {
            if (mapParts[i].IsMapActive())
            {
                mapParts[i].SetMapOff();
                if (i == mapParts.Count - 1)
                {
                    i = 0;
                    mapParts[i].SetMapOn();
                    return;
                }

                i++;
                mapParts[i].SetMapOn();
                return;
            }
        }
    }

    public void ActivatePreviousMapPart()
    {
        for (int i = 0; i < mapParts.Count; i++)
        {
            if (mapParts[i].IsMapActive())
            {
                mapParts[i].SetMapOff();
                if (i == 0)
                {
                    i = mapParts.Count - 1;
                    mapParts[i].SetMapOn();
                    return;
                }

                i--;
                mapParts[i].SetMapOn();
                return;
            }
        }
    }

    public int GetActiveMap()
    {
        for(int i = 0;i < mapParts.Count;i++) 
        {
            MapPart mapPart = mapParts[i];

            if (mapPart.IsMapActive())
            {
                return i;
            }
        }

        return -1;
    }
}
[Serializable]
public class MapPart
{
    public bool isOn;
    public Image mapImage;
    public Image mapEmergency;

    public void SetMapOn()
    {
        isOn = true;
        mapImage.enabled = true;
    }

    public void SetMapOff()
    {
        isOn = false;
        mapImage.enabled = false;
    }
    public void SetEmergencyOn(Sprite sprite)
    {
        mapEmergency.enabled = true;
        mapEmergency.sprite = sprite;
    }

    public void SetEmergencyOff()
    {      
        mapEmergency.enabled = false;
    }
    public bool IsMapActive()
    {
        return isOn;
    }
}
