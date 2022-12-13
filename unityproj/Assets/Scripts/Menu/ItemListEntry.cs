using System;
using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ItemListEntry : MonoBehaviour
{
    public EquippableItem Item;
    
    public Image icon;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI weightText;
    public Image background;

    private Button _button;
    private ItemSelector _parent;

    public void Initialize(EquippableItem item, int index, ItemSelector parent)
    {
        Item = item;
        _parent = parent;
        nameText.text = Item.itemName;
        weightText.text = Item.weight.ToString();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClick()
    {
        _parent.Select(Item);
    }
}
