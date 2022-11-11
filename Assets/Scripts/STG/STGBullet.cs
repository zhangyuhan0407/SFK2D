using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STGBullet : MonoBehaviour
{
    // Start is called before the first frame update
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
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            collision.GetComponent<STGEnemy>().DecreaseHP(1);
        }
        
    }


}
