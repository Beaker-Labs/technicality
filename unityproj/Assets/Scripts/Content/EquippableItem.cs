using System;
using UnityEngine;

public class EquippableItem : MonoBehaviour
{
    [Header("Item Properties")]
    public string ItemName = "";
    [TextArea(5,5)] public string Description = "";
    public int Weight;
}
