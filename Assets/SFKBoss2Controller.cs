using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFKBoss2Controller : MonoBehaviour
{
    enum SFKState
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

    SFKState state;

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

        cdNormalAttack -= Time.deltaTime;
        cdRush -= Time.deltaTime;
        cdShot -= Time.deltaTime;



        if(Input.GetKeyDown(KeyCode.O))
        {
            EnterState(SFKState.Shotting);
        }

        float dis = Mathf.Abs((player.transform.position - this.transform.position).magnitude);

        //if (dis < disRush)
        //{
        //    if (CheckReadyRush())
        //    {
        //        cdRush = 5f;
        //        EnterState(SFKState.Rushing);
        //        return;
        //    }
        //}


        EnterState(this.state);

        return;




        

        if(dis < disNormalAttack)
        {
            if (CheckReadyNormalAttack())
            {
                EnterState(SFKState.NormalAttacking);
            }
        }
        //else if (dis < disShot)
        //{
        //    if (CheckReadyShotting())
        //    {
        //        EnterState(SFKState.Shotting);
        //    }
        //}
        else if (dis < disRush)
        {
            if (CheckReadyRush())
            {
                EnterState(SFKState.Rushing);
            }
        }
        else
        {
            HandleNormalState();
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            if (this.state == SFKState.Rushing)
            {
                this.EnterState(SFKState.Normal);
            }
            else
            {
                this.HandleTakeDamage(1);
            }
        }
        else if (collision.collider.tag == "Wall")
        {
            //this.EnterState(SFKState.Stunned);
            this.EnterState(SFKState.Normal);
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



    void EnterState(SFKState s)
    {
        //Debug.Log("Last State: " + this.state + " CurrentState: " + s);

        if (state != s)
        {
            switch (state)
            {
                case SFKState.Normal:
                    Debug.Log("Stop Normal");
                    StopCoroutine(HandleNormalState());
                    break;
                case SFKState.NormalAttacking:
                    HandleNormalAttack();
                    break;
                case SFKState.Rushing:
                    Debug.Log("Stop Rush");
                    StopCoroutine(HandleRush());
                    break;
                case SFKState.Shotting:
                    HandleShot();
                    break;
                case SFKState.Rage:
                    HandleRage();
                    break;
                case SFKState.Stunned:
                    HandleStunned();
                    break;
                case SFKState.Dead:
                    HandleDead();
                    break;
            }
        }
        

        this.state = s;
        
        switch (state)
        {
            case SFKState.Normal:
                StartCoroutine(HandleNormalState());
                break;
            case SFKState.NormalAttacking:
                HandleNormalAttack();
                break;
            case SFKState.Rushing:
                StartCoroutine(HandleRush());
                break;
            case SFKState.Shotting:
                StartCoroutine(HandleShot());
                break;
            case SFKState.Rage:
                HandleRage();
                break;
            case SFKState.Stunned:
                HandleStunned();
                break;
            case SFKState.Dead:
                HandleDead();
                break;
        }
    }





    /// <summary>
    /// Skills
    /// </summary>
    ///

    

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
    

    public IEnumerator HandleNormalState()
    {
        while (this.GetComponentInChildren<SpriteRenderer>().color != Color.white)
        {
            this.GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(this.GetComponentInChildren<SpriteRenderer>().color, Color.white, 0.01f);
            yield return new WaitForEndOfFrame();
        }


        float h = 0;
        float v = 0;

        if(isOnGround)
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


    public void HandleNormalAttack()
    {

    }


    public IEnumerator HandleRush()
    {
        rig.velocity = new Vector2(0, 0);

        while (this.GetComponentInChildren<SpriteRenderer>().color != Color.black)
        {
            this.GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(this.GetComponentInChildren<SpriteRenderer>().color, Color.black, 0.01f);
            yield return new WaitForEndOfFrame();
        }
        
        
        //Play Shake Before Animation
        if (player.transform.position.x < transform.position.x)
        {
            rig.velocity = new Vector2(-speedRush, 0);
        }
        else
        {
            rig.velocity = new Vector2(+speedRush, 0);
        }
    }


    public IEnumerator HandleShot()
    {
        while (this.transform.localScale.x > 1.1f)
        {
            this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(1f, 1f, 1f), 0.01f);
            yield return new WaitForEndOfFrame();
        }

        for (int i = 0; i < 7; i++)
        {
            GameObject bullet = Instantiate(prefabBullet, this.transform.position, Quaternion.identity);
            if(i == 0)
            {
                bullet.GetComponent<SFKBoss2BulletController>().dir = new Vector2(-1, 0);
            }
            else if (i == 1)
            {
                bullet.GetComponent<SFKBoss2BulletController>().dir = new Vector2(-1, 0.5f).normalized;
            }
            else if (i == 2)
            {
                bullet.GetComponent<SFKBoss2BulletController>().dir = new Vector2(-1, 1.732f).normalized;
            }
            else if (i == 3)
            {
                bullet.GetComponent<SFKBoss2BulletController>().dir = new Vector2(0, 1);
            }
            else if (i == 4)
            {
                bullet.GetComponent<SFKBoss2BulletController>().dir = new Vector2(1, 1.732f).normalized;
            }
            else if (i == 5)
            {
                bullet.GetComponent<SFKBoss2BulletController>().dir = new Vector2(1, 0.5f).normalized;
            }
            else if (i == 6)
            {
                bullet.GetComponent<SFKBoss2BulletController>().dir = new Vector2(1, 0);
            }
        }

        //yield return new WaitForSeconds(3);
        EnterState(SFKState.Normal);
    }


    public void HandleRage()
    {

    }


    public void HandleStunned()
    {

    }


    public void HandleDead() {
        Destroy(gameObject);
    }
        


    /// <summary>
    /// Private Functions
    /// </summary>
    /// <returns></returns>


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
