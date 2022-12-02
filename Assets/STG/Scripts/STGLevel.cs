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

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        items = GameObject.FindObjectsOfType<STGItem>();
        foreach(var item in items)
        {
            if(item.type == STGWeaponType.Fist)
            {
                if(player.GetComponent<STGFist>() != null)
                {
                    item.gameObject.SetActive(false);
                }
            }
            else if (item.type == STGWeaponType.Pistol)
            {
                if (player.GetComponent<STGPistol>() != null)
                {
                    item.gameObject.SetActive(false);
                }
            }
            else if (item.type == STGWeaponType.Rifle)
            {
                if (player.GetComponent<STGRifle>() != null)
                {
                    item.gameObject.SetActive(false);
                }
            }
            else if (item.type == STGWeaponType.Shotgun)
            {
                if (player.GetComponent<STGShotGun>() != null)
                {
                    item.gameObject.SetActive(false);
                }
            }
        }
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

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

}
