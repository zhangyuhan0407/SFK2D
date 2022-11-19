using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFKBoss1Controller : MonoBehaviour
{

    public Vector2 originPosition;

    public Rigidbody2D rb;


    public float partolDistance;

    public float speed;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        originPosition = transform.position;
        partolDistance = 3f;


        StartCoroutine(HandlePartol());

    }

    // Update is called once per frame
    void Update()
    {
        if(CheckBossRunOutPartolArea())
        {
            ChangeDirection();
        }
    }


    public IEnumerator HandlePartol()
    {
        while(true)
        {
            ChangeDirection();
            yield return new WaitForSeconds(2f);
        }
    }


    public void ChangeDirection()
    {
        float randomX = Random.Range(-100, 100);
        float randomY = Random.Range(-100, 100);

        rb.velocity = new Vector2(randomX, randomY).normalized * speed;
    }


    public bool CheckBossRunOutPartolArea()
    {
        float deltaX = transform.position.x - originPosition.x;
        float deltaY = transform.position.y - originPosition.y;
        Vector2 a = new Vector2(deltaX, deltaY);
        return a.magnitude > partolDistance;
    }


}
