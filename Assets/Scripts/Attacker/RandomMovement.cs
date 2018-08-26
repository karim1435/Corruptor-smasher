using UnityEngine;
using System.Collections;
using Assets.Scripts.Attacker;

public class RandomMovement :Movement {
    private float maxX;
    private float minX;
    private float maxY;
    private float minY;

    private float tChange = 0.0f; // force new direction in the first Update
    private float randomX;
    private float randomY;
    private int offset=10;
    protected override void Start()
    {
        maxX = GameManager.instance.Right.x;
        minX = GameManager.instance.Left.x;
        maxY = GameManager.instance.Top.y;
        minY = (Screen.height / Camera.main.pixelHeight) / 2 + offset;
        base.Start();
    }
    void Update()
    {
        if (canMove)
        {
            AssignNewRandomPosition();
            ClamPositionByBound();
        }
    }
    private void ClamPositionByBound()
    {
        Vector3 inPos = transform.position;
        inPos.x = Mathf.Clamp(transform.position.x, minX, maxX);
        inPos.y = Mathf.Clamp(transform.position.y, -minY, maxY);
        transform.position = inPos;
    }

    private void AssignNewRandomPosition()
    {
        transform.Translate(RandomPosition() * speedMove * Time.deltaTime*0.5f);

        bool boundXPos = transform.position.x >= maxX || transform.position.x <= minX;
        bool boundYMaxPos = transform.position.y >= maxY;
        bool boundYMinPos = transform.position.y <= minY;

        if (boundXPos)
            randomX = -randomX;
        if (boundYMaxPos)
            randomY = -randomY;
    }

    private Vector3 RandomPosition()
    {
        if (Time.time >= tChange)
        {
            randomX = Random.Range(-2.0f, 2.0f);
            randomY = Random.Range(-2.0f, 2.0f); 
                                                 
            tChange = Time.time + Random.Range(100, 150);
        }
        return new Vector3(randomX, randomY, 0);
    }
}
