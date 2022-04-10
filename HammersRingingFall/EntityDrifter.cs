using System;
using System.Collections.Generic;
using System.Text;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.GameContent;

namespace HammersRingingFall
{
    class EntityDrifter : EntityHumanoid   
    {
        public override bool ShouldReceiveDamage(DamageSource damageSource , float damage)
        {

            Console.WriteLine("test");
            if (damageSource.SourceEntity == null)
            {
                System.Diagnostics.Debug.WriteLine("EntityHit0, SourceEntity is " + damageSource.SourceEntity);
                return false;
            }
            System.Diagnostics.Debug.WriteLine("EntityHit0, SourceEntity is " + damageSource.SourceEntity);
            if (damageSource.SourceEntity is EntityThrownStone)
            {
                System.Diagnostics.Debug.WriteLine("EntityHitA, SourceEntity is " + damageSource.SourceEntity);
                EntityThrownStone stone = damageSource.SourceEntity as EntityThrownStone;
                if (stone.FiredBy is EntityDrifter) return false;
            }
            if (damageSource.SourceEntity is EntityDrifter)
            {
                System.Diagnostics.Debug.WriteLine("EntityHitB, SourceEntity is " + damageSource.SourceEntity);
                return false;
            }
            System.Diagnostics.Debug.WriteLine("EntityHitC, SourceEntity is " + damageSource.SourceEntity);
            return base.ShouldReceiveDamage(damageSource, damage);
        }
    }
}
