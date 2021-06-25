using System;
using System.Collections.Generic;
using UnityEngine;

namespace Systems.Audio {
    public class AudioManager : MonoBehaviour {
        [SerializeField] private Sound[] sounds;
        private readonly Dictionary<Sound, AudioSource> _audioSourcesOverSounds = new Dictionary<Sound, AudioSource>();

        private void Awake() {
            foreach (var sound in sounds) {
                var audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.clip = sound.audioClip;
                audioSource.volume = sound.volume;
                audioSource.pitch = sound.pitch;
                _audioSourcesOverSounds[sound] = audioSource;
            }
        }

/***
 * Get sound name from SoundNameProvider
 */
        public AudioSource Play(SoundName soundName) {
            try {
                var searchedSound = Array.Find(sounds, sound => sound.name == soundName.Name);
                var searchedAudioSource = _audioSourcesOverSounds[searchedSound];
                searchedAudioSource.Play();
                return searchedAudioSource;
            }
            catch (Exception e) {
                Debug.LogError($"{soundName} does not exist in sound library : {e.Message}");
                return null;
            }
        }
    }
}