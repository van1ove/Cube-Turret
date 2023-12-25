using Player;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class TurretInstaller : MonoInstaller
    {
        [SerializeField] private Turret turret;
        [SerializeField] private Transform targetsPositions;
        public override void InstallBindings()
        {
            Turret turretInstance = Container.InstantiatePrefabForComponent<Turret>(turret, 
                CreateSpawnPosition(targetsPositions.position, turret.transform.localScale.y), 
                Quaternion.identity, null);

            Container.Bind<Turret>().FromInstance(turretInstance).AsSingle();

            InputController inputController = turretInstance.gameObject.GetComponent<InputController>();

            inputController.SetTargets(targetsPositions);
        }

        private Vector3 CreateSpawnPosition(Vector3 position, float yScale)
        {
            float x = position.x;
            float y = position.y + yScale;
            float z = position.z;
        
            return new Vector3(x, y, z);
        }
    }
}
