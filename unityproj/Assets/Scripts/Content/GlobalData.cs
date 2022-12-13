using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GlobalData", menuName = "ScriptableObjects/GlobalData", order = 1)]
public class GlobalData : ScriptableObject
{
    public Color textPositiveColor;
    public Color textNegativeColor;
    public GameObject weaponSlotPrefab;
}
