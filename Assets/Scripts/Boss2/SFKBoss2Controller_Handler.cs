using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SFKBoss2Controller : MonoBehaviour
{
    
    public IEnumerator HandleNormalState()
    {
        while (this.GetComponentInChildren<SpriteRenderer>().color != Color.white)
        {
            if (this.state != SFKState.Normal)
            {
                yield break;
            }
            this.GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(this.GetComponentInChildren<SpriteRenderer>().color, Color.white, 0.02f);
            yield return new WaitForEndOfFrame();
        }
    }


    public IEnumerator HandleNormalAttack()
    {
        while (this.GetComponentInChildren<SpriteRenderer>().color != Color.cyan)
        {
            if (this.state != SFKState.NormalAttacking)
            {
                yield break;
            }
            this.GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(this.GetComponentInChildren<SpriteRenderer>().color, Color.cyan, 0.02f);
            yield return new WaitForEndOfFrame();
        }

        EnterState(SFKState.Normal);
    }


    public IEnumerator HandleRush()
    {
        rig.velocity = new Vector2(0, 0);

        while (this.GetComponentInChildren<SpriteRenderer>().color != Color.black)
        {
            if (this.state != SFKState.Rushing)
            {
                yield break;
            }
            this.GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(this.GetComponentInChildren<SpriteRenderer>().color, Color.black, 0.02f);
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
        rig.velocity = new Vector2(0, 0);

        GetComponent<Rigidbody2D>().gravityScale = 0;

        while (this.transform.localScale.x > 1.1f)
        {
            if (this.state != SFKState.Shotting)
            {
                yield break;
            }
            this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(1f, 1f, 1f), 0.05f);
            yield return new WaitForEndOfFrame();
        }

        float offset = 0f;
        for (int i = 0; i < 60; i++)
        {
            GameObject bullet = Instantiate(prefabBullet, this.transform.position, Quaternion.identity);
            Vector2 dir = player.transform.position - this.transform.position;
            bullet.GetComponent<SFKBoss2BulletController>().dir = dir;
            offset += 0.5f;
            yield return new WaitForSeconds(0.2f);
        }
        

        yield return new WaitForSeconds(1);

        while (this.transform.localScale.x < 9.9f)
        {
            this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(10f, 10f, 10f), 0.01f);
            yield return new WaitForEndOfFrame();
        }

        GetComponent<Rigidbody2D>().gravityScale = 1;
        EnterState(SFKState.Normal);

    }


    public IEnumerator HandleRage()
    {
        while (this.GetComponentInChildren<SpriteRenderer>().color != Color.red)
        {
            if (this.state != SFKState.Rage)
            {
                yield break;
            }
            this.GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(this.GetComponentInChildren<SpriteRenderer>().color, Color.red, 0.02f);
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(1);
        EnterState(SFKState.Normal);
    }


    public IEnumerator HandleStunned()
    {
        while (this.GetComponentInChildren<SpriteRenderer>().color != Color.gray)
        {
            if (this.state != SFKState.Stunned)
            {
                yield break;
            }
            this.GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(this.GetComponentInChildren<SpriteRenderer>().color, Color.gray, 0.02f);
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(1);
        EnterState(SFKState.Normal);
    }


    public IEnumerator HandleDead()
    {
        while (this.GetComponentInChildren<SpriteRenderer>().color != Color.clear)
        {
            this.GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(this.GetComponentInChildren<SpriteRenderer>().color, Color.clear, 0.02f);
            yield return new WaitForEndOfFrame();
        }

        Destroy(gameObject);
    }


}
