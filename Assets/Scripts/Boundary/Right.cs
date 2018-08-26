using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Boundary
{
    public class Right : Batas
    {
        public override void CreateBoundary()
        {
            boundaryCollider.size = new Vector2(boundaryWidth, Mathf.Abs(LowerLeft.y) + Mathf.Abs(LowerRight.y) + overhang);
            boundaryCollider.offset = new Vector2(boundaryWidth / 2, 0);
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight / 2, 1));
        }
    }
}
