using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum SFKItemType
{

}

public class SFKItem : MonoBehaviour
{

    public string key;

    public SFKItemType type;

    public SFKSlot slot;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    

    public static SFKItem Create(SFKItemType type)
    {
        string key = "";
        switch (type)
        {
            
        }

        GameObject prefab = Resources.Load<GameObject>("Prefab/Items/Icon_" + key);
        GameObject obj = Instantiate(prefab);

        SFKItem ret = obj.GetComponent<SFKItem>();
        ret.type = type;

        return ret;
    }
    

    public bool Use()
    {
        return true;
    }
    
    
    public void Clear()
    {
        Destroy(gameObject);
    }
    
}
