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
{
  Health,
  Hunger
}

[System.Serializable] public class ItemDataConsumable
{
  public ConsumableType type;
  public float value;
}


[CreateAssetMenu(fileName = "Item", menuName = "New Item")]

public class ItemData : ScriptableObject
{
  [Header("Info")]
  public string displayName;
  public string description;
  public ItemType type;
  public Sprite icon;

  [Header("Stacking")]
  public bool canStack; //여러개 가질 수 있는지
  public int maxStackAmount; //얼마나 가질 수 있는지
    
  [Header("Consumable")]
  public ItemDataConsumable[] consumables; //먹었을 때 피 회복 등의 효과 주는거
    
  [Header("Equip")]
  public GameObject equipPrefab;
}