using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STGBOSS : MonoBehaviour
{

    enum State
    {
        Move,
        Skill1,
        Skill2,
        Skill3,
        Dead,
    }

    float cd1;
    float cd2;
    float cd3;


    GameObject player;
    public GameObject prefabSkill1;
    public GameObject prefabSkill2;
    public GameObject prefabSkill3;

    public int hp;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        cd1 = 1000;
        cd2 = 10000;
        cd3 = 1;
    }

    // Update is called once per frame
    void Update()
    {
        cd1 -= Time.deltaTime;
        cd2 -= Time.deltaTime;
        cd3 -= Time.deltaTime;

        if(cd1 < 0)
        {
            cd1 = 7;
            StartSkill1();
            return;
        }

        if (cd2 < 0)
        {
            cd2 = 10;
            StartSkill2();
            return;
        }

        if (cd3 < 0)
        {
            cd3 = 25;
            StartSkill3();
            return;
        }


        Move();

    }



    void Move()
    {
    
    }


    void StartSkill1()
    {
        GameObject skill1 = Instantiate(prefabSkill1);
        skill1.transform.position = player.transform.position;


    }


    void StartSkill2()
    {
        GameObject skill2 = Instantiate(prefabSkill2);
        skill2.transform.position = new Vector2(transform.position.x, transform.position.y + 1);
    }


    void StartSkill3()
    {
        for(int i = 0;i < 5;i++)
        {
            GameObject skill3 = Instantiate(prefabSkill3);
            float x = Random.Range(-5f, 5f);
            float y = Random.Range(-5f, 5f);
            skill3.transform.position = new Vector2(transform.position.x + x, transform.position.y + y);
        }
    }




}
