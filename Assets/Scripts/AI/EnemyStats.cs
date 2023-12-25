using UnityEngine;

namespace AI
{
    [CreateAssetMenu(fileName = "EnemyStats", menuName = "Enemy Stats")]
    public class EnemyStats : ScriptableObject
    {
        [SerializeField] private int health;
        [SerializeField] private int moveSpeed;
        [SerializeField] private int damage;
        [SerializeField] private int attacksPerMinute;

        public int Health => health;
        public int MoveSpeed => moveSpeed;
        public int Damage => damage;
        public int AttacksPerMinute => attacksPerMinute;
    }
}