using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using FargoCalamity.Calamity.Enchantments;

namespace FargoCalamity.NPCs
{
    [AutoloadHead]
    public class DarkSquirrel : ModNPC
    {
        private static Profiles.DefaultNPCProfile NPCProfile;
        private string ShopName = "Shop";
        private int count;
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 6;
            NPCID.Sets.ExtraFramesCount[Type] = 9;
            NPCID.Sets.AttackFrameCount[Type] = 4;
            NPCID.Sets.DangerDetectRange[Type] = 700;
            NPCID.Sets.AttackType[Type] = 0;
            NPCID.Sets.AttackTime[Type] = 90;
            NPCID.Sets.AttackAverageChance[Type] = 30;
            NPCID.Sets.HatOffsetY[Type] = 4;

            NPCID.Sets.CannotSitOnFurniture[Type] = true;

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = -1f,
                Direction = -1
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness.SetBiomeAffection<ForestBiome>(AffectionLevel.Love);
            NPC.Happiness.SetBiomeAffection<UndergroundBiome>(AffectionLevel.Hate);
            //NPC.Happiness.SetNPCAffection<>(AffectionLevel.Like);

            NPCProfile = new Profiles.DefaultNPCProfile(Texture, NPCHeadLoader.GetHeadSlot(HeadTexture), Texture + "_Party");
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 44;
            NPC.height = 42;
            NPC.damage = 0;
            NPC.defense = 0;
            NPC.lifeMax = 100;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = .25f;

            AnimationType = NPCID.Squirrel;
            NPC.aiStyle = NPCAIStyleID.Passive;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            return NPC.downedMoonlord;
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>()
            {
                "Kirs",
                "Sin"
            };
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Shop";
            button2 = "test";
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                shop = "Shop0";
            }
        }

        public void ToggleShops()
        {
            ShopName = "Shop0";
        }

        private static int[] ShopIn = new int[]
        {
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("AeropecEnchant").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("AstralEnchant").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("AtaxiaEnchant").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("AuricEnchant").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("BloodflareEnchant").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("BrimflameEnchant").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("DaedalusEnchant").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("DemonShadeEnchant").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("FathomSwarmerEnchant").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("FearmongerEnchant").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("GodSlayerEnchant").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("MolluskEnchant").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("OmegaBlueEnchant").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("PlagueReaperEnchant").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("ReaverEnchant").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("SilvaEnchant").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("SnowRuffianEnchant").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("StatigelEnchant").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("SulphurousEnchant").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("TarragonEnchant").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("UmbraphileEnchant").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("VictideEnchant").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("WulfrumEnchant").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("XerocEnchant").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("RogueEssence").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("AnnihilationForce").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("DesolationForce").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("DevastationForce").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("ExaltationForce").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("CalamitySoul").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("RogueSoul").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("SoulOfEternity").Type,
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("universe").Type,
        };

        public override void AddShops()
        {
            int c = 0;
            NPCShop npcShop = new NPCShop(Type, ShopName);
            Player player = new Player();
            foreach (int ShopOut in ShopIn)
            {
                if (player.HasItem(ShopOut) && count < 40)
                {
                    npcShop = new NPCShop(Type, ShopName);
                    npcShop.Add(ShopOut);
                    count++;
                }
                else if (player.HasItem(ShopOut))
                {
                    c++;
                    ShopName = "Shop" + Convert.ToString(c);
                    count = 0;
                }
            }
            
        }
    }
}