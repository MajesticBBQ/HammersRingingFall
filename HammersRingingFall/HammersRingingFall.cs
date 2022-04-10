using HammersRingingFall;
using System;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;

namespace HammersRingingFall
{
    public class HammersRingingFall : ModSystem
    {
        public override bool ShouldLoad(EnumAppSide forSide)
        {
            return true;
        }

        public override void Start(ICoreAPI api)
        {
            base.Start(api);
            api.RegisterEntity("EntityDrifter", typeof(EntityDrifter));
        }
    }

    
}
