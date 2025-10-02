using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public LogicManager logic;
    private int pathNum = 0;
    private Transform target;
    public Rigidbody2D rb;
    public int moveSpeed = 90;
    public GameObject end;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Brain").GetComponent<LogicManager>();
        target = logic.path[pathNum];
        rb = GetComponent<Rigidbody2D>();
        end = GameObject.FindGameObjectWithTag("End");

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) <= 0.1f)
        {
            pathNum += 1;
            if (pathNum == logic.path.Length)
            {
                target = end.transform;

            }
            else if (target == end.transform)
            {
                logic.health -= 5;
                Destroy(gameObject);
            }
            target = logic.path[pathNum];
            
        }



    }

    void FixedUpdate()
    {
        Vector2 dir = (target.position - transform.position).normalized;
        rb.linearVelocity = dir * moveSpeed * Time.deltaTime;
    }
}
