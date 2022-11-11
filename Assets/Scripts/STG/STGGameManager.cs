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


    STGPortal[] portals;

    public STGLevel level;

    // Start is called before the first frame update
    void Start()
    {
        portals = FindObjectsOfType<STGPortal>();
        level = GameObject.FindObjectOfType<STGLevel>();
        ClosePortal();
    }

    // Update is called once per frame
    void Update()
    {
        if (level.type == STGLevelType.Fight)
        {
            Debug.Log("GameOver");
            STGEnemy enemy = FindObjectOfType<STGEnemy>();
            if (enemy == null)
            {
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        OpenPortal();
    }


    public void OpenPortal()
    {
        foreach (var por in portals)
        {
            por.gameObject.SetActive(true);
        }
    }

    public void ClosePortal()
    {
        foreach (var por in portals)
        {
            por.gameObject.SetActive(false);
        }
    }
}
