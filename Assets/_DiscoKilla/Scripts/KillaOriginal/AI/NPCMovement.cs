using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : CoreNPC
{
    public float speed;

    private void Awake()
    {
        color = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void FixedUpdate()
    {
        if (canMove /*&& canMoveChecker*/)
        {
            Movement();
            if (!hiding) transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            SetHiding();
        }
    }

    public override void Defeated()
    {
        //Instantiate(loot, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        base.Defeated();
    }
}
