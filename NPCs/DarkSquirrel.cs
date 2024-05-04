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
using Terraria.Utilities;
using FargoCalamity;
using FargoCalamity.Calamity.Enchantments;

namespace FargoCalamity.NPCs
{
    [AutoloadHead]
    public class DarkSquirrel : ModNPC
    {
        private static Profiles.DefaultNPCProfile NPCProfile;
        private string ShopName = "DarkSquirrelShop";
        private string ShopName2 = "DarkSquirrelShop2";
        private int count;
        public NPCShop Shop2 { get; private set; }
        private bool shop2Active = false;
        private bool shop1Active = true;
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
            button2 = shop2Active ? "Switch to Shop 1" : "Switch to Shop 2";
        }

        public override string GetChat()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();
            if (Language.ActiveCulture.Name == "en-US")
            {
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
            }
            if (Language.ActiveCulture.Name == "ru-RU")
            {
                chat.Add(Language.GetTextValue("Бла, Бла, я самая болтливая белка в лесу!"));
                chat.Add(Language.GetTextValue("У меня есть жёлуди в изобилии, но я всегда найду место для еще одного!"));
                chat.Add(Language.GetTextValue("Будьте осторожны с этой лисой, она хитрая!"));
                chat.Add(Language.GetTextValue("Бегать по деревьям - мое любимое занятие"));
                chat.Add(Language.GetTextValue("Почему эти птицы не могут перестать воровать мои жёлуди?"));
                chat.Add(Language.GetTextValue("Я мастер в поиске сокрытых сокровищ в лесу."));
                chat.Add(Language.GetTextValue("Я может и маленькая, но я самостоятельна."));
                chat.Add(Language.GetTextValue("Мой пушистый хвост сохраняет меня в тепле и уюте, даже зимой."));
                chat.Add(Language.GetTextValue("Нет ничего лучше, чем хорошая игра в салки с моими беличьими друзьями"));
                chat.Add(Language.GetTextValue("Я могу быть быстрой, но всегда нахожу время, чтобы насладиться красотой леса."));
            }
            string chosenChat = chat;
            return chosenChat;
        }
        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                shop = ShopName;
            }
            else
            {
                shop2Active = !shop2Active;
                NPC.RecalculateShop(this, shop);
            }
        }

        public override void AddShops()
        {
            NPCShop npcShop = new NPCShop(Type, ShopName);
            Shop2 = new NPCShop(Type, ShopName2);

            npcShop.Register();
            Shop2.Register();
        }   
    }
}