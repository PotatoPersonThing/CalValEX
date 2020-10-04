using CalValEX.Items.Dyes;
using CalValEX.Oracle;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using CalValEX.Items;
using System;

namespace CalValEX
{
    public class CalValEX : Mod
    {
        public static bool Bumble;
        public static string currentDate;
        public static int day;
        public static int month;

        public override void Load()
        {
            DateTime dateTime = DateTime.Now;
            currentDate = dateTime.ToString("dd/MM/yyyy");
            day = dateTime.Day;
            month = dateTime.Month;
            if (!Main.dedServ)
            {
                AddEquipTexture(null, EquipType.Head, "SandElemental_Head", "CalValEX/Items/Equips/Transformations/SandElemental_Head");
                AddEquipTexture(null, EquipType.Head, "SandElemental_Body", "CalValEX/Items/Equips/Transformations/SandElemental_Body", "CalValEX/Items/Equips/Transformations/SandElemental_Arms");
                AddEquipTexture(null, EquipType.Head, "SandElemental_Legs", "CalValEX/Items/Equips/Transformations/SandElemental_Legs");
                GameShaders.Armor.BindShader(ModContent.ItemType<DraedonHologramDye>(), new ArmorShaderData(new Ref<Effect>(GetEffect("Effects/DraedonHologramDye")), "DraedonHologramDyePass"));
            }
        }

        public override void Unload()
        {
            currentDate = null;
            Bumble = false;
            day = -1;
            month = -1;
        }

        public override void PostSetupContent()
        {
            Mod cal = ModLoader.GetMod("CalamityMod");
            cal.GetItem("KnowledgeCrabulon").Tooltip.AddTranslation(GameCulture.English, "A crab and its mushrooms, a love story.\nIt's interesting how creatures can adapt given certain circumstances.\nFavorite this item to gain the Mushy buff while underground or in the mushroom biome.\nHowever, your movement speed will be decreased while in these areas due to you being covered in fungi.\nThe great crustacean's mushrooms may also grow angry when attacked, though they will also become harmless.");
            cal.GetItem("LaboratoryConsoleItem").Tooltip.AddTranslation(GameCulture.English, "Can be used to print blueprints");
            Mod censusMod = ModLoader.GetMod("Census");
            if (censusMod != null)
            {
                censusMod.Call("TownNPCCondition", ModContent.NPCType<OracleNPC>(), "Equip a Pet or Light Pet");
            }
        }

        public static void MountNerf(Player player, float reduceDamageBy, float reduceHealthBy)
        {
            bool bossIsAlive = false;
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.active && npc.boss)
                {
                    bossIsAlive = true;
                }
            }

            if (bossIsAlive)
            {
                int calculateLife = (int)(player.statLifeMax2 * reduceHealthBy);
                player.statLifeMax2 -= calculateLife;
                player.allDamage -= reduceDamageBy;
            }
        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            MessageType msgType = (MessageType)reader.ReadByte();
            byte playerNumber;
            OraclePlayer oraclePlayer;
            CalValEXPlayer calValEXPlayer;
            int SCalHits;
            switch (msgType)
            {
                case MessageType.SyncOraclePlayer:
                    playerNumber = reader.ReadByte();
                    oraclePlayer = Main.player[playerNumber].GetModPlayer<OraclePlayer>();
                    oraclePlayer.playerHasGottenBag = reader.ReadBoolean();
                    break;

                case MessageType.PlayerBagChanged:
                    playerNumber = reader.ReadByte();
                    oraclePlayer = Main.player[playerNumber].GetModPlayer<OraclePlayer>();
                    oraclePlayer.playerHasGottenBag = reader.ReadBoolean();
                    if (Main.netMode == NetmodeID.Server)
                    {
                        var packet = GetPacket();
                        packet.Write((byte)MessageType.PlayerBagChanged);
                        packet.Write(playerNumber);
                        packet.Write(oraclePlayer.playerHasGottenBag);
                        packet.Send(-1, playerNumber);
                    }
                    break;

                case MessageType.SyncCalValEXPlayer:
                    playerNumber = reader.ReadByte();
                    calValEXPlayer = Main.player[playerNumber].GetModPlayer<CalValEXPlayer>();
                    SCalHits = reader.ReadInt32();
                    calValEXPlayer.SCalHits = SCalHits;
                    break;

                case MessageType.SyncSCalHits:
                    playerNumber = reader.ReadByte();
                    calValEXPlayer = Main.player[playerNumber].GetModPlayer<CalValEXPlayer>();
                    SCalHits = reader.ReadInt32();
                    calValEXPlayer.SCalHits = SCalHits;
                    if (Main.netMode == NetmodeID.Server)
                    {
                        var packet = GetPacket();
                        packet.Write((byte)MessageType.SyncSCalHits);
                        packet.Write(playerNumber);
                        packet.Write(calValEXPlayer.SCalHits);
                        packet.Send(-1, playerNumber);
                    }
                    break;
                default:
                    Logger.WarnFormat("CalValEX: Unknown Message type: {0}", msgType);
                    break;
            }
        }

        public enum MessageType
        {
            SyncOraclePlayer = 0,
            PlayerBagChanged,
            SyncCalValEXPlayer,
            SyncSCalHits
        }

        public override void AddRecipes()
		{
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            //Wulfrum
            ModRecipe recipe = new ModRecipe(this);
            recipe.AddIngredient(calamityMod.ItemType("EnergyCore"), 50);
            recipe.AddIngredient(ItemID.SlimeBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(calamityMod.ItemType("WulfrumSlimeBanner"));
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(calamityMod.ItemType("EnergyCore"), 50);
            recipe.AddIngredient(ItemID.SlimeBanner);
            recipe.AddTile(calamityMod.TileType("StaticRefiner"));
            recipe.SetResult(calamityMod.ItemType("WulfrumSlimeBanner"));
            recipe.AddRecipe();
            //Irradiated
            recipe = new ModRecipe(this);
            recipe.AddIngredient(calamityMod.ItemType("GammaSlimeBanner"));
            recipe.AddIngredient(ModContent.ItemType<NuclearFumes>(), 50);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(calamityMod.ItemType("IrradiatedSlimeBanner"));
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(calamityMod.ItemType("GammaSlimeBanner"));
            recipe.AddIngredient(ModContent.ItemType<NuclearFumes>(), 50);
            recipe.AddTile(calamityMod.TileType("StaticRefiner"));
            recipe.SetResult(calamityMod.ItemType("IrradiatedSlimeBanner"));
            recipe.AddRecipe();
        }
    }
}