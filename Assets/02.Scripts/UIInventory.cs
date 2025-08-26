using System;
using TMPro;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.Events;

public class UIInventory : MonoBehaviour
{
    public ItemSlot[] slots;

    public GameObject inventoryWindow;
    public Transform slotPanel;

    [Header("Selected Item")]
    public TextMeshProUGUI selectedItemName;
    public TextMeshProUGUI selectedItemDescription;
    public TextMeshProUGUI selectedItemStatName;
    public TextMeshProUGUI selectedItemStatValue;
    public GameObject useButton;
    public GameObject equipButton;
    public GameObject unEquipButton;
    public GameObject dropButton;
    
    private ItemSlot selectedItem;
    private int selectedItemIndex = 0;

    private int curEquipIndex;
    
    public void SelectItem(int index)
    {
        if (slots[index].item == null) return; //아이템 정보가 없으면 그냥 return

        selectedItem = slots[index];
        selectedItemIndex = index;

        selectedItemName.text = selectedItem.item.displayName; //선택한 아이템 이름
        selectedItemDescription.text = selectedItem.item.description; //설명

        selectedItemStatName.text = string.Empty; //아이템에 무조건 회복 등의 기능이 있진 않으니 일단 empty
        selectedItemStatValue.text = string.Empty;

        for(int i = 0; i< selectedItem.item.consumables.Length; i++) //회복 등의 기능이 있는 아이템이 있다면 실행
        {
            selectedItemStatName.text += selectedItem.item.consumables[i].type.ToString() + "\n";
            selectedItemStatValue.text += selectedItem.item.consumables[i].value.ToString() + "\n";
        }

        useButton.SetActive(selectedItem.item.type == ItemType.Consumable);
        equipButton.SetActive(selectedItem.item.type == ItemType.Equipable && !slots[index].equipped); //아이템 장착
        unEquipButton.SetActive(selectedItem.item.type == ItemType.Equipable && slots[index].equipped); //아이템 해제
        dropButton.SetActive(true);
    }
}
