using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Manager
{
    public class GameAudio:MonoBehaviour
    {
        public AudioClip backingSound;

        public AudioClip[] death;

        public AudioClip lostLife;

        public AudioClip newLife;

        public AudioClip bombEffects;

        public AudioClip thunderEffects;

        public AudioClip poisonEffects;

        public AudioClip ohnoEffects;

        public AudioClip tapEfefect;

        public AudioClip pickUpItem;

        public AudioClip gameOver;
    }
}
