using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavenStairs : MonoBehaviour
{
    public GameObject player;
    public Transform targetPosition;
    public float speed = 2f;
    public float scaleSpeed = 0.5f; // 스케일 변화 속도
    public float maxScale = 1.5f;  // 최대 확대
    public float minScale = 0.3f;  // 최소 축소
    public float tiltAngle = 15f;  // 최대 기울기
    public float tiltSpeed = 5f;   // 기울기 변화 속도

    public void OnStairBtn()
    {
        StartCoroutine(MovePlayer());
    }

    private IEnumerator MovePlayer()
    {
        Vector3 originalScale = player.transform.localScale;
        Vector3 targetScale = new Vector3(Random.Range(minScale, maxScale), Random.Range(minScale, maxScale), 1f);
        float tiltDirection = 1f; // 기울기 방향
        
        while(Vector3.Distance(player.transform.position, targetPosition.position) > 0.01f)
        {
            //플레이어 이동
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition.position, speed * Time.deltaTime);
            
            //플레이어 크기 변화
            player.transform.localScale = Vector3.Lerp(player.transform.localScale, targetScale, scaleSpeed * Time.deltaTime);

            // 스케일이 거의 도달하면 새 랜덤 값으로 다시 변화
            if(Vector3.Distance(player.transform.localScale, targetScale) < 0.05f)
            {
                targetScale = new Vector3(Random.Range(minScale, maxScale), Random.Range(minScale, maxScale), 1f);
            }
            
            // 좌우 기울기
            float angle = Mathf.Sin(Time.time * tiltSpeed) * tiltAngle; // -tiltAngle ~ +tiltAngle 반복
            player.transform.rotation = Quaternion.Euler(0f, 0f, angle);
            
            yield return null; // 다음 프레임까지 대기
        }
        
        // 이동 완료 후 위치와 스케일 설정
        player.transform.position = targetPosition.position;
        player.transform.localScale = originalScale;
    }
}
