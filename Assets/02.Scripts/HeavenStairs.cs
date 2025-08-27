using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavenStairs : MonoBehaviour
{
    public GameObject player;
    public Transform targetPosition;
    public float speed = 2f;
    public float scaleSpeed = 0.5f; // ������ ��ȭ �ӵ�
    public float maxScale = 1.5f;  // �ִ� Ȯ��
    public float minScale = 0.3f;  // �ּ� ���
    public float tiltAngle = 15f;  // �ִ� ����
    public float tiltSpeed = 5f;   // ���� ��ȭ �ӵ�

    public void OnStairBtn()
    {
        StartCoroutine(MovePlayer());
    }

    private IEnumerator MovePlayer()
    {
        Vector3 originalScale = player.transform.localScale;
        Vector3 targetScale = new Vector3(Random.Range(minScale, maxScale), Random.Range(minScale, maxScale), 1f);
        float tiltDirection = 1f; // ���� ����
        
        while(Vector3.Distance(player.transform.position, targetPosition.position) > 0.01f)
        {
            //�÷��̾� �̵�
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition.position, speed * Time.deltaTime);
            
            //�÷��̾� ũ�� ��ȭ
            player.transform.localScale = Vector3.Lerp(player.transform.localScale, targetScale, scaleSpeed * Time.deltaTime);

            // �������� ���� �����ϸ� �� ���� ������ �ٽ� ��ȭ
            if(Vector3.Distance(player.transform.localScale, targetScale) < 0.05f)
            {
                targetScale = new Vector3(Random.Range(minScale, maxScale), Random.Range(minScale, maxScale), 1f);
            }
            
            // �¿� ����
            float angle = Mathf.Sin(Time.time * tiltSpeed) * tiltAngle; // -tiltAngle ~ +tiltAngle �ݺ�
            player.transform.rotation = Quaternion.Euler(0f, 0f, angle);
            
            yield return null; // ���� �����ӱ��� ���
        }
        
        // �̵� �Ϸ� �� ��ġ�� ������ ����
        player.transform.position = targetPosition.position;
        player.transform.localScale = originalScale;
    }
}
