using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler //IPointerClickHandler : ���� ������Ʈ�� �����ϰ� �ش� ���� ��ư�� ������.
{
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI text; //������ ����
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
            if (_item != null) { //�κ��� �������� �ִٸ�
                image.sprite = item.itemImage;
                text.text = "1";
                image.color = new Color(1, 1, 1, 1); //�̹��� ǥ��
            } else { //�󽽷��̸� ȭ�鿡 ǥ��x
                image.color = new Color(1, 1, 1, 0);
                text.text = null;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData) //������ ĭ�� Ŭ������ �� ���� ����ֱ�
    {
        uiInventory.selectedSlot = this; //Ŭ���� ���� ���� ����
        uiInventory.ShowItemInfo(_item);
    }
}