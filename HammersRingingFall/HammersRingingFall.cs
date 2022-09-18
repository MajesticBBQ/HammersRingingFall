using Vintagestory.API.Common;

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
                var Config = api.LoadModConfig<HammersRingingFallConfig>("hammersringingfall.json");
                if (Config is null) throw new FileNotFoundException();

                api.Logger.Notification("HRF Mod Config Succcessfully Loaded.");
                HammersRingingFallConfig.Current = Config;
            }
            catch
            {
                api.Logger.Notification("HRF Mod Config Not Specified. Falling back to default settings");
                HammersRingingFallConfig.Current = HammersRingingFallConfig.GetDefault();
            }
            finally
            {
                if (HammersRingingFallConfig.Current.CrucibleCapacityPerSlot <= 0)
                {
                    HammersRingingFallConfig.Current.CrucibleCapacityPerSlot = 10;
                }
                api.World.Config.SetInt("CrucibleCapacityPerSlot", HammersRingingFallConfig.Current.CrucibleCapacityPerSlot);
                api.StoreModConfig(HammersRingingFallConfig.Current, "hammersringingfall.json");
            }
        }

        public class HammersRingingFallConfig
        {
            public int CrucibleCapacityPerSlot { get; set; } = 10;

            public HammersRingingFallConfig() { }

            public static HammersRingingFallConfig Current { get; set; }

            public static HammersRingingFallConfig GetDefault() {

                HammersRingingFallConfig defaultConfig = new();
                defaultConfig.CrucibleCapacityPerSlot = 10;
                return defaultConfig;
            }
            
        }
        
    }
}
