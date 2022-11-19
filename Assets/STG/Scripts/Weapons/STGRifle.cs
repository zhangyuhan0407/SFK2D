using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STGRifle : MonoBehaviour
{
    public GameObject prefabBullet;

    float cd;

    // Start is called before the first frame update
    void Start()
    {
        prefabBullet = Resources.Load<GameObject>("Prefabs/STG/Bullets/Bullet");
        cd = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cd -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (cd <= 0)
            {
                cd = 0.7f;
                Shot();
            }
        }
    }


    void Shot()
    {
        Invoke("ShotOne", 0.0f);
        Invoke("ShotOne", 0.1f);
        Invoke("ShotOne", 0.2f);
    }


    void ShotOne()
    {
        GameObject bullet = Instantiate(prefabBullet);
        bullet.transform.position = gameObject.transform.position;
        STGEnemy[] enemys = GameObject.FindObjectsOfType<STGEnemy>();
        Vector2 dir;
        if (enemys.Length > 0)
        {
            dir = (enemys[0].transform.position - transform.position).normalized;
        }
        else
        {
            dir = new Vector2(-1, 0);
        }
        bullet.GetComponent<Rigidbody2D>().velocity = dir * 8;
    }
}