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
    float cdMove = 2;

    Rigidbody2D rig;

    GameObject player;
    public GameObject prefabSkill1;
    public GameObject prefabSkill2;
    public GameObject prefabSkill3;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        cd1 = 1;
        cd2 = 4;
        cd3 = 7;
        cdMove = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cd1 -= Time.deltaTime;
        cd2 -= Time.deltaTime;
        cd3 -= Time.deltaTime;
        cdMove -= Time.deltaTime;

        if(cd1 < 0)
        {
            cd1 = 4;
            StartSkill1();
            return;
        }

        if (cd2 < 0)
        {
            cd2 = 7;
            StartSkill2();
            return;
        }

        if (cd3 < 0)
        {
            cd3 = 10;
            StartSkill3();
            return;
        }

        if(cdMove < 0)
        {
            cdMove = 1f;
            Move();
        }
        
        
    }



    void Move()
    {
        float x = Random.Range(-5f, 5f);
        float y = Random.Range(-3f, 3f);
        Vector2 pos = new Vector2(x, y);
        Vector2 dir = pos - new Vector2(transform.position.x, transform.position.y);
        rig.velocity = dir.normalized * 2f;
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
