using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.AprilFools;
using CalValEX.AprilFools.Jharim;

namespace CalValEX.AprilFools
{
	public class JharimHead : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
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
            if (Main.netMode != NetmodeID.MultiplayerClient)
                NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<Jharim.Jharim>());
            else
                NetMessage.SendData(MessageID.SpawnBossUseLicenseStartEvent, -1, -1, null, player.whoAmI, ModContent.NPCType<Jharim.Jharim>());
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