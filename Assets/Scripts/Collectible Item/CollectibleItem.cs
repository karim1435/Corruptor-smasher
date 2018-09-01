using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Defender;

namespace Assets.Scripts.Collectible_Item
{
    public abstract class CollectibleItem:MonoBehaviour
    {
        [SerializeField]
        protected float speedMove = 100;
        [SerializeField]
        protected float bonus;
        protected Text infoBonusText;

        private Rigidbody2D body2d;
        protected virtual void Start()
        {
            body2d = GetComponent<Rigidbody2D>();
        }
        void Update()
        {
            body2d.velocity = new Vector2(0, Vector2.down.y * speedMove * Time.deltaTime);
        }
        void OnMouseDown()
        {
            GiveExtraBonus();
            Destroy(gameObject);
        }
        protected abstract void GiveExtraBonus();
    }
}
