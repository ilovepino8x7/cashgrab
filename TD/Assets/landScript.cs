using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class landScript : MonoBehaviour
{
    public GameObject tower;
    public SpriteRenderer sp;
    public Color scolour = (Color)new Color32(25, 118, 15, 255);

    public Color hcolour = Color.gray;
    public LogicManager logic;
    public AudioSource AuSo;
    public AudioClip clip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindWithTag("Brain").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseEnter()
    {
        sp.color = hcolour;
    }
    private void OnMouseExit()
    {
        sp.color = scolour;
    }
    private void OnMouseDown()
    {
        if (tower != null) return;
        if (logic.GetSelTower() == logic.towers[0])
        {
            GameObject towerToMake = logic.GetSelTower();
            if (logic.spendingSpree(200) == true)
            {
                tower = Instantiate(towerToMake, transform.position, Quaternion.identity);
                AuSo.PlayOneShot(clip);
            }
            else return;
        }
        if (logic.GetSelTower() == logic.towers[1])
        {
            GameObject towerToMake = logic.GetSelTower();
            if (logic.spendingSpree(500) == true)
            {
                tower = Instantiate(towerToMake, transform.position, Quaternion.identity);
                AuSo.PlayOneShot(clip);
            }
        }
    }
}
