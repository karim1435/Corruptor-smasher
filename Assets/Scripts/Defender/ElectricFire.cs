using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Defender
{
    public class ElectricFire:MonoBehaviour
    {
        [SerializeField]
        private GameObject prefarb;

        private Electric electric;
        void Start()
        {
            electric = GameObject.FindObjectOfType<Electric>();
            electric.OnFireAttack += SpawnPrefarb;
        }
        void OnDisable()
        {
            electric.OnFireAttack -= SpawnPrefarb;
        }
        void SpawnPrefarb()
        {
            GameObject fire = Instantiate(prefarb);
            fire.transform.position =transform.position;
            fire.transform.rotation = Quaternion.identity;
            Destroy(fire, 0.1f);
        }
    }
}
