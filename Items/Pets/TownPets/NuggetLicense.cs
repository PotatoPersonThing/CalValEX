using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets.TownPets {
    public class NuggetLicense : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Chicken Nugget License");
            Tooltip.SetDefault("ombgus");
            SacrificeTotal = 1;
        }

        public override void SetDefaults() {
            Item.width = 30;
            Item.height = 20;
            
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.Pink;
            
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Item112;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;

            Item.maxStack = 30;
            Item.consumable = true;
        }

        public int PickANug (int pick) {
            switch (pick) {
                case 0:
                    if (!CalValEXWorld.nugget) {
                        CalValEXWorld.nugget = true;
                        return pick;
                    } else {
                        pick = Main.rand.Next(0, 6);
                        return PickANug(pick);
                    }
                case 1:
                    if (!CalValEXWorld.draco) {
                        CalValEXWorld.draco = true;
                        return pick;
                    } else {
                        pick = Main.rand.Next(0, 6);
                        return PickANug(pick);
                    }
                case 2:
                    if (!CalValEXWorld.folly) {
                        CalValEXWorld.folly = true;
                        return pick;
                    } else {
                        pick = Main.rand.Next(0, 6);
                        return PickANug(pick);
                    }
                case 3:
                    if (!CalValEXWorld.godnug) {
                        CalValEXWorld.godnug = true;
                        return pick;
                    } else {
                        pick = Main.rand.Next(0, 6);
                        return PickANug(pick);
                    }
                case 4:
                    if (!CalValEXWorld.mammoth) {
                        CalValEXWorld.mammoth = true;
                        return pick;
                    } else {
                        pick = Main.rand.Next(0, 6);
                        return PickANug(pick);
                    }
                case 5:
                    if (!CalValEXWorld.shadow) {
                        CalValEXWorld.shadow = true;
                        return pick;
                    } else {
                        pick = Main.rand.Next(0, 6);
                        return PickANug(pick);
                    }
                default:
                    return -1;
            }
        }

        public override bool ConsumeItem(Player player) {
            if (!CalValEXWorld.AnyChickensAround())
                return false;

            return base.ConsumeItem(player);
        }

        public override bool? UseItem(Player player) {
            if (CalValEXWorld.AnyChickensAround()) {
                int spawnwhichdog = Main.rand.Next(0, 6);
                PickANug(spawnwhichdog);
                if (Main.netMode == NetmodeID.SinglePlayer)
                    Main.NewText(Language.GetTextValue("The license teleports away to the Uber Eats delivery service"), 50, byte.MaxValue, 130);
                else
                    NetMessage.SendData(MessageID.SpawnBoss, -1, -1, null, player.whoAmI, -13f, 0.0f, 0.0f, 0, 0, 0);
                return true;
            } else if (!CalValEXWorld.AnyChickensAround()) {
                Main.NewText(Language.GetTextValue("there's already a fucking nugget in") + ($" {Main.worldName}") + Language.GetTextValue(", dumbass"), byte.MaxValue, 0, 0);
                return true;
            }
            return null;
        }

    }
}
