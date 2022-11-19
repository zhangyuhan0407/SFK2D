using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STGEnemy : MonoBehaviour
{

    int hp;

    // Start is called before the first frame update
    void Start()
    {
        hp = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseHP(int value)
    {
        hp -= value;
        if(hp<=0)
        {
            Destroy(gameObject);
        }
    }
}
