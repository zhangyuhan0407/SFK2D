using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFKPlayerFollower : MonoBehaviour
{

    public SFKPlayerController player;
    Rigidbody2D rb;

    public Vector2 deltaPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player").GetComponent<SFKPlayerController>() ;
        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.angularDrag = 0;

        deltaPosition = new Vector2(1, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = player.transform.position;
        Vector3 dest;
        if (player.direction == SFKPlayerController.PlayerFaceDirection.Right)
        {
            dest = new Vector3(pos.x - deltaPosition.x, pos.y + deltaPosition.y, 0);
        }
        else
        {
            dest = new Vector3(pos.x + deltaPosition.x, pos.y + deltaPosition.y, 0);
        }

        rb.velocity = dest - transform.position;
    }






}
