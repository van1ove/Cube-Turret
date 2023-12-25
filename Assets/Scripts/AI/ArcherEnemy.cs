using UnityEngine;

namespace Enemy
{
    public class ArcherEnemy : Enemy
    {
        [SerializeField] private float attackDistance;

        public void Start()
        {
            base.Start();
            Debug.Log(nameof(ArcherEnemy));
        }

        public class ArcherEnemyFactory : EnemyFactory { }
    }
}