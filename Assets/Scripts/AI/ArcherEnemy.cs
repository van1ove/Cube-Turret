using UnityEngine;

namespace AI
{
    public class ArcherEnemy : Enemy
    {
        [SerializeField] private float attackDistance;

        public void Start()
        {
            base.Start();
        }

        public class ArcherEnemyFactory : EnemyFactory { }
    }
}