using UnityEngine.UI;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int health;
    private Image health1;
    private Image health2;
    private Image health3;
    public Sprite FullHealth;
    public Sprite Halfhealth;
    public Sprite NoHealth;

    private void Start()
    {
        health = 6;
        health1 = transform.GetChild(0).gameObject.GetComponent<Image>();
        health2 = transform.GetChild(1).gameObject.GetComponent<Image>();
        health3 = transform.GetChild(2).gameObject.GetComponent<Image>();
    }
    private void Update()
    {
        switch (health)
        {
            case 1:
                health1.overrideSprite = Halfhealth;
                health2.overrideSprite = NoHealth;
                health3.overrideSprite = NoHealth;
                break;
            case 2:
                health1.overrideSprite = FullHealth;
                health2.overrideSprite = NoHealth;
                health3.overrideSprite = NoHealth;
                break;
            case 3:
                health1.overrideSprite = FullHealth;
                health2.overrideSprite = Halfhealth;
                health3.overrideSprite = NoHealth;
                break;
            case 4:
                health1.overrideSprite = FullHealth;
                health2.overrideSprite = FullHealth;
                health3.overrideSprite = NoHealth;
                break;
            case 5:
                health1.overrideSprite = FullHealth;
                health2.overrideSprite = FullHealth;
                health3.overrideSprite = Halfhealth;
                break;
            case 6:
                health1.overrideSprite = FullHealth;
                health2.overrideSprite = FullHealth;
                health3.overrideSprite = FullHealth;
                break;
        }
    }
}
