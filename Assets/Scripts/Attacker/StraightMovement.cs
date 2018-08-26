using UnityEngine;
using System.Collections;
using Assets.Scripts.Attacker;

public class StraightMovement : Movement {
    private Rigidbody2D body2d;
    protected override void Start()
    {
        body2d = GetComponent<Rigidbody2D>();
        base.Start();
    }
    void FixedUpdate()
    {
        Move();
    }
    private void Move()
	{
        if (canMove)
            body2d.velocity = new Vector2(0,Vector2.down.y * speedMove * Time.deltaTime);
        else
            body2d.velocity = Vector3.zero;
	}
}
