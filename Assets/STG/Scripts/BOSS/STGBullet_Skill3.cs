using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STGBullet_Skill3 : MonoBehaviour
{
    GameObject player;
    GameObject boss;

    float rangeAttack;
    float cd;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss");
        player = GameObject.Find("Player");
        rangeAttack = 1;
        cd = 0;
    }


    // Update is called once per frame
    void Update()
    {
        cd -= Time.deltaTime;
        float dis = (transform.position - player.transform.position).magnitude;

        if(dis < rangeAttack && cd < 0)
        {
            cd = 1;
            Attack();
        }
        else
        {
            Move();
        }
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position,
                                                player.transform.position,
                                                2f * Time.deltaTime);
    }

    void Attack()
    {
        boss.GetComponent<STGBOSS>().hp += 5;
    }

}
