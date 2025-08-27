using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler //IPointerClickHandler : 월드 오브젝트는 무시하고 해당 슬롯 버튼만 감지함.
{
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI text; //아이템 수량
    UIInventory uiInventory;

    public void Start()
    {
        uiInventory = GetComponentInParent<UIInventory>();
    }

    private Item _item;
    public Item item {
        get { return _item; }
        set {
            _item = value;
            if (_item != null) { //인벤에 아이템이 있다면
                image.sprite = item.itemImage;
                text.text = "1";
                image.color = new Color(1, 1, 1, 1); //이미지 표시
            } else { //빈슬롯이면 화면에 표시x
                image.color = new Color(1, 1, 1, 0);
                text.text = null;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData) //아이템 칸을 클릭했을 때 정보 띄워주기
    {
        uiInventory.selectedSlot = this; //클릭된 슬롯 정보 전달
        uiInventory.ShowItemInfo(_item);
    }
}