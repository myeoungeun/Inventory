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
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI shieldText;
    public bool equipped = false;
    public GameObject equippedItem;

#if UNITY_EDITOR
    private void OnValidate() {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }
#endif

    void Awake() {
        FreshSlot();
        TextClear();
        MaxInventoryTxt.text = slots.Length.ToString();
        CurrentInventoryTxt.text = items.Count.ToString(); //시작할 때 가지고 있는 아이템 개수 반영
        
    }

    public void FreshSlot() { //슬롯 UI를 리스트 상태와 동기화
        int i = 0;
        for (; i < items.Count && i < slots.Length; i++) {
            slots[i].item = items[i];
        }
        for (; i < slots.Length; i++) {
            slots[i].item = null;
        }
    }

    public void AddItem(Item _item) { //아이템 추가
        if (items.Count < slots.Length) {
            items.Add(_item);
            FreshSlot();
            CurrentInventoryTxt.text = items.Count.ToString(); //현재 아이템 개수 반영
        } else {
            print("슬롯이 가득 차 있습니다.");
        }
    }

    public void TextClear() //화면에 띄워주는 텍스트/버튼 초기화
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
            
            Debug.Log($"슬롯 클릭: {item.itemName}");
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
    
    public void OnClickThrowButton() //아이템 버리기
    {
        if(selectedSlot != null && selectedSlot.item != null)
        {
            items.Remove(selectedSlot.item); // 리스트에서 제거
            selectedSlot.item = null;        // 슬롯 비우기
            FreshSlot();
            TextClear();
            CurrentInventoryTxt.text = items.Count.ToString(); // 개수 갱신
            selectedSlot = null;             // 선택 초기화
        }
    }

    public void UseItem() //아이템 사용
    {
        if(selectedSlot != null && selectedSlot.item != null)
        {
            Player.Instance.hp += selectedSlot.item.consumables[0].value;
            hpText.text = Player.Instance.hp.ToString(); //상태창 UI 반영
            OnClickThrowButton();
        }
    }

    public void EquipItem() //아이템 장착
    {
        if (!equipped)
        {
            Player.Instance.shield += selectedSlot.item.shield;
            shieldText.text = Player.Instance.shield.ToString();
            equipped = true;
            equippedItem.SetActive(true);
        }
    }

    public void UnEquipItem() //아이템 장착 해제
    {
        if (equipped) //장착상태일 때만 해제 가능
        {
            Player.Instance.shield -= selectedSlot.item.shield;
            shieldText.text = Player.Instance.shield.ToString();
            equipped = false;
            equippedItem.SetActive(false);
        }
    }
}
