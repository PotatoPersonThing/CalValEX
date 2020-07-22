using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX;

namespace CalValEX.Items.Mounts
{
    public class PBGMountBuff : ModBuff
    {
        public override void SetDefaults() {
			DisplayName.SetDefault("Plague Rider");
			Description.SetDefault("Ya gotta beelieve in yourself");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.mount.SetMount(ModContent.MountType<Items.Mounts.PBGMount>(), player);
			player.buffTime[buffIndex] = 10;
		}
	}
}