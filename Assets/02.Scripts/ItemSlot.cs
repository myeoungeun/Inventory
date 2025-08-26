using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public ItemData item;
    
    public Button button;
    public Image icon;
    public TextMeshProUGUI quantityText;
    private Outline outline;
    
    public UIInventory inventory;

    public int index;
    public bool equipped;
    public int quantity;

    public void Set()
    {
        icon.gameObject.SetActive(true);
        icon.sprite = item.icon;
        quantityText.text = quantity > 1 ? quantity.ToString() : string.Empty;

        if (outline != null)
        {
            outline.enabled = equipped;
        }
    }

    public void Clear()
    {
        item = null;
        icon.gameObject.SetActive(false);
        quantityText.text = string.Empty;
    }

    public void OnClickButton() //아이템 클릭하면 정보 나오는 함수
    {
        inventory.SelectItem(index);
    }
}