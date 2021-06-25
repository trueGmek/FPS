using System;
using UnityEngine;

namespace Systems.Audio {
    [Serializable]
    public struct Sound {
        public String name;
        public AudioClip audioClip;
        [Range(0f, 1f)] public float volume;
        [Range(0.1f, 10f)] public float pitch;
    }
}