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

            try
            {
                HammersRingingFallConfig FromDisk;
                if ((FromDisk = api.LoadModConfig<HammersRingingFallConfig>("HammersRingingFallConfig.json")) == null)
                {
                    api.StoreModConfig<HammersRingingFallConfig>(HammersRingingFallConfig.Loaded, "HammersRingingFallConfig.json");
                }
                else HammersRingingFallConfig.Loaded = FromDisk;
            }
            catch
            {
                api.StoreModConfig<HammersRingingFallConfig>(HammersRingingFallConfig.Loaded, "HammersRingingFallConfig.json");
            }

            api.World.Config.SetInt($"CrucibleCapacityPerSlot", HammersRingingFallConfig.Loaded.CrucibleCapacityPerSlot);
        }

        public class HammersRingingFallConfig : ModSystem
        {
            public static HammersRingingFallConfig Loaded { get; set; } = new HammersRingingFallConfig();
            public int CrucibleCapacityPerSlot { get; set; } = 10;


        }
        
    }
}
