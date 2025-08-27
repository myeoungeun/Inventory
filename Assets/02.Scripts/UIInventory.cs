using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public List<Item> items;

    [SerializeField] private Transform slotParent; //Bag
    [SerializeField] private Slot[] slots;

    public TextMeshProUGUI CurrentInventoryTxt;
    public TextMeshProUGUI MaxInventoryTxt;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescription;
    public TextMeshProUGUI StatName;
    public TextMeshProUGUI StatValue;
    public Button UseButton;
    public Button EquipButton;
    public Button UnEquipButton;
    public Button ThrowButton;
    public Slot selectedSlot;

#if UNITY_EDITOR
    private void OnValidate() {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }
#endif

    void Awake() {
        FreshSlot();
        TextClear();
        MaxInventoryTxt.text = slots.Length.ToString();
        CurrentInventoryTxt.text = items.Count.ToString(); //������ �� ������ �ִ� ������ ���� �ݿ�
        
    }

    public void FreshSlot() { //���� UI�� ����Ʈ ���¿� ����ȭ
        int i = 0;
        for (; i < items.Count && i < slots.Length; i++) {
            slots[i].item = items[i];
        }
        for (; i < slots.Length; i++) {
            slots[i].item = null;
        }
    }

    public void AddItem(Item _item) { //������ �߰�
        if (items.Count < slots.Length) {
            items.Add(_item);
            FreshSlot();
            CurrentInventoryTxt.text = items.Count.ToString(); //���� ������ ���� �ݿ�
        } else {
            print("������ ���� �� �ֽ��ϴ�.");
        }
    }

    public void TextClear() //ȭ�鿡 ����ִ� �ؽ�Ʈ/��ư �ʱ�ȭ
    {
        itemName.text = "";
        itemDescription.text = "";
        StatName.text = "";
        StatValue.text = "";
        UseButton.gameObject.SetActive(false);
        EquipButton.gameObject.SetActive(false);
        UnEquipButton.gameObject.SetActive(false);
        ThrowButton.gameObject.SetActive(false);
    }

    public void ShowItemInfo(Item item)
    {
        TextClear();
        if (item != null) {
            itemName.text = item.itemName;
            itemDescription.text = item.itemDescription;
            ThrowButton.gameObject.SetActive(true);
            
            Debug.Log($"���� Ŭ��: {item.itemName}");
            if (item.type == ItemType.Equipable)
            {
                EquipButton.gameObject.SetActive(true);
                UnEquipButton.gameObject.SetActive(true);
            }
            if (item.type == ItemType.Consumable)
            {
                StatName.text = item.consumables[0].type.ToString();
                StatValue.text = item.consumables[0].value.ToString();
                UseButton.gameObject.SetActive(true);
            }
        }
    }
    
    public void OnClickThrowButton()
    {
        if(selectedSlot != null && selectedSlot.item != null)
        {
            items.Remove(selectedSlot.item); // ����Ʈ���� ����
            selectedSlot.item = null;        // ���� ����
            FreshSlot();
            TextClear();
            CurrentInventoryTxt.text = items.Count.ToString(); // ���� ����
            selectedSlot = null;             // ���� �ʱ�ȭ
        }
    }
}
