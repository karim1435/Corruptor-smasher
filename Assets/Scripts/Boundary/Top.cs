using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Boundary
{
    public class Top : Batas
    {
        public override void CreateBoundary()
        {
            boundaryCollider.size = new Vector2(Mathf.Abs(TopLeft.x) + Mathf.Abs(TopRight.x) + overhang, boundaryWidth);
            boundaryCollider.offset = new Vector2(0, boundaryWidth / 2);
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight, 1));
        }
    }
}
