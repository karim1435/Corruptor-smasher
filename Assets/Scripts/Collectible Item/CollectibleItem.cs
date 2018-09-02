using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Defender;

namespace Assets.Scripts.Collectible_Item
{
    public abstract class CollectibleItem<T> :MonoBehaviour where T : MonoBehaviour
    {
        protected T defender;
        [SerializeField]
        protected float speedMove = 100;
        [SerializeField]
        protected float bonus;

        private Rigidbody2D body2d;
        protected virtual void Start()
        {
            defender = GameObject.FindObjectOfType<T>();
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
        protected virtual void GiveExtraBonus()
        {
            defender.gameObject.GetComponent<DefenderParent>().ExtraItem(bonus);
        }
    }
}
