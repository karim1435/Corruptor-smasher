using Assets.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Boundary
{
    public class Bottom : Batas
    {
        public override void CreateBoundary()
        {
            boundaryCollider.size = new Vector2(Mathf.Abs(TopLeft.x) + Mathf.Abs(TopRight.x) + overhang, boundaryWidth);
            boundaryCollider.offset = new Vector2(0, -boundaryWidth / 2);
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth / 2, 0, 1));
        }
        void OnTriggerExit2D(Collider2D col)
        {
            Destroy(col.gameObject);
        }
    }
}
