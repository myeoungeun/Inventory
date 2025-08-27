using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Singleton<Player>
{
    [Header("�÷��̾� ����")]
    public int attack;
    public int shield;
    public int hp;
    public int critical;
    
    [Header("�κ��丮")]
    public UIInventory inventory;
    
    void Update() {
        if (Input.GetMouseButtonDown(0)) //��Ŭ�� �ؼ� ������ �ִ��� �д°�
        {
            Vector3 mousePos = Input.mousePosition; //���콺 ȭ�� ��ǥ ������
            mousePos.z = 10f; // ī�޶�� ������Ʈ �Ÿ�
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos); //ȭ����ǥ->���� ��ǥ ��ȯ

            Collider2D hit = Physics2D.OverlapPoint(worldPos); //Ŭ���� ���� ������Ʈ(������) �ִ��� üũ
            if (hit != null) //Ŭ���� ���� ������Ʈ�� ������
            {
                IObjectItem clickInterface = hit.GetComponent<IObjectItem>(); //Ŭ���� ������Ʈ�� ������ �������̽��� ������ �ִ��� Ȯ��
                if (clickInterface != null)
                {
                    Item item = clickInterface.ClickItem(); //������ �����ͼ�
                    inventory.AddItem(item); //�κ��丮�� ������ �߰�
                    clickInterface.DestroyObject();
                }
            }
        }
    }
}
