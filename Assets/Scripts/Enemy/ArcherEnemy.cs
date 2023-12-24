using UnityEngine;

namespace Enemy
{
    public class ArcherEnemy : Enemy
    {
        [SerializeField] private float attackDistance;
        public void Start()
        {
            base.Start();
        }

        /*
        private IEnumerator Move()
        {
            transform.position = Vector3.MoveTowards(transform.position,
                Target.transform.position, enemyStats.MoveSpeed * Time.deltaTime);
        }
        */
        
        public override void Attack()
        {
            throw new System.NotImplementedException();
        }
    }
}