using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] Image image;

    private Item _item;
    public Item item {
        get { return _item; }
        set {
            _item = value;
            if (_item != null) { //�κ��� �������� �ִٸ�
                image.sprite = item.itemImage;
                image.color = new Color(1, 1, 1, 1); //�̹��� ǥ��
            } else { //�󽽷��̸� ȭ�鿡 ǥ��x
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }
}