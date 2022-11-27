using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum STGPortalType
{
    FightNormal,
    FightElit,
    Shop,
}


public class STGPortal : MonoBehaviour
{
    
    public STGPortalType type = STGPortalType.FightElit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        string key = "";
        if(collision.CompareTag("Player"))
        {
            switch(type)
            {
                case STGPortalType.FightNormal:
                    key = "LevelFightNormal";
                    break;
                case STGPortalType.FightElit:
                    key = "LevelFightElit";
                    break;
                case STGPortalType.Shop:
                    key = "LevelShop";
                    break;
            }

            
            GameObject prefab = Resources.Load<GameObject>("Prefabs/Levels/" + key);
            GameObject obj = Instantiate(prefab);
            STGGameManager.Instance.level = obj.GetComponent<STGLevel>();
            STGGameManager.Instance.ClosePortal();
        }

    }

}
