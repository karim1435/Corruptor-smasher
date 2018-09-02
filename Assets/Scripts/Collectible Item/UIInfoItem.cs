using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Collectible_Item
{
    class UIInfoItem:MonoBehaviour
    {
        [SerializeField]
        private float delayInfoTime=0.5f;

        private Text infoText;
        void Start()
        {
            infoText = GetComponent<Text>();
        }
        private IEnumerator HideInfo()
        {
            yield return new WaitForSeconds(delayInfoTime);
            infoText.enabled = false;
        }
        public void ShowInfo(string info)
        {
            infoText.enabled = true;
            infoText.text = info;
            StartCoroutine(HideInfo());
        }

    }
}
