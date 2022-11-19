using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum STGWeaponType
{
    Pistol,
    Rifle,
    Shotgun,
    Fist,
}


public class STGItem : MonoBehaviour
{

    public STGItem[] items;

    public STGWeaponType type;

    // Start is called before the first frame update
    void Start()
    {
        items = GameObject.FindObjectsOfType<STGItem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (type)
            {
                case STGWeaponType.Pistol:
                    collision.gameObject.AddComponent<STGPistol>();
                    break;
                case STGWeaponType.Rifle:
                    collision.gameObject.AddComponent<STGRifle>();
                    break;
                case STGWeaponType.Shotgun:
                    collision.gameObject.AddComponent<STGShotGun>();
                    break;
                case STGWeaponType.Fist:
                    collision.gameObject.AddComponent<STGFist>();
                    break;
            }

            foreach(var item in items)
            {
                Destroy(item.gameObject);
            }

            STGGameManager.Instance.OpenPortal();

            //GameObject prefab = Resources.Load<GameObject>("Prefabs/STG/" + key);
            //GameObject obj = Instantiate(prefab);
        }
    }
}
