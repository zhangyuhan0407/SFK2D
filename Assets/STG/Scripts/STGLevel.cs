using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum STGLevelType
{
    Shop,
    Fight,
}


public class STGLevel : MonoBehaviour
{
    public STGItem[] items;

    public STGLevelType type;

    // Start is called before the first frame update
    void Start()
    {
        items = GameObject.FindObjectsOfType<STGItem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OpenPortal()
    {
        foreach(var item in items)
        {
            Destroy(item.gameObject);
        }
    }

}
