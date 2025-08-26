using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavenStairs : MonoBehaviour
{
    public GameObject player;
    public GameObject targetPosition;

    public void OnStairBtn()
    {
        player.transform.position = Vector3.MoveTowards(gameObject.transform.position,targetPosition.transform.position, 1f);        
    }
}
