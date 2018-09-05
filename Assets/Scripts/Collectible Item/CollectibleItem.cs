using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Defender;
using Assets.Scripts.Manager;

namespace Assets.Scripts.Collectible_Item
{
    public abstract class CollectibleItem<T> :MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField]
        protected float speedMove = 50;
        [SerializeField]
        protected float bonus;

        protected T defender;
        protected string info;
    
        private Rigidbody2D body2d;
        private UIInfoItem uIInfoItem;

        protected GameAudio audioGame;
        void Awake()
        {
            uIInfoItem = FindObjectOfType<UIInfoItem>();

            audioGame = FindObjectOfType<GameAudio>();
        }
        protected virtual void Start()
        {
            defender = GameObject.FindObjectOfType<T>();
            body2d = GetComponent<Rigidbody2D>(); 
        }
        void Update()
        {
            body2d.velocity = new Vector2(0, Vector2.down.y * speedMove * Time.deltaTime);
        }
        protected virtual void OnMouseDown()
        {
            if (!GameManager.Instance.IsGameRunning()) return;
            GiveExtraBonus();
            Destroy(gameObject);
            InfoBonus(info);
        }
        protected virtual void GiveExtraBonus()
        {
            defender.gameObject.GetComponent<DefenderParent>().ExtraItem(bonus);
        }
        protected virtual void InfoBonus(string info)
        {
            uIInfoItem.ShowInfo(info);
        }
        protected void PlayAudio(AudioClip audio)
        {
            SoundManager.Instance.PlayEffect(audio);
        }
    }
}
