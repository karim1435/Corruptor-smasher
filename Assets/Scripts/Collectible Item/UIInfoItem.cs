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
        private Text infoText;
        void Start()
        {
            infoText = GetComponent<Text>();
        }
        IEnumerator HideInfo()
        {
            yield return new WaitForSeconds(0.2f);
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
