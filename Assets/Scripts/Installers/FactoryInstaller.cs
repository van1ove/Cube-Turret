using AI;
using Zenject;
using UnityEngine;

namespace Installers
{
    public class FactoryInstaller : MonoInstaller
    {
        [SerializeField] private GameObject enemy;
        public override void InstallBindings()
        {
            Container.BindFactory<Enemy, Enemy.EnemyFactory>().FromComponentInNewPrefab(enemy);
        }
    }
}