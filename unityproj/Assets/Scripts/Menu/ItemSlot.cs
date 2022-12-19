using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// This controls a UI element which lets you select an item to equip to a vehicle
// 
public abstract class ItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private float _defaultScale;
    
    // Start is called before the first frame update
    void Start()
    {
        _defaultScale = transform.localScale.x;
    }
    
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        transform.localScale = Vector3.one * _defaultScale * 1.1f;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        transform.localScale = Vector3.one * _defaultScale * 1.0f;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        GetSelection();
    }

    protected abstract void GetSelection();
}
