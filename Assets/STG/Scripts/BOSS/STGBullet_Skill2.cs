using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STGBullet_Skill2 : MonoBehaviour
{

    public GameObject prefabLazer;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 8);
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("Shot", 1);
        Invoke("Shot", 2);
        Invoke("Shot", 3);
        Invoke("Shot", 4);
        Invoke("Shot", 5);
        Invoke("Shot", 6);
    }

    void Shot()
    {
        GameObject lazer = Instantiate(prefabLazer);
        lazer.transform.position = transform.position;
    }


}
