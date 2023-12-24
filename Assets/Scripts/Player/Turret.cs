using Interfaces;
using UnityEngine;

namespace Player
{
    public class Turret : MonoBehaviour, IDamageble
    {
        [Header("Stats")]
        [SerializeField] private float rotationSpeed;
        [SerializeField] private int damage;
        [SerializeField] private int shootsPerMinute;
        [SerializeField] private int health;
        
        public float RotationSpeed => rotationSpeed;
        public int Damage => damage;
        public int ShootsPerMinute => shootsPerMinute;
        public int Health => health;

        private float _time;
        private float _shootDelay;

        private void Start()
        {
            _time = 0;
            _shootDelay = 60f / shootsPerMinute;
        }

        private void Update()
        {
            _time += Time.deltaTime;
            if (_time <= _shootDelay) return;

            Shoot();
            _time = 0;
        }
        
        void Shoot()
        {
            
        }
        
        public void TakeDamage(int takenDamage)
        {
            if (health > 0)
            {
                health -= takenDamage;
                if (health <= 0) ;
            }
        }
    }
}