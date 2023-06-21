using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawn : MonoBehaviour
{
    public GameObject stonePrefab; // 돌 프리팹
    public float spawnHeight = 10f; // 돌이 생성될 높이
    public float spawnRange = 5f; // 돌이 생성될 범위
    public int maxStones = 10; // 최대 돌 개수
    public float timeInterval = 1f; // 돌이 떨어지는 시간 간격
    private int currentStones = 0; // 현재 생성된 돌 개수

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
        stone.GetComponent<Square>().OnStoneDestroyed += ReduceStoneCount; // 돌이 파괴될 때 돌 개수 감소
        currentStones++;
    }

    void ReduceStoneCount()
    {
        currentStones--;
    }
}