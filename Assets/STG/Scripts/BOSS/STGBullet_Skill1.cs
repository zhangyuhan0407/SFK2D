using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STGBullet_Skill1 : MonoBehaviour
{
    Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        //ani.SetTrigger("Explode");
        Invoke("Explode", 1);
        Destroy(gameObject, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Explode()
    {
        gameObject.AddComponent<STGHurtPlayer>();
    }

}
