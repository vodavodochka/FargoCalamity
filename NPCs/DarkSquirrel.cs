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
using FargoCalamity;
using FargoCalamity.Calamity.Enchantments;
using FargoCalamity.NPCs;
using System.Linq;
using Terraria.Utilities;

namespace FargoCalamity.NPCs
{
    [AutoloadHead]
    public class DarkSquirrel : ModNPC
    {
        private static Profiles.DefaultNPCProfile NPCProfile;
        private string ShopName = "DarkSquirrelShop";
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

            NPC.Happiness.SetNPCAffection(NPCID.Guide, AffectionLevel.Love);
            NPC.Happiness.SetNPCAffection(NPCID.Merchant, AffectionLevel.Love);
            NPC.Happiness.SetNPCAffection(ModLoader.GetMod("Fargowiltas").Find<ModNPC>("Squirrel").Type, AffectionLevel.Hate);

            NPC.Happiness.SetBiomeAffection<ForestBiome>(AffectionLevel.Love);
            NPC.Happiness.SetBiomeAffection<UndergroundBiome>(AffectionLevel.Hate);

            NPCHappiness.AffectionLevelToPriceMultiplier[AffectionLevel.Love] = 0.75f;
            NPCHappiness.AffectionLevelToPriceMultiplier[AffectionLevel.Like] = 0.85f;
            NPCHappiness.AffectionLevelToPriceMultiplier[AffectionLevel.Dislike] = 1.1f;
            NPCHappiness.AffectionLevelToPriceMultiplier[AffectionLevel.Hate] = 1.25f;

            NPCProfile = new Profiles.DefaultNPCProfile(Texture, NPCHeadLoader.GetHeadSlot(HeadTexture), Texture + "_Party");
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 44;
            NPC.height = 42;
            NPC.damage = 0;
            NPC.defense = 40;
            NPC.lifeMax = 2500;
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
        }

        public override string GetChat()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();

            chat.Add(Language.GetTextValue("Chitter chatter, I'm the chattiest squirrel in the forest!"));
            chat.Add(Language.GetTextValue("I've got acorns galore, but I could always use more!"));
            chat.Add(Language.GetTextValue("Watch out for that fox, he's a sly one!"));
            chat.Add(Language.GetTextValue("Scampering up trees is my favorite pastime."));
            chat.Add(Language.GetTextValue("Why can't those birds stop stealing my acorns?"));
            chat.Add(Language.GetTextValue("I'm a master at finding hidden treasures in the forest."));
            chat.Add(Language.GetTextValue("I may be small, but I'm fiercely independent."));
            chat.Add(Language.GetTextValue("My bushy tail keeps me warm and cozy in the winter."));
            chat.Add(Language.GetTextValue("I love nothing more than a good game of chase with my fellow squirrels."));
            chat.Add(Language.GetTextValue("I may be quick, but I always take time to enjoy the beauty of the forest."));
            
            string chosenChat = chat;
            return chosenChat;
        }
        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                shop = ShopName;
            }
        }

        public override void AddShops()
        {
            NPCShop npcShop = new NPCShop(Type, ShopName);
            Mod fargoCalamity = ModLoader.GetMod("FargoCalamity");

            npcShop.Register();
        }
    }
}