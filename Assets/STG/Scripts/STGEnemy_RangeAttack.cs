using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STGEnemy_RangeAttack : MonoBehaviour
{
    public GameObject player;
    public GameObject prefabBullet;

    float cd;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        prefabBullet = Resources.Load<GameObject>("Prefabs/Bullets/BulletEnemy");
        cd = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cd -= Time.deltaTime;
        if(cd < 0)
        {
            Attack();
            cd = Random.Range(0.5f,1.5f);
        }
    }


    void Attack()
    {
        GameObject bullet = Instantiate(prefabBullet);
        bullet.transform.position = transform.position;
        Vector2 dir = (player.transform.position - transform.position).normalized;
        bullet.GetComponent<Rigidbody2D>().velocity = dir * 2f;
    }
}
