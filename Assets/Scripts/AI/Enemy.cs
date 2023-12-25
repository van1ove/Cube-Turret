using Interfaces;
using Player;
using UnityEngine;
using Zenject;

namespace AI
{
    public class Enemy : MonoBehaviour, IDamageble, IAttack
    {
        [SerializeField] protected EnemyStats enemyStats;

        [Inject] protected Turret Target;
        
        private int _health;

        private const float DestructionDelay = 2f;

        public void Start()
        {
            _health = enemyStats.Health;
            Attack();
        }

        public void Attack()
        {
            Debug.Log("Attack");
        }

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
        
        public class EnemyFactory : PlaceholderFactory<Enemy> { }
    }
}