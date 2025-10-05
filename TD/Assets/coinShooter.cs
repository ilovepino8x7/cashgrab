using UnityEngine;
using UnityEditor;
using System.Net;
using Unity.VisualScripting;

public class coinShooter : MonoBehaviour
{
    public int targetingRange = 3;
    public LayerMask enemyMask;
    private Transform target;
    public GameObject end;
    public spawnBullets spawner;
    public float spawnDelay = 0.5f;
    public float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        end = GameObject.FindGameObjectWithTag("End");
        spawner = transform.GetChild(0).gameObject.GetComponent<spawnBullets>();
        timer = spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        findTarget();
        RotToTarget();
        checkTargetRange();
        if (timer <= 0)
        {
            spawner.spawnCoin();
            timer = spawnDelay;
        }
        else if (target != null)
        {
            timer -= Time.deltaTime;
        }
        
    }
    public void findTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);
        if (hits.Length > 0)
        {
            float ClosestDistance = Mathf.Infinity;
            foreach (RaycastHit2D hit in hits)
            {
                float disToEnd = Vector2.Distance(hit.transform.position, end.transform.position);
                if (disToEnd < ClosestDistance)
                {
                    ClosestDistance = disToEnd;
                    target = hit.transform;
                }
            }
        }
    }
    public void checkTargetRange()
    {
        if (target == null) return;
        if (Vector2.Distance(transform.position, target.position) > targetingRange)
        {
            target = null;
        }
    } 
    public void RotToTarget()
    {
        if (target == null) return;
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRot = Quaternion.Euler(new Vector3(0f, 0f, angle));
        transform.rotation = targetRot;
    }
}
