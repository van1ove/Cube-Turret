using Interfaces;
using UnityEngine;

namespace Player
{
    public class Turret : MonoBehaviour, IDamageble, IAttack
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
        private float _attackDelay;

        private bool _canAttack;
        private void Start()
        {
            _time = 0;
            _attackDelay = 60f / shootsPerMinute;
            _canAttack = true;
        }

        private void Update()
        {
            _time += Time.deltaTime;
            if (_time <= _attackDelay) return;

            if(_canAttack) Attack();
            _time = 0;
        }
        
        public void Attack()
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

        public void ChangeAttackPosibility(bool canAttack) => _canAttack = canAttack;
    }
}