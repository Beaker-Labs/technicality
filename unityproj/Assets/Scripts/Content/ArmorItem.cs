using UnityEngine;

[CreateAssetMenu(fileName = "ArmorItem", menuName = "ScriptableObjects/ArmorItem", order = 1)]
public class ArmorItem : EquippableItem
{
    public int Armor;
    public int HitPoints;
}
