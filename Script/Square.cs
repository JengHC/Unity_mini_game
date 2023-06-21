using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public GameObject explosionPrefab;           // 돌이 파괴될 때 폭발 프리팹
    public event System.Action OnStoneDestroyed; // 돌이 파괴될 때 호출되는 이벤트
    public int coin = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Blade")
        {
            GameObject scorecontorl = GameObject.Find("ScoreControl");
            scorecontorl.GetComponent<ScoreControl>().AddScore();
            DestroyStone();
        }
    }

    void DestroyStone()
    {
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
        if (OnStoneDestroyed != null)
        {
            OnStoneDestroyed.Invoke(); // 돌 파괴 이벤트 호출
        }
        Destroy(gameObject); // 돌 오브젝트 파괴
    }
}