using System;
using UnityEngine;
using Weapons;
using Random = UnityEngine.Random;

namespace Enemies {
    [RequireComponent(typeof(Body))]
    public class CubeEnemy : MonoBehaviour {
        private Shootable _shootable;
        private Body _body;
        private Renderer _renderer;
        private static readonly int BaseColor = Shader.PropertyToID("_BaseColor");

        private void Awake() {
            _shootable = GetComponent<Shootable>();
            _body = GetComponent<Body>();
            _renderer = GetComponent<Renderer>();
        }

        private void Start() {
            _shootable.OnHit += RandomizeColor;
            _shootable.OnHit += SetScaleToHealth;
        }

        private void RandomizeColor(HitData hit) {
            _renderer.material.SetColor(BaseColor,
                new Color(Random.value, Random.value, Random.value));
        }

        private void SetScaleToHealth(HitData hit) {
            float scaleValue = _body.CurrentHealth / _body.initialHealth.value;
            transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
        }
    }
}