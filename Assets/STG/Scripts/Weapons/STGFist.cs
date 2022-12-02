using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STGFist : MonoBehaviour
{
    public GameObject prefabBullet;

    float cd;
    
    // Start is called before the first frame update
    void Start()
    {
        prefabBullet = Resources.Load<GameObject>("Prefabs/Bullets/BulletFist");
    }


    // Update is called once per frame
    void Update()
    {
        cd -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (cd <= 0)
            {
                cd = 1.0f;
                Shot();
            }
        }
    }


    void Shot()
    {
        GameObject bullet = Instantiate(prefabBullet);
        bullet.transform.position = gameObject.transform.position;
        STGEnemy[] enemys = GameObject.FindObjectsOfType<STGEnemy>();
        Vector3 dir = Vector3.zero;
        if (enemys.Length > 0)
        {
            if(enemys[0].transform.position.x < transform.position.x)
            {
                dir.x = -2;
            }
            else
            {
                dir.x = 2;
            }

            if (enemys[0].transform.position.y < transform.position.y)
            {
                dir.y = -1;
            }
            else
            {
                dir.y = 1;
            }
        }
        else
        {
            dir = new Vector2(-1, 0);
        }

        //bullet.transform.position += dir;
    }


}
