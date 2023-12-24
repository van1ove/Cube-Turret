using Interfaces;
using Player;
using UnityEngine;

namespace Enemy
{
    public abstract class Enemy : MonoBehaviour, IDamageble
    {
        [SerializeField] protected EnemyStats enemyStats;

        protected Turret Target;
        private int _health;

        private const float DestructionDelay = 2f;

        public void Start()
        {
            _health = enemyStats.Health;
        }

        public abstract void Attack();

        public void TakeDamage(int takenDamage)
        {
            _health -= takenDamage;
            if (_health <= 0)
            {
                Invoke(nameof(Die), DestructionDelay);
            }
        }

        public void Die()
        {
            Destroy(this);
        }
    }
}