using UnityEngine;

public class spawnBullets : MonoBehaviour
{
    public GameObject coin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnCoin()
    {
        Instantiate(coin, transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z + 90f));
    }
}
