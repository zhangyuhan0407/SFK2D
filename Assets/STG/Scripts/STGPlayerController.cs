using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STGPlayerController : MonoBehaviour
{
    public float speed;

    Rigidbody2D rig;
    Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3;
        rig = GetComponent<Rigidbody2D>();
        ani= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    public void Move()
    {
        Vector2 dir = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
        }

        transform.position = new Vector2(transform.position.x + dir.x * speed * Time.deltaTime, transform.position.y + dir.y * speed * Time.deltaTime); 
        //transform.position = transform.position + dir * speed * Time.deltaTime;

        if(dir.magnitude == 0)
        {
            ani.SetBool("Move", true);
        }
        else
        {
            ani.SetBool("Move", false);
        }
    }


}
