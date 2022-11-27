using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STGPistol : MonoBehaviour
{

    public GameObject prefabBullet;

    float cd;

    // Start is called before the first frame update
    void Start()
    {
        prefabBullet = Resources.Load<GameObject>("Prefabs/Bullets/Bullet");
        cd = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cd -= Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.J))
        {
            if(cd <= 0)
            {
                cd = 0.3f;
                Shot();
            }
        }
    }


    void Shot()
    {
        GameObject bullet = Instantiate(prefabBullet);
        bullet.transform.position = gameObject.transform.position;
        STGEnemy[] enemys = GameObject.FindObjectsOfType<STGEnemy>();
        Vector2 dir;
        if(enemys.Length > 0)
        {
            dir = (enemys[0].transform.position - transform.position).normalized;
        }
        else
        {
            dir = new Vector2(-1,0);
        }
        bullet.GetComponent<Rigidbody2D>().velocity = dir * 6;
    }

}
