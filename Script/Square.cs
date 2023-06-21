using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public GameObject explosionPrefab;           // ���� �ı��� �� ���� ������
    public event System.Action OnStoneDestroyed; // ���� �ı��� �� ȣ��Ǵ� �̺�Ʈ
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
            OnStoneDestroyed.Invoke(); // �� �ı� �̺�Ʈ ȣ��
        }
        Destroy(gameObject); // �� ������Ʈ �ı�
    }
}