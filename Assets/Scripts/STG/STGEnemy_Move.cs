using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STGEnemy_Move : MonoBehaviour
{

    public float speed;

    GameObject player;

    Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        speed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }



    void Move()
    {
        Vector2 dir = (player.transform.position - transform.position).normalized;
        rig.velocity = dir * speed;
    }
}
