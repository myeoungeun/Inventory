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
            if (_item != null) { //인벤에 아이템이 있다면
                image.sprite = item.itemImage;
                image.color = new Color(1, 1, 1, 1); //이미지 표시
            } else { //빈슬롯이면 화면에 표시x
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }
}