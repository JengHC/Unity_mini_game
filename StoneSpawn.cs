using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawn : MonoBehaviour
{
    public GameObject stonePrefab; // �� ������
    public float spawnHeight = 10f; // ���� ������ ����
    public float spawnRange = 5f; // ���� ������ ����
    public int maxStones = 10; // �ִ� �� ����
    public float timeInterval = 1f; // ���� �������� �ð� ����
    private int currentStones = 0; // ���� ������ �� ����

    private void Start()
    {
        StartCoroutine(SpawnStoneRoutine());
    }

    IEnumerator SpawnStoneRoutine()
    {
        while (currentStones < maxStones)
        {
            SpawnStone();
            yield return new WaitForSeconds(timeInterval);
        }
    }

    void SpawnStone()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-spawnRange, spawnRange), spawnHeight);
        GameObject stone = Instantiate(stonePrefab, spawnPosition, Quaternion.identity);
        stone.GetComponent<Square>().OnStoneDestroyed += ReduceStoneCount; // ���� �ı��� �� �� ���� ����
        currentStones++;
    }

    void ReduceStoneCount()
    {
        currentStones--;
    }
}