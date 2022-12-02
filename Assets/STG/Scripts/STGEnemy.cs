using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STGEnemy : MonoBehaviour
{
    public int maxHP;
    public int hp;

    // Start is called before the first frame update
    void Start()
    {
        if(maxHP == 0)
        {
            maxHP = 3;
            hp = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DecreaseHP(int value)
    {
        hp -= value;
        STGSliderEnemyHP.Instance.SetValue(hp, maxHP);
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
