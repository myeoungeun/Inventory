using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
  Equipable, //장착 가능한 아이템
  Consumable, //소비
  Resource //자원
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
  public ItemConsumable[] consumables; //먹었을 때 피 회복 등의 효과 주는거
}