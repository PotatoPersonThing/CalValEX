using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts
{
    public class BikeBuff : ModBuff
    {
        public override void SetDefaults() 
		{
			DisplayName.SetDefault("Profaned Bike");
			Description.SetDefault("For when you really need to get somewhere, in style.");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) 
		{
			player.mount.SetMount(ModContent.MountType<ProfanedCycle>(), player);
			player.buffTime[buffIndex] = 10;
			CalValEX.MountNerf(player, 0.9f, 0.75f);
		}
	}
}
