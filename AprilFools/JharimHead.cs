using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.AprilFools;

namespace CalValEX.AprilFools
{
	public class JharimHead : ModItem
	{
		public override void SetStaticDefaults()
		{
		}
		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 18;
			Item.maxStack = 1;
			Item.rare = 9;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.useStyle = 4;
			Item.UseSound = SoundID.Item44;
			Item.consumable = true;
		}
		
		public override bool? UseItem(Player player)
		{
			Terraria.Audio.SoundEngine.PlaySound(SoundID.Item15, player.position);
			if (Main.netMode != 1)
			{
				NPC.SpawnOnPlayer(player.whoAmI, (ModContent.NPCType<AprilFools.Jharim.Jharim>()));
			}
			return true;
		}

		public override bool CanUseItem(Player player)
        {
            if (!CalValEX.AprilFoolMonth)
            {
				return false;
            }
			else if (NPC.AnyNPCs(ModContent.NPCType<AprilFools.Jharim.Jharim>()))
			{
				return false;
			}
            else
            {
                return true;
            }
		}
	}
}