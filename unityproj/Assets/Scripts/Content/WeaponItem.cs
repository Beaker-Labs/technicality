using UnityEngine;

// This scriptableObject defines the weapon for inventory purposes. The weapon's actual behaviour and appearance is defined inside the prefab.
[CreateAssetMenu(fileName = "WeaponItem", menuName = "ScriptableObjects/WeaponItem", order = 1)]
public class WeaponItem : EquippableItem
{
    [Header("This scriptableObject defines the weapon for inventory purposes. The weapon's actual behaviour and appearance is defined inside the prefab.")]
    public GameObject prefab;
}