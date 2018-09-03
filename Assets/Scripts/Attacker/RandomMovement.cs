using UnityEngine;
using System.Collections;
using Assets.Scripts.Attacker;

public class RandomMovement :Movement {

    private float maxX;
    private float minX;
    private float maxY;
    private float minY;

    private float tChange = 0.0f; 

    private float randomX;
    private float randomY;

    private int offset=10;
    protected override void Start()
    {
        SetupBoundary();
        base.Start();
    }

    private void SetupBoundary()
    {
        maxX = GameManager.Instance.RightBound.x;
        minX = GameManager.Instance.LeftBound.x;
        maxY = GameManager.Instance.TopBound.y;
        minY = (Screen.height / Camera.main.pixelHeight) / 2 + offset;
    }

    void FixedUpdate()
    {
        if (canMove)
            AssignNewRandomPosition();
        ClamPositionByBound();
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
        transform.Translate(RandomPosition * speedMove * Time.deltaTime * 0.5f);
        CheckIfIsTouchingBound();
    }

    private void CheckIfIsTouchingBound()
    {
        bool boundXPos = transform.position.x >= maxX || transform.position.x <= minX;
        bool boundYMaxPos = transform.position.y >= maxY;
        bool boundYMinPos = transform.position.y <= minY;

        if (boundXPos)
            randomX = -randomX;
        if (boundYMaxPos)
            randomY = -randomY;
    }

    private Vector3 RandomPosition
    {
        get
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
}
