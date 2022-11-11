using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class SFKBoss2Controller : MonoBehaviour
{
    public enum SFKState
    {
        Normal,
        NormalAttacking,
        Rushing,
        Shotting,
        Rage,
        Stunned,
        Dead
    }

    [HideInInspector]
    public GameObject player;
    [HideInInspector]
    public Rigidbody2D rig;
    [HideInInspector]
    public GameObject prefabBullet;

    public SFKState state;

    public bool isOnGround;

    public int maxHP;
    public int hp;


    public float speedMove;
    public float speedRush;


    public float cdRush;
    public float cdShot;
    public float cdNormalAttack;


    public float disNormalAttack;
    public float disShot;
    public float disRush;




    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        rig = GetComponent<Rigidbody2D>();

        this.state = SFKState.Normal;
        cdRush = 3f;
        isOnGround = false;

        prefabBullet = Resources.Load("Prefabs/Boss2_Bullet") as GameObject;
    }



    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    EnterState(SFKState.Shotting);
        //}

        
        //    return;

        cdNormalAttack -= Time.deltaTime;
        cdRush -= Time.deltaTime;
        cdShot -= Time.deltaTime;

        
        if (this.state != SFKState.Normal)
        {
            return;
        }
        

        float dis = Mathf.Abs(player.transform.position.x - this.transform.position.x);


        if (dis < disRush)
        {
            if (CheckReadyRush())
            {
                cdRush = 30f;
                EnterState(SFKState.Rushing);
                return;
            }
        }

        if (dis < disShot)
        {
            if (CheckReadyShotting())
            {
                cdShot = 20;
                EnterState(SFKState.Shotting);
                return;
            }
        }

        if (dis < disNormalAttack)
        {
            if(CheckReadyNormalAttack())
            {
                cdNormalAttack = 0;
                EnterState(SFKState.NormalAttacking);
                return;
            } 
        }
        
        Move();
        
    }






    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            if (this.state == SFKState.Rushing)
            {
                this.EnterState(SFKState.Rage);
            }
            else
            {
                this.HandleTakeDamage(1);
            }
        }
        else if (collision.collider.tag == "Wall")
        {
            if(this.state == SFKState.Rushing)
            {
                this.EnterState(SFKState.Stunned);
            }
        }
        else if (collision.collider.tag == "Ground")
        {
            isOnGround = true;
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isOnGround = false;
        }
    }



    public void HandleHurtPlayer()
    {
        //player.GetComponent<PlayerController>().HandleTakeDamage(1);
    }


    public void HandleTakeDamage(int value)
    {
        this.hp -= value;
        if (this.hp <= 0)
        {
            EnterState(SFKState.Dead);
        }
    }

    public void Move()
    {
        float h = 0;
        float v = 0;

        if (isOnGround)
        {
            if (player.transform.position.x < transform.position.x)
            {
                h = -speedMove; v = 0f;
            }
            else
            {
                h = speedMove; v = 0f;
            }
        }
        else
        {
            h = 0f; v = rig.velocity.y;
        }

        rig.velocity = new Vector2(h, v);
    }



    void EnterState(SFKState s)
    {
        /*
        if (state != s)
        {
            switch (state)
            {
                case SFKState.Normal:
                    StopCoroutine(HandleNormalState());
                    break;
                case SFKState.NormalAttacking:
                    StopCoroutine(HandleNormalAttack());
                    break;
                case SFKState.Rushing:
                    StopCoroutine(HandleRush());
                    break;
                case SFKState.Shotting:
                    StopCoroutine(HandleShot());
                    break;
                case SFKState.Rage:
                    StopCoroutine(HandleRage());
                    break;
                case SFKState.Stunned:
                    StopCoroutine(HandleStunned());
                    break;
                case SFKState.Dead:
                    StopCoroutine(HandleDead());
                    break;
            }

            Debug.Log("Last State: " + state + "\tEnter State: " + s);
            this.state = s;
            
            switch (s)
            {
                case SFKState.Normal:
                    StartCoroutine(HandleNormalState());
                    break;
                case SFKState.NormalAttacking:
                    StartCoroutine(HandleNormalAttack());
                    break;
                case SFKState.Rushing:
                    StartCoroutine(HandleRush());
                    break;
                case SFKState.Shotting:
                    StartCoroutine(HandleShot());
                    break;
                case SFKState.Rage:
                    StartCoroutine(HandleRage());
                    break;
                case SFKState.Stunned:
                    StartCoroutine(HandleStunned());
                    break;
                case SFKState.Dead:
                    StartCoroutine(HandleDead());
                    break;
            }
        }

        */

        this.state = s;

        switch (s)
        {
            case SFKState.Normal:
                StartCoroutine(HandleNormalState());
                break;
            case SFKState.NormalAttacking:
                StartCoroutine(HandleNormalAttack());
                break;
            case SFKState.Rushing:
                StartCoroutine(HandleRush());
                break;
            case SFKState.Shotting:
                StartCoroutine(HandleShot());
                break;
            case SFKState.Rage:
                StartCoroutine(HandleRage());
                break;
            case SFKState.Stunned:
                StartCoroutine(HandleStunned());
                break;
            case SFKState.Dead:
                StartCoroutine(HandleDead());
                break;
        }

    }
    

    private bool CheckReadyRush()
    {
        return cdRush <= 0;
    }
    
    private bool CheckReadyShotting()
    {
        return cdShot <= 0;
    }
    
    private bool CheckReadyNormalAttack()
    {
        return cdNormalAttack <= 0;
    }
    
}
