using UnityEngine;

public abstract class EquippableItem : ScriptableObject
{
    [Header("Item Properties")]
    public string itemName = "";
    [TextArea(5,5)] public string description = "";
    public int weight;
    public Sprite icon;
}
