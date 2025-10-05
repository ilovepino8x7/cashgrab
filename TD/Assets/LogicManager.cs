using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicManager : MonoBehaviour
{
    public Transform[] path;
    public GameObject[] towers;
    public Transform startPoint;
    public Transform endPoint;
    public int health = 100;
    private int selTower = 0;
    public int dollas = 500;
    public bool menuOpen = false;
    public Animator ani;
    public TMP_Text mon;
    public TMP_Text healthText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ani = GameObject.Find("Menu").GetComponent<Animator>();
        mon = GameObject.FindWithTag("Pounds").GetComponent<TextMeshProUGUI>();
        healthText = GameObject.FindWithTag("Health").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        mon.text = "£" + dollas.ToString();
        healthText.text = health.ToString();
        if (health <= 0)
        {
            SceneManager.LoadScene("LossScreen");
        }
    }
    public GameObject GetSelTower()
    {
        return towers[selTower];
    }
    public void MoMoney(int num)
    {
        dollas += num;
    }
    public bool spendingSpree(int num)
    {
        if (num <= dollas)
        {
            dollas -= num;
            return true;
        }
        else return false;
    }
    public void toggleMenu()
    {
        menuOpen = !menuOpen;
        ani.SetBool("isOpen", menuOpen);
    }
    public void selIce()
    {
        selTower = 1;
    }
    public void selBasic()
    {
        selTower = 0;
    }
    public void loadGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void loadWin()
    {
        SceneManager.LoadScene("WinScreen");
    }
}
