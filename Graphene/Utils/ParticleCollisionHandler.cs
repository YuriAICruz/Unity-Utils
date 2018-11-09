using System;
using System.Collections.Generic;
using UnityEngine;

namespace Graphene.Utils
{
    [RequireComponent(typeof(ParticleSystem ))]
    public class ParticleCollisionHandler : MonoBehaviour
    {
        [HideInInspector]
        public ParticleSystem Particle;
        public List<ParticleCollisionEvent> CollisionEvents;

        public event Action<GameObject, Vector3> OnCollision;

        private void Start()
        {
            Particle = GetComponent<ParticleSystem>();
            CollisionEvents = new List<ParticleCollisionEvent>();
        }

        private void OnParticleCollision(GameObject other)
        {
            int numCollisionEvents = Particle.GetCollisionEvents(other, CollisionEvents);
            
            int i = 0;

            while (i < numCollisionEvents)
            {
                OnCollision?.Invoke(other, CollisionEvents[i].intersection);
                i++;
            }
        }
    }
}