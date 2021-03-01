//using CalValEX.Buffs.Transformations;
//using CalValEX.Items.Equips.Transformations;
using CalValEX.Items.Equips.Hats.Draedon;
using CalValEX.Items.Equips.Shirts.Draedon;
using CalValEX.Items.Mounts.Morshu;
using CalValEX.Projectiles.Pets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX
{
    public class CalValEXPlayer : ModPlayer
    {
        private const int saveVersion = 0;

        public bool ZoneAstral;
        public bool HellLab;
        public bool mBirb = false;
        public bool mBirb2 = false;
        public bool mDoge = false;
        public bool hDoge = false;
        public bool bDoge = false;
        public bool mAero = false;
        public bool aero = false;
        public bool mSkater = false;
        public bool mShark = false;
        public bool mFolly = false;
        public bool mPerf = false;
        public bool mHive = false;
        public bool mPhan = false;
        public bool mChan = false;
        public bool mNaked = false;
        public bool mArmored = false;
        public bool SWPet = false;
        public bool eidolist = false;
        public bool excal = false;
        public bool mRav = false;
        public bool tub = false;
        public bool andro = false;
        public bool seerS = false;
        public bool seerM = false;
        public bool seerL = false;
        public bool mImp = false;
        public bool George = false;
        public bool rPanda = false;
        public bool catfish = false;
        public bool cr = false;
        public bool eb = false;
        public bool mSlime = false;
        public bool fog = false;
        public bool mDebris = false;
        public bool mHeat = false;
        public bool mHeat2 = false;
        public bool dBall = false;
        public bool mClam = false;
        public bool mAme = false;
        public bool mSap = false;
        public bool mEme = false;
        public bool mTop = false;
        public bool mRub = false;
        public bool mDia = false;
        public bool mCry = false;
        public bool mAmb = false;
        public bool sBun = false;
        public bool uSerpent = false;
        public bool GeorgeII = false;
        public bool junsi = false;
        public bool SignusMini = false;
        public bool Angrypup = false;
        public bool cryokid = false;
        public bool MiniCryo = false;
        public bool SmolCrab = false;
        public bool VoidOrb = false;
        public bool AstPhage = false;
        public bool StarJelly = false;
        public bool ProGuard1 = false;
        public bool ProGuard2 = false;
        public bool ProGuard3 = false;
        public bool ProviPet = false;
        public bool Dstone = false;
        public bool EWyrm = false;
        public bool PBGmini = false;
        public bool BoldLizard = false;
        public bool Nugget = false;
        public bool Enredpet = false;
        public bool sandmini = false;
        public bool raresandmini = false;
        public bool babywaterclone = false;
        public bool rarebrimling = false;
        public bool cloudmini = false;
        public bool Skeetyeet = false;
        public bool TerminalRock = false;
        public bool BabyCnidrion = false;
        public bool sVoid = false;
        public bool sSignus = false;
        public bool sWeeb = false;
        public bool euros = false;
        public bool jared = false;
        public bool asPet = false;
        public bool dsPet = false;
        public bool mDuke = false;
        public bool sirember = false;
        public bool deusmain = false;
        public bool deussmall = false;
        public bool rusty = false;
        public bool sepet = false;
        public bool pylon = false;
        public bool worb = false;
        public bool rover = false;
        public bool drone = false;
        public bool hover = false;
        public bool RepairBot = false;
        public bool MechaGeorge = false;
        public bool CalamityBABYBool = false;
        public bool CalamityBabyGotHit = false;
        public int SCalHits = 0;
        public bool Lightshield = false;
        public bool sDuke = false;
        public bool squid = false;
        public bool voidling = false;
        public bool mScourge = false;
        public bool darksunSpirits = false;
        public bool goozmaPet = false;
        public bool voreworm = false;
        public bool moistPet = false;
	    public bool Chihuahua = false;
	    public bool strongWeeb = false;
	    public bool ySquid = false;
	    public bool oSquid = false;

        //public CalamityPlayer calPlayer;
        /*
        public bool sandTPrevious;
        public bool sandT;
        public bool sandHide;
        public bool sandForce;
        */

        public int morshuTimer;

        public override void Initialize()
        {
            ResetMyStuff();
            //calPlayer = player.GetModPlayer<CalamityPlayer>();
            CalamityBabyGotHit = false;
            morshuTimer = 0;
        }

        public override void ResetEffects()
        {
            //sandTPrevious = sandT;
            //sandT = sandHide = sandForce = false;
            ResetMyStuff();
        }

        /*
        public override void UpdateVanityAccessories()
        {
            for (int n = 13; n < 18 + player.extraAccessorySlots; n++)
            {
                Item item = player.armor[n];
                if (item.type == ModContent.ItemType<SandyBangles>())
                {
                    sandHide = false;
                    sandForce = true;
                }
            }
        }

        public override void FrameEffects()
        {
            if ((sandT || sandForce) && !sandHide)
            {
                player.legs = mod.GetEquipSlot("SandElemental_Legs", EquipType.Legs);
                player.body = mod.GetEquipSlot("SandElemental_Body", EquipType.Body);
                player.head = mod.GetEquipSlot("SandElemental_Head", EquipType.Head);
            }
        }

        public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff)
        {
            if (sandT)
                player.AddBuff(ModContent.BuffType<SandTransformationBuff>(), 60, true);
        }
        */

        public override void PostUpdateBuffs()
        {
            if (!player.HasBuff(ModContent.BuffType<MorshuBuff>()))
                morshuTimer = 0;
        }

        public override void UpdateDead()
        {
            ResetMyStuff();
            CalamityBabyGotHit = false;
            SCalHits = 0;
            morshuTimer = 0;
        }

        private void ResetMyStuff()
        {
            mBirb = false;
            mBirb2 = false;
            mDoge = false;
            mAero = false;
            mSkater = false;
            mShark = false;
            mFolly = false;
            mPerf = false;
            mHive = false;
            mPhan = false;
            mChan = false;
            mNaked = false;
            mArmored = false;
            eidolist = false;
            excal = false;
            aero = false;
            mRav = false;
            tub = false;
            andro = false;
            seerS = false;
            seerM = false;
            seerL = false;
            mImp = false;
            George = false;
            rPanda = false;
            catfish = false;
            cr = false;
            eb = false;
            mSlime = false;
            fog = false;
            mDebris = false;
            mHeat = false;
            mHeat2 = false;
            dBall = false;
            mClam = false;
            mAme = false;
            mSap = false;
            mEme = false;
            mTop = false;
            mRub = false;
            mDia = false;
            mCry = false;
            mAmb = false;
            sBun = false;
            uSerpent = false;
            GeorgeII = false;
            junsi = false;
            SignusMini = false;
            MiniCryo = false;
            SmolCrab = false;
            VoidOrb = false;
            AstPhage = false;
            StarJelly = false;
            ProGuard1 = false;
            ProGuard2 = false;
            ProGuard3 = false;
            ProviPet = false;
            Dstone = false;
            EWyrm = false;
            PBGmini = false;
            BoldLizard = false;
            Nugget = false;
            Enredpet = false;
            sandmini = false;
            raresandmini = false;
            rarebrimling = false;
            babywaterclone = false;
            cloudmini = false;
            Skeetyeet = false;
            Angrypup = false;
            cryokid = false;
            TerminalRock = false;
            BabyCnidrion = false;
            sVoid = false;
            sSignus = false;
            sWeeb = false;
            euros = false;
            hDoge = false;
            bDoge = false;
            SWPet = false;
            jared = false;
            asPet = false;
            dsPet = false;
            mDuke = false;
            sirember = false;
            deusmain = false;
            deussmall = false;
            rusty = false;
            sepet = false;
            pylon = false;
            worb = false;
            rover = false;
            drone = false;
            hover = false;
            RepairBot = false;
            MechaGeorge = false;
            CalamityBABYBool = false;
            Lightshield = false;
            sDuke = false;
            squid = false;
            voidling = false;
            mScourge = false;
            darksunSpirits = false;
            goozmaPet = false;
            voreworm = false;
            moistPet = false;
	        Chihuahua = false;
            strongWeeb = false;
            ySquid = false;
            oSquid = false;
        }

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            DoCalamityBabyThings((int)damage);
        }

        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            DoCalamityBabyThings(damage);

            if (npc.type == ModLoader.GetMod("CalamityMod").NPCType("SupremeCalamitas") && player.immuneTime <= 0)
                SCalHits++;
        }

        public override void OnHitByProjectile(Projectile proj, int damage, bool crit)
        {
            DoCalamityBabyThings(damage);

            for (int i = 0; i < Main.maxNPCs; i++)
            {
                if (Main.npc[i].active && Main.npc[i].type == ModLoader.GetMod("CalamityMod").NPCType("SupremeCalamitas"))
                {
                    if (player.immuneTime <= 0)
                        SCalHits++;
                }
            }
        }

        private void DoCalamityBabyThings(int damage)
        {
            if (CalamityBABYBool)
            {
                if (damage > 0)
                {
                    if (player.whoAmI == Main.myPlayer)
                    {
                        if (player.name == "Kawaggy")
                        {
                            string humiliationText = "";
                            switch (Main.rand.Next(0, 5))
                            {
                                case 0:
                                    humiliationText = "Why didn't you code me earlier?";
                                    break;

                                case 1:
                                    humiliationText = "Not worthy.";
                                    break;

                                case 2:
                                    humiliationText = "It's been months.";
                                    break;

                                case 3:
                                    humiliationText = "You will not be forgiven.";
                                    break;

                                case 4:
                                    humiliationText = "I hope you learn.";
                                    break;
                            }
                            CombatText.NewText(player.getRect(), Color.White, humiliationText);
                            player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " is not worthy."), 99999999, -1);
                        }

                        if (Main.rand.NextFloat() < 0.08f)
                        {
                            if (CalamityBABY.nameList.Contains(player.name))
                            {
                                player.AddBuff(BuffID.Lovestruck, Main.rand.Next(600, 3601));
                            }
                            else if (!player.HasBuff(ModLoader.GetMod("CalamityMod").BuffType("AstrageldonBuff")) || !Main.LocalPlayer.HasItem(ItemID.LandMine))
                            {
                                CalamityBabyGotHit = true;
                            }
                        }
                    }
                }
            }
        }

        public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
        {
            if (player.ZoneBeach && power > 80 && Utils.NextFloat(Main.rand) < 0.021f)
            {
                caughtType = mod.ItemType("WetBubble");
            }
        }

        public override void UpdateBiomes()
        {
            ZoneAstral = CalValEXWorld.astralTiles > 50;
            HellLab = CalValEXWorld.hellTiles > 50;
        }

        public override bool CustomBiomesMatch(Player other)
        {
            CalValEXPlayer modOther = other.GetModPlayer<CalValEXPlayer>();
            return ZoneAstral == modOther.ZoneAstral;
            return HellLab == modOther.HellLab;
        }

        public override void CopyCustomBiomesTo(Player other)
        {
            CalValEXPlayer modOther = other.GetModPlayer<CalValEXPlayer>();
            modOther.ZoneAstral = ZoneAstral;
            modOther.HellLab = HellLab;
        }

        public override void SendCustomBiomes(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = ZoneAstral;
            flags[1] = HellLab;
            writer.Write(flags);
        }

        public override void ReceiveCustomBiomes(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            ZoneAstral = flags[0];
            HellLab = flags[1];
        }

        public override void clientClone(ModPlayer clientClone)
        {
            CalValEXPlayer clone = clientClone as CalValEXPlayer;
            clone.SCalHits = SCalHits;
        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = mod.GetPacket();
            packet.Write((byte)CalValEX.MessageType.SyncCalValEXPlayer);
            packet.Write((byte)player.whoAmI);
            packet.Write(SCalHits);
            packet.Send(toWho, fromWho);
        }

        public override void SendClientChanges(ModPlayer clientPlayer)
        {
            CalValEXPlayer clone = clientPlayer as CalValEXPlayer;
            if (clone.SCalHits != SCalHits)
            {
                var packet = mod.GetPacket();
                packet.Write((byte)CalValEX.MessageType.SyncSCalHits);
                packet.Write((byte)player.whoAmI);
                packet.Write(SCalHits);
                packet.Send();
            }
        }

        public override void ModifyDrawLayers(List<PlayerLayer> layers)
        {
            int headLayer = layers.FindIndex(l => l == PlayerLayer.Head);
            int bodyLayer = layers.FindIndex(l => l == PlayerLayer.Body);

            if (headLayer > -1)
            {
                layers.Insert(headLayer + 1, DraedonHelmet);
            }
            if (bodyLayer > -1)
            {
                layers.Insert(bodyLayer + 1, DraedonChestplate);
            }
        }

        public override void ModifyDrawHeadLayers(List<PlayerHeadLayer> layers)
        {
            int headLayer = layers.FindIndex(l => l == PlayerHeadLayer.Armor);

            if (headLayer > -1)
            {
                layers.Insert(headLayer + 1, HeadDraedonHelmet);
            }
        }

        public override void ModifyDrawInfo(ref PlayerDrawInfo drawInfo) //i just really dont want to fix the sprite issues.
        {
            if (drawInfo.drawPlayer.legs == mod.GetEquipSlot("DraedonLeggings", EquipType.Legs))
            {
                drawInfo.legColor = Color.Transparent;
                drawInfo.legGlowMaskColor = Color.Transparent;
                drawInfo.pantsColor = Color.Transparent;
            }

            if (drawInfo.drawPlayer.body == mod.GetEquipSlot("DraedonChestplate", EquipType.Body))
            {
                drawInfo.armGlowMaskColor = Color.Transparent;
                drawInfo.bodyColor = Color.Transparent;
                drawInfo.bodyGlowMaskColor = Color.Transparent;
                drawInfo.shirtColor = Color.Transparent;
                drawInfo.underShirtColor = Color.Transparent;
            }

            if (drawInfo.drawPlayer.head == mod.GetEquipSlot("DraedonHelmet", EquipType.Head))
            {
                drawInfo.eyeColor = Color.Transparent;
                drawInfo.eyeWhiteColor = Color.Transparent;
                drawInfo.faceColor = Color.Transparent;
                drawInfo.hairColor = Color.Transparent;
                drawInfo.headGlowMaskColor = Color.Transparent;
            }
        }

        public static readonly PlayerHeadLayer HeadDraedonHelmet = new PlayerHeadLayer("CalValEX", "HeadDraedonHelmet", delegate (PlayerHeadDrawInfo drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("CalValEX");

            if (drawPlayer.head != mod.GetEquipSlot("DraedonHelmet", EquipType.Head))
            {
                return;
            }

            Texture2D texture = DraedonHelmetTextureCache.none;
            //ugly but i dont care
            if (drawPlayer.HeldItem.magic)
            {
                texture = DraedonHelmetTextureCache.magic;
            }
            if (drawPlayer.HeldItem.summon)
            {
                texture = DraedonHelmetTextureCache.summoner;
            }
            if (drawPlayer.HeldItem.ranged)
            {
                texture = DraedonHelmetTextureCache.ranger;
            }
            if (drawPlayer.HeldItem.thrown)
            {
                texture = DraedonHelmetTextureCache.rogue;
            }
            if (drawPlayer.HeldItem.melee)
            {
                texture = DraedonHelmetTextureCache.melee;
            }

            if (texture == DraedonHelmetTextureCache.none)
                return;

            float drawX = (int)(drawPlayer.position.X - Main.screenPosition.X - (drawPlayer.bodyFrame.Width / 2) + (drawPlayer.width / 2));
            float drawY = (int)(drawPlayer.position.Y - Main.screenPosition.Y + drawPlayer.height - drawPlayer.bodyFrame.Height + 4);

            Vector2 position = new Vector2(drawX, drawY) + drawPlayer.headPosition + drawInfo.drawOrigin;

            Rectangle frame = drawPlayer.bodyFrame;

            Color color = Color.White;

            float alpha = (255 - drawPlayer.immuneAlpha) / 255f;

            float rotation = drawPlayer.headRotation;

            Vector2 origin = drawInfo.drawOrigin;

            float scale = drawInfo.scale;

            SpriteEffects spriteEffects = drawInfo.spriteEffects;

            DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, scale, spriteEffects, 0);

            GameShaders.Armor.Apply(drawInfo.armorShader, drawPlayer, drawData);

            drawData.Draw(Main.spriteBatch);

            Main.pixelShader.CurrentTechnique.Passes[0].Apply();
        });

        public static readonly PlayerLayer DraedonHelmet = new PlayerLayer("CalValEX", "DraedonHelmet", PlayerLayer.Head, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
            {
                return;
            }

            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("CalValEX");

            if (drawPlayer.head != mod.GetEquipSlot("DraedonHelmet", EquipType.Head))
            {
                return;
            }

            Texture2D texture = DraedonHelmetTextureCache.none;
            //ugly but i dont care
            if (drawPlayer.HeldItem.magic)
            {
                texture = DraedonHelmetTextureCache.magic;
            }
            if (drawPlayer.HeldItem.summon)
            {
                texture = DraedonHelmetTextureCache.summoner;
            }
            if (drawPlayer.HeldItem.ranged)
            {
                texture = DraedonHelmetTextureCache.ranger;
            }
            if (drawPlayer.HeldItem.thrown)
            {
                texture = DraedonHelmetTextureCache.rogue;
            }
            if (drawPlayer.HeldItem.melee)
            {
                texture = DraedonHelmetTextureCache.melee;
            }

            if (texture == DraedonHelmetTextureCache.none)
                return;

            float drawX = (int)(drawInfo.position.X - Main.screenPosition.X - (drawPlayer.bodyFrame.Width / 2) + (drawPlayer.width / 2));
            float drawY = (int)(drawInfo.position.Y - Main.screenPosition.Y + drawPlayer.height - drawPlayer.bodyFrame.Height + 4);

            Vector2 position = new Vector2(drawX, drawY) + drawPlayer.headPosition + drawInfo.headOrigin;

            Rectangle frame = drawPlayer.bodyFrame;

            Color color = Lighting.GetColor(
                (int)(drawInfo.position.X + drawPlayer.width * 0.5) / 16,
                (int)(drawInfo.position.Y + drawPlayer.height * 0.25) / 16,
                Color.White);

            float alpha = (255 - drawPlayer.immuneAlpha) / 255f;

            float rotation = drawPlayer.headRotation;

            Vector2 origin = drawInfo.headOrigin;

            SpriteEffects spriteEffects = drawInfo.spriteEffects;

            DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0);

            drawData.shader = drawInfo.headArmorShader;

            Main.playerDrawData.Add(drawData);
        });

        public static readonly PlayerLayer DraedonChestplate = new PlayerLayer("CalValEX", "DraedonChestplate", PlayerLayer.Body, delegate (PlayerDrawInfo drawInfo) {

            if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
                return;

            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("CalValEX");

            if (drawPlayer.body != mod.GetEquipSlot("DraedonChestplate", EquipType.Body))
                return;

            Texture2D texture = DraedonHelmetTextureCache.none;
            //ugly but i dont care
            if (drawPlayer.HeldItem.magic)
            {
                texture = DraedonChestplateCache.magic;
            }
            if (drawPlayer.HeldItem.summon)
            {
                texture = DraedonChestplateCache.summoner;
            }
            if (drawPlayer.HeldItem.ranged)
            {
                texture = DraedonChestplateCache.ranger;
            }
            if (drawPlayer.HeldItem.thrown)
            {
                texture = DraedonChestplateCache.rogue;
            }
            if (drawPlayer.HeldItem.melee)
            {
                texture = DraedonChestplateCache.melee;
            }

            if (texture == DraedonChestplateCache.none)
                return;

            float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
            float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.bodyFrame.Height / 2 + 4f;

            Vector2 origin = drawInfo.bodyOrigin;

            Vector2 position = new Vector2(drawX, drawY) + drawPlayer.bodyPosition - Main.screenPosition;

            float alpha = (255 - drawPlayer.immuneAlpha) / 255f;

            Color color = Lighting.GetColor(
               (int)(drawInfo.position.X + drawPlayer.width * 0.5) / 16,
               (int)(drawInfo.position.Y + drawPlayer.height * 0.5) / 16,
               Color.White);

            Rectangle frame = drawPlayer.bodyFrame;

            float rotation = drawPlayer.bodyRotation;

            SpriteEffects spriteEffects = drawInfo.spriteEffects;

            DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0);

            drawData.shader = drawInfo.bodyArmorShader;

            Main.playerDrawData.Add(drawData);
        });
    }
}