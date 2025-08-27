using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Singleton<Player>
{
    [Header("플레이어 상태")]
    public int attack;
    public int shield;
    public int hp;
    public int critical;
    
    [Header("인벤토리")]
    public UIInventory inventory;
    
    void Update() {
        if (Input.GetMouseButtonDown(0)) //좌클릭 해서 아이템 있는지 읽는거
        {
            Vector3 mousePos = Input.mousePosition; //마우스 화면 좌표 가져옴
            mousePos.z = 10f; // 카메라와 오브젝트 거리
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos); //화면좌표->월드 좌표 변환

            Collider2D hit = Physics2D.OverlapPoint(worldPos); //클릭한 곳에 오브젝트(아이템) 있는지 체크
            if (hit != null) //클릭한 곳에 오브젝트가 있으면
            {
                IObjectItem clickInterface = hit.GetComponent<IObjectItem>(); //클릭한 오브젝트가 아이템 인터페이스를 가지고 있는지 확인
                if (clickInterface != null)
                {
                    Item item = clickInterface.ClickItem(); //아이템 가져와서
                    inventory.AddItem(item); //인벤토리에 아이템 추가
                    clickInterface.DestroyObject();
                }
            }
        }
    }
}
