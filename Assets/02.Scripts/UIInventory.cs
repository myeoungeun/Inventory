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

    [SerializeField]
    private Transform slotParent; //Bag
    [SerializeField]
    private Slot[] slots;

    public TextMeshProUGUI CurrentInventoryTxt;
    public TextMeshProUGUI MaxInventoryTxt;

#if UNITY_EDITOR
    private void OnValidate() {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }
#endif

    void Awake() {
        FreshSlot();
        MaxInventoryTxt.text = slots.Length.ToString();
        CurrentInventoryTxt.text = items.Count.ToString(); //������ �� ������ �ִ� ������ ���� �ݿ�
        
    }

    public void FreshSlot() { //������â �ʱ�ȭ
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
}
