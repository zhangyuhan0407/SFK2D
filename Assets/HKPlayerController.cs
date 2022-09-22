using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HKPlayerController : MonoBehaviour
{

    public enum PlayerState
    {
        Idle,
        OneHook,
        TwoHook,
    }


    public Camera m_Camera;

    public GameObject hook1;
    public GameObject hook2;

    public Rigidbody2D rb;

    LineRenderer liner;

    public int currentPoint;


    public PlayerState state;



    private Vector2 dest;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


        liner = GetComponent<LineRenderer>();
        liner.material = new Material(Shader.Find("Standard"));
        liner.positionCount = 2;

        liner.startWidth = liner.endWidth = 0.1f;
        liner.material.SetColor("_Color", Color.white);
        
        currentPoint = 0 ;

        EnterState(PlayerState.Idle);
        hook1 = Instantiate(Resources.Load("Hook")) as GameObject;
        hook2 = Instantiate(Resources.Load("Hook")) as GameObject;
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (state == PlayerState.Idle)
            {
                HandleHook1();
                EnterState(PlayerState.OneHook);
            }
            else if (state == PlayerState.OneHook)
            {
                HandleHook2();
                EnterState(PlayerState.TwoHook);
            }
        }
        
        if(state == PlayerState.OneHook || state == PlayerState.TwoHook)
        {
            Vector2 playerPosition = transform.position;
            if (state == PlayerState.OneHook)
            {
                rb.velocity = Vector2.ClampMagnitude((dest - playerPosition) * 100000, 3f);
            }
            else if (state == PlayerState.TwoHook)
            {
                rb.velocity = Vector2.ClampMagnitude((dest - playerPosition) * 100000, 10f);
            }
            
        }
        
        if(CheckReachDest())
        {
            if (state != PlayerState.Idle)
            {
                HandleReachDest();
            }
        }
        

        //Debug.DrawRay(transform.position, dest);
        
    }


    public void EnterState(PlayerState s)
    {
        state = s;
        switch(s)
        {
            case PlayerState.Idle:
                rb.velocity = Vector2.zero;
                break;
            default:
                return;
        }
    }



    public void HandleHook1()
    {
        //Vector3 a = m_Camera.WorldToScreenPoint(Input.mousePosition);
        Vector2 mousePosition = m_Camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        //Vector2 a = transform.TransformPoint(Input.mousePosition);
        Vector2 playerPos = transform.position;
        Vector2 delta = mousePosition - playerPos;

        //Debug.Log("mousePosition: " + Input.mousePosition);

        //Debug.Log("mousePosition: " + mousePosition);
        //Debug.Log("playerPos: " + playerPos);
        //Debug.Log("delta: " + delta);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, delta);

        if (hit.collider != null)
        {
            hook1.transform.position = hit.point;
            //liner.SetPosition(currentPoint++, hook1.transform.position);
            //liner.positionCount++;
            //liner.positionCount = 0;

            liner.SetPosition(0, transform.position);
            liner.SetPosition(1, hook1.transform.position);
        }
        else
        {
            //Debug.Log("hit.collider is null");
        }

        HandleDest(hook1.transform.position);

        //rb.velocity = Vector2.zero;
        //Vector2 playerPosition = transform.position;
    }


    private void HandleHook2()
    {
        Vector2 mousePosition = m_Camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        Vector2 playerPos = transform.position;
        Vector2 delta = mousePosition - playerPos;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, delta);

        if (hit.collider != null)
        {
            hook2.transform.position = hit.point;
            //liner.SetPosition(currentPoint++, hook2.transform.position);
            //liner.positionCount++;
            //liner.positionCount = 0;
        }

        Vector2 playerPosition = transform.position;
        Vector2 dir1 = dest - playerPosition;
        Vector2 dir2 = hook2.transform.position - transform.position;
        HandleDest(dir1 + dir2 + playerPosition);
        hook2.transform.position = dest;

        //rb.velocity = Vector2.zero;
        //rb.AddForce((dest - playerPosition) * 50);
    }


    public void aaa()
    {

    }





    public bool CheckReachDest()
    {
        float deltaX = Mathf.Abs(dest.x - transform.position.x);
        float deltaY = Mathf.Abs(dest.y - transform.position.y);
        
        bool ret = false;
        if(deltaX < 0.3f && deltaY < 0.3f)
        {
            ret = true;
        }
        return ret;
    }


    public void HandleReachDest()
    {
        HandleDest(Vector2.zero);
        if (state == PlayerState.OneHook)
        {
            EnterState(PlayerState.Idle);
        }
        else if (state == PlayerState.TwoHook)
        {
            EnterState(PlayerState.Idle);
        }
    }

    
    public void HandleDest(Vector2 a)
    {
        dest = a;
    }


}
