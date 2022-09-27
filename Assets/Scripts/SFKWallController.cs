using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFKWallController : MonoBehaviour
{

    Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        RandomMove();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void RandomMove()
    {
        if(Random.Range(0, 100) < 50)
        {
            rig.velocity = new Vector2(5, 0);
        }
        else
        {
            rig.velocity = new Vector2(-5, 0);
        }

        Invoke("RandomMove", 2);
    }

}
