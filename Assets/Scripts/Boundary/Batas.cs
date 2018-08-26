using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Boundary
{
    public abstract class Batas : MonoBehaviour
    {
        protected BoxCollider2D boundaryCollider;
        protected float boundaryWidth = 0.8f;
        protected float overhang = 1.0f;
        void Start()
        {
            boundaryCollider = GetComponent<BoxCollider2D>();
            CreateBoundary();
        }
        public Vector3 TopLeft
        {
            get
            {
                return Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0));
            }
        }
        public Vector3 TopRight
        {
            get
            {
                return Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0));
            }
        }
        public Vector3 LowerLeft
        {
            get
            {
                return Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
            }
        }
        public Vector3 LowerRight
        {
            get
            {
                return Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0));
            }
        }
        public abstract void CreateBoundary();
    }
}
