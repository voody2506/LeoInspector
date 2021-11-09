using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace Voody.UniLeo
{
    public enum ConvertMode
    {
        ConvertAndInject,
        ConvertAndDestroy,
        ConvertAndSaveEntity
    }
    public class ConvertToEntity : MonoBehaviour
    {
        public ConvertMode convertMode;
        private EcsEntity? entity;
        private void Start()
        {
            var world = WorldHandler.GetWorld();
            if (world != null)
            {
                var entity = world.NewEntity();
                var instantiateComponent = new InstantiateComponent() { gameObject = gameObject };
                entity.Replace(instantiateComponent);
            }
        }

        public EcsEntity? TryGetEntity()
        {
            if (entity.HasValue)
            {
                if (entity.Value.IsAlive())
                {
                    return entity.Value;
                }
            }

            return null;
        }

        public void Set(EcsEntity entity)
        {
            this.entity = entity;
        }
    }
}
