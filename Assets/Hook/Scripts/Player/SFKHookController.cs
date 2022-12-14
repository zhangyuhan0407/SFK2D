using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFKHookController : MonoBehaviour
{

    public enum HookState
    {
        Idle,
        Working
    }


    public HookState state;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void EnterState(HookState s)
    {
        state = s;
        switch (s)
        {
            case HookState.Idle:
                gameObject.SetActive(false);
                break;
            case HookState.Working:
                gameObject.SetActive(true);
                break;
        }
    }


}
