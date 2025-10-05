using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class iceTower : MonoBehaviour
{
    public int targetingRange = 1;
    public LayerMask enemyMask;
    private float timer = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            slowTargets();
            timer = 2f;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
    public void slowTargets()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);
        if (hits.Length > 0)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit2D hit = hits[i];
                EnemyMove EnMo = hit.transform.gameObject.GetComponent<EnemyMove>();
                EnMo.updateSpeed(0);
                Debug.Log("Freeze");
                StartCoroutine(resetEnemySpeed(EnMo));
                Debug.Log("Thaw");
            }
        }
    }
    public IEnumerator resetEnemySpeed(EnemyMove EnMo)
    {
        yield return new WaitForSeconds(0.25f);
        EnMo.resetSpeed();
    }
}