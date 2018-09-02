using UnityEngine;
using System.Collections;
using Assets.Assets;
using Assets.Scripts.Boundary;
using System;

public class ElectricArea : Batas {

    public delegate void TriggerZone(GameObject other);
    public event TriggerZone OnElectricInArea;
    public event TriggerZone OnElectricOffArea;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Tag.Enemy)
            if (OnElectricInArea != null)
                OnElectricInArea(other.gameObject);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == Tag.Enemy)
            if (OnElectricOffArea != null)
                OnElectricOffArea(other.gameObject);
    }
    public override void CreateBoundary()
    {
        boundaryCollider.size = new Vector2(Mathf.Abs(TopLeft.x) + Mathf.Abs(TopRight.x) + overhang, boundaryWidth);
        boundaryCollider.offset = new Vector2(0, -boundaryWidth / 2);
    }
}
