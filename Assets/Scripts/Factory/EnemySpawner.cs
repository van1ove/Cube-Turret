using UnityEngine;
using Zenject;
using AI;
using Random = System.Random;

namespace Factory
{
    public class EnemySpawner : MonoBehaviour
    {
        [Inject] private Enemy.EnemyFactory _enemyFactory;

        [SerializeField] private Transform targets;
        [SerializeField] private float timeBeforeSpawn;
        private float _time;

        private Random _random;
        private void Start()
        {
            _random = new Random();
            SpawnEnemy();
        }
        
        private void Update()
        {
            _time += Time.deltaTime;
            if (_time <= timeBeforeSpawn) return;

            SpawnEnemy();
            _time = 0;
        }
        
        private void SpawnEnemy()
        {
            Enemy enemy = _enemyFactory.Create();
            enemy.transform.position = ChoosePosition();
        }

        private Vector3 ChoosePosition()
        {
            int pos = _random.Next(0, targets.childCount);
            return targets.GetChild(pos).position;
        }
    }
}