using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
  Equipable, //���� ������ ������
  Consumable, //�Һ�
  Resource //�ڿ�
}

public enum ConsumableType
{ hp }

[System.Serializable] public class ItemConsumable
{
  public ConsumableType type;
  public float value;
}


[CreateAssetMenu(fileName = "Item", menuName = "New Item")]

public class Item : ScriptableObject
{
  [Header("Info")]
  public string itemName;
  public string itemDescription;
  public ItemType type;
  public Sprite itemImage;
    
  [Header("Consumable")]
  public ItemConsumable[] consumables; //�Ծ��� �� �� ȸ�� ���� ȿ�� �ִ°�
}