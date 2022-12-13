using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ItemSelector : MonoBehaviour
{
    private List<EquippableItem> _items;

    public GameObject itemListEntry;
    private Action<EquippableItem> _setItemCallback;
    
    public void Show(Type itemType, Action<EquippableItem> setItemCallback)
    {
        gameObject.SetActive(true);
        
        _items = new List<EquippableItem>();
        foreach (var item in GameInfo.Items)
        {
            if (itemType.IsInstanceOfType(item))
            {
                _items.Add(item);
            }
        }

        itemListEntry.SetActive(true);
        
        for (int i = 0; i < _items.Count; i++)
        {
            ItemListEntry il = Instantiate(itemListEntry, itemListEntry.transform.parent).GetComponent<ItemListEntry>();
            il.Initialize(_items[i], i, this);
        }
        itemListEntry.SetActive(false);

        
    }
    
    // Start is called before the first frame update
    // void Start()
    // {
    //     Select(typeof(EquippableItem));
    // }

    public void Select(EquippableItem item)
    {
        Debug.Log($"Selecting {item.itemName}");
        
        // clean up leftover ui elements before disabling self
        foreach (Transform child in itemListEntry.transform.parent)
        {
            if (child != itemListEntry.transform)
            {
                Destroy(child.gameObject);
            }
        }
        gameObject.SetActive(false);

        if (_setItemCallback != null)
        {
            _setItemCallback(item);
        }
    }
}
