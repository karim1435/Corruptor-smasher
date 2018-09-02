using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Tower
{
    public class UITower:MonoBehaviour
    {
        private Image[] liveImages;
        private TowerHealth tower;
        void Start()
        {
            tower = GameObject.FindObjectOfType<TowerHealth>();
       
            liveImages = GetComponentsInChildren<Image>();
        }
        void Update()
        {
            HealthTower();
        }
        private void HealthTower()
        {
            if (liveImages.Length == 3)
                ShowHealthHeart();
        }

        private void ShowHealthHeart()
        {
            for (int i = 0; i < liveImages.Length; i++)
            {
                liveImages[i].enabled = (i + 1) <= tower.CurrentHp;
            }
        }
    }
}
