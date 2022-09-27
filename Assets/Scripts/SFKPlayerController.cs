using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFKPlayerController : MonoBehaviour
{

    public enum PlayerState
    {
        Idle,
        OneHook,
        TwoHook,
    }

    public Rigidbody2D rb;
    public Camera m_Camera;

    public GameObject hook1;
    public GameObject hook2;



    LineRenderer liner;
    public int currentPoint;


    public PlayerState state;


    public GameObject destObj;
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
        currentPoint = 0;

        hook1 = Instantiate(Resources.Load("Hook")) as GameObject;
        hook2 = Instantiate(Resources.Load("Hook")) as GameObject;
        hook1.name = "Hook1";
        hook2.name = "Hook2";
        EnterState(PlayerState.Idle);
    }


    // Update is called once per frame
    void Update()
    {
        
        if (state == PlayerState.OneHook)
        {
            liner.SetPosition(0, transform.position);
            liner.SetPosition(1, hook1.transform.position);

            dest = hook1.transform.position;
            destObj.transform.position = dest;
        }


        if (Input.GetMouseButtonDown(0))
        {
            if (state == PlayerState.Idle)
            {
                HandleHook1();
                EnterState(PlayerState.OneHook);
            }
        }


        if (Input.GetMouseButtonDown(1))
        {
            if (state == PlayerState.OneHook)
            {
                HandleHook2();
                EnterState(PlayerState.TwoHook);
            }
        }


        if (state == PlayerState.OneHook || state == PlayerState.TwoHook)
        {
            Vector2 playerPosition = transform.position;

            if (state == PlayerState.OneHook)
            {
                rb.velocity = (dest - playerPosition).normalized * 3f;
            }
            else if (state == PlayerState.TwoHook)
            {
                rb.velocity = (dest - playerPosition).normalized * 10f;
            }
        }

        if (CheckReachDest())
        {
            if (state != PlayerState.Idle)
            {
                HandleReachDest();
            }
        }

    }


    public void EnterState(PlayerState s)
    {
        state = s;
        switch (s)
        {
            case PlayerState.Idle:
                rb.velocity = Vector2.zero;
                rb.gravityScale = 1;
                hook1.transform.position = transform.position;
                hook2.transform.position = transform.position;
                hook1.SetActive(false);
                hook2.SetActive(false);
                break;
            default:
                rb.gravityScale = 0;
                return;
        }
    }



    public void HandleHook1()
    {
        Vector2 mousePosition = m_Camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        Vector2 playerPos = transform.position;
        Vector2 delta = mousePosition - playerPos;

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, delta);

        foreach (var hit in hits)
        {
            if (hit.collider.tag == "Wall" || hit.collider.tag == "Ground")
            {
                hook1.SetActive(true);
                hook1.transform.position = hit.point;
                hook1.transform.SetParent(hit.collider.transform);

                liner.SetPosition(0, transform.position);
                liner.SetPosition(1, hook1.transform.position);

                HandleDest(hook1.transform.position);

                break;
            }
        }

    }


    private void HandleHook2()
    {
        Vector2 mousePosition = m_Camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        Vector2 playerPos = transform.position;
        Vector2 delta = mousePosition - playerPos;

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, delta);

        foreach (var hit in hits)
        {
            if (hit.collider.tag == "Wall" || hit.collider.tag == "Ground")
            {
                hook2.SetActive(true);
                hook2.transform.position = hit.point;
                hook2.transform.SetParent(hit.collider.transform);

                Vector2 playerPosition = transform.position;
                Vector2 dir1 = dest - playerPosition;
                Vector2 dir2 = hook2.transform.position - transform.position;
                HandleDest((dir1 + dir2 + playerPosition) * 2f);

                break;
            }
        }

    }


    public bool CheckReachDest()
    {
        float deltaX = Mathf.Abs(dest.x - transform.position.x);
        float deltaY = Mathf.Abs(dest.y - transform.position.y);

        bool ret = false;
        if (deltaX < 0.1f && deltaY < 0.1f)
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
        this.dest = a;
        destObj.transform.position = dest;
        destObj.SetActive(a != Vector2.zero);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.name);
        if (this.state != PlayerState.Idle)
        {
            EnterState(PlayerState.Idle);
        }

    }

}
