using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STGShotGun : MonoBehaviour
{
    public GameObject prefabBullet;

    float cd;

    // Start is called before the first frame update
    void Start()
    {
        prefabBullet = Resources.Load<GameObject>("Prefabs/Bullets/BulletThrowingStar");
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
                cd = 1f;
                Shot();
            }
        }
    }


    void Shot()
    {

        GameObject bullet1 = Instantiate(prefabBullet);
        GameObject bullet2 = Instantiate(prefabBullet);
        GameObject bullet3 = Instantiate(prefabBullet);
        GameObject bullet4 = Instantiate(prefabBullet);

        bullet1.transform.position = gameObject.transform.position;
        bullet2.transform.position = gameObject.transform.position;
        bullet3.transform.position = gameObject.transform.position;
        bullet4.transform.position = gameObject.transform.position;


        bullet1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * 8;
        bullet2.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * 8;
        bullet3.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * 8;
        bullet4.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0) * 8;

    }

}
