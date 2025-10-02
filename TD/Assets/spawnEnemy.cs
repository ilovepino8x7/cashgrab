using System;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    public int enemyCount;
    public float timer;
    public int[] rounds = { 0, 4, 9, 19, 34, 49, 69, 84, 109, 139, 199 };
    public int R = 1;
    public float spawnDiff = 4f;
    public GameObject enemy;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        R = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (R == 1 && enemyCount <= rounds[R])
        {
            if (timer <= 0)
            {
                SpawnEnemies();
                timer = spawnDiff;
            }
            timer -= Time.deltaTime;
        }
    }
    public void SpawnEnemies()
    {
        Instantiate(enemy);
        enemyCount += 1;
    }
}
