using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public LogicManager logic;
    private int pathNum = 0;
    private Transform target;
    public Rigidbody2D rb;
    private int moveSpeed = 70;
    public GameObject end;
    private int baseSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Brain").GetComponent<LogicManager>();
        target = logic.path[pathNum];
        rb = GetComponent<Rigidbody2D>();
        end = GameObject.FindGameObjectWithTag("End");
        baseSpeed = moveSpeed;

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
                logic.health -= 10;
                Destroy(gameObject);
            }
            if (pathNum < logic.path.Length)
            {
                target = logic.path[pathNum];
            }

        }



    }

    void FixedUpdate()
    {
        Vector2 dir = (target.position - transform.position).normalized;
        rb.linearVelocity = dir * moveSpeed * Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ayo")
        {
            logic.MoMoney(20);
            Destroy(other.gameObject);
            Destroy(transform.gameObject);
        }
    }
    public void updateSpeed(int speed)
    {
        moveSpeed = speed;
    }
    public void resetSpeed()
    {
        moveSpeed = baseSpeed;
    }
}
