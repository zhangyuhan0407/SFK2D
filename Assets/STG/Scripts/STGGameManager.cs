using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STGGameManager : MonoBehaviour
{
    public static STGGameManager Instance;

    void Awake()
    {
        Instance = this;
    }

    public int l;

    STGPortal[] portals;

    public STGLevel level;

    // Start is called before the first frame update
    void Start()
    {
        l = 1;
        portals = FindObjectsOfType<STGPortal>();
        level = GameObject.FindObjectOfType<STGLevel>();
        ClosePortal();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.level != null)
        {
            if (level.type == STGLevelType.Fight)
            {
                STGEnemy enemy = FindObjectOfType<STGEnemy>();
                if (enemy == null)
                {
                    GameOver();
                }
            }
        }
    }

    public void GameOver()
    {
        this.level = null;
        this.l += 1;
        OpenPortal();
        ClearBullet();
    }

    public void ClearBullet()
    {
        STGBullet[] bullets1 = FindObjectsOfType<STGBullet>();
        STGBullet_Enemy[] bullets2 = FindObjectsOfType<STGBullet_Enemy>();

        foreach(var bullet in bullets1)
        {
            bullet.OnClearRoom();
        }

        foreach (var bullet in bullets2)
        {
            bullet.OnClearRoom();
        }

        STGSliderEnemyHP.Instance.Hide();
    }

    public void OpenPortal()
    {
        Debug.Log("OpenPortal: " + this.l);
        foreach (var por in portals)
        {
            if(this.l == 1)
            {
                por.gameObject.SetActive(por.type == STGPortalType.Shop);
            }
            else if (this.l == 2)
            {
                por.gameObject.SetActive(por.type == STGPortalType.FightNormal);
            }
            else if (this.l == 3)
            {
                por.gameObject.SetActive(por.type == STGPortalType.Shop);
            }
            else if (this.l == 4)
            {
                por.gameObject.SetActive(por.type == STGPortalType.FightElit);
            }
        }
    }

    public void ClosePortal()
    {
        foreach (var por in portals)
        {
            por.gameObject.SetActive(false);
        }
    }

    public void SetLevel(STGLevel l)
    {
        if(this.level != null)
        {
            this.level.DestroySelf();
        }

        this.level = l;
    }

}
