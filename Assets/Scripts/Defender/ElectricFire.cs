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

        private const float lifeTimeShoot = 0.1f;
        private Electric electric;
        void Start()
        {
            electric = GameObject.FindObjectOfType<Electric>();
            electric.OnFireAttack += SpawnPrefarb;
        }
        private void OnDisable()
        {
            electric.OnFireAttack -= SpawnPrefarb;
        }
        private void SpawnPrefarb()
        {
            GameObject fire = (GameObject)Instantiate(prefarb, transform.position, Quaternion.identity);
            Destroy(fire, lifeTimeShoot);
        }
    }
}
