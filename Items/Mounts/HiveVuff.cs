using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX;

namespace CalValEX.Items.Mounts
{
    public class HiveVuff : ModBuff
    {
        public override void SetDefaults() {
			DisplayName.SetDefault("Conglomeration Mind");
			Description.SetDefault("I swear it's not what you think");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.mount.SetMount(ModContent.MountType<Items.Mounts.HiveMount>(), player);
			player.buffTime[buffIndex] = 10;
            Main.LocalPlayer.AddBuff(ModLoader.GetMod("CalamityMod").BuffType("CorruptionEffigyBuff"), 10);
		}
	}
}