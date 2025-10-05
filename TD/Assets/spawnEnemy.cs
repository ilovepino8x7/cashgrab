using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class spawnEnemy : MonoBehaviour
{
    public float enemyCount;
    public float timer;
    public float[] rounds = { 0, 4, 9, 15, 20, 25};
    public int R = 1;
    public GameObject enemy;
    public Button rCont;
    private bool isRunning = false;
    public LogicManager logic;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        R = 1;
        rCont = GameObject.FindWithTag("ScoreControl").GetComponent<Button>();
        rCont.interactable = true;
        enemyCount = 0;
        logic = GameObject.FindWithTag("Brain").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnEnemies()
    {
        Instantiate(enemy);
        enemyCount += 1;
    }
    public IEnumerator startRound()
    {
        if (isRunning)
        {
            Debug.Log("InProgress");
            yield break;
        }
        isRunning = true;
        rCont.interactable = false;
        if (R >= rounds.Length)
        {
            Debug.Log("Victory");
            logic.loadWin();
            yield break;

        }
        while (enemyCount <= rounds[R])
        {
            SpawnEnemies();
            yield return new WaitForSeconds(2);
        }
        R += 1;
        enemyCount = 0;
        rCont.interactable = true;
        isRunning = false;
        Debug.Log("Round Completed");
    }
    public void beginRound()
    {
        StartCoroutine(startRound());
    }
}
