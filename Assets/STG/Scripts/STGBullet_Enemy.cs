using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STGBullet_Enemy : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Destroy(gameObject);
        }

    }
}
