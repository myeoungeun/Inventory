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
        if (slots[index].item == null) return; //������ ������ ������ �׳� return

        selectedItem = slots[index];
        selectedItemIndex = index;

        selectedItemName.text = selectedItem.item.displayName; //������ ������ �̸�
        selectedItemDescription.text = selectedItem.item.description; //����

        selectedItemStatName.text = string.Empty; //�����ۿ� ������ ȸ�� ���� ����� ���� ������ �ϴ� empty
        selectedItemStatValue.text = string.Empty;

        for(int i = 0; i< selectedItem.item.consumables.Length; i++) //ȸ�� ���� ����� �ִ� �������� �ִٸ� ����
        {
            selectedItemStatName.text += selectedItem.item.consumables[i].type.ToString() + "\n";
            selectedItemStatValue.text += selectedItem.item.consumables[i].value.ToString() + "\n";
        }

        useButton.SetActive(selectedItem.item.type == ItemType.Consumable);
        equipButton.SetActive(selectedItem.item.type == ItemType.Equipable && !slots[index].equipped); //������ ����
        unEquipButton.SetActive(selectedItem.item.type == ItemType.Equipable && slots[index].equipped); //������ ����
        dropButton.SetActive(true);
    }
}
