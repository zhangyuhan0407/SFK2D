using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFKSlot : MonoBehaviour
{

    public SFKItem item;
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    

    public void Accept(SFKItem item)
    {
        this.item = item;
        item.slot = this;
        item.transform.SetParent(this.transform);
        item.transform.localPosition = Vector3.zero;
    }


    public void Clear()
    {
        if(this.item == null)
        {
            return;
        }
        
        this.item.slot = null;
        this.item = null;
    }


    public bool CheckIsEmpty()
    {
        return this.item == null;
    }
    
}
