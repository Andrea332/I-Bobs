using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Sequence", menuName = "Sequence", order = 1)]
public class Sequence : ScriptableObject
{
    public int mapSlice;
    public int numPadNumber;
    public int counterNumber;
    public int levaOn;
    public Sprite emergencySprite;
    public Sprite manual;
}
