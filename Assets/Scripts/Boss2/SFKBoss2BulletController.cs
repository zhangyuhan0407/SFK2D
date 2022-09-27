using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFKBoss2BulletController : MonoBehaviour
{

    public Vector2 dir;

    // Start is called before the first frame update
    void Start()
    {
        //dir = new Vector2(-3f,0);
        Invoke("Shot", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Shot()
    {
        this.GetComponent<Rigidbody2D>().velocity = dir.normalized * 3;
        Invoke("Clear", 5);
    }


    public void Clear()
    {
        Destroy(gameObject);
    }
}
