using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFKBagController : MonoBehaviour
{
    public static SFKBagController Instance;

    private void Awake()
    {
        Instance = this;
    }
    
    public List<SFKSlot> slots;

    public List<SFKItem> items;
    
    

    void Start()
    {
        items = new List<SFKItem>();
        slots = new List<SFKSlot>();
    }

    
    void Update()
    {
        
    }
    

    public void AddItem(SFKItem item)
    {
        if (items.Count > slots.Count)
        {
            return;
        }
        this.items.Add(item);
        FindEmptySlot().Accept(item);
        UpdateUI();
    }


    public void UseItem(SFKItem item)
    {
        UpdateUI();
    }
    

    public void UpdateUI()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if(i < items.Count)
            {
                slots[i].Accept(items[i]);
            }
            else
            {
                slots[i].Clear();
            }
        }
    }


    public SFKSlot FindEmptySlot()
    {
        foreach (var slot in slots)
        {
            if (slot.CheckIsEmpty())
            {
                return slot;
            }
        }
        return null;
    }

    
    public void OpenUI()
    {
        this.gameObject.SetActive(true);
    }

    public void CloseUI()
    {
        this.gameObject.SetActive(false);
    }


}
