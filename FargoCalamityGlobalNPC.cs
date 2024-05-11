using FargoCalamity.Calamity.Enchantments;
using FargoCalamity.Calamity.Essences;
using FargoCalamity.Calamity.Forces;
using FargoCalamity.Calamity.Souls;
//using FargoCalamity.Calamity.Ammos.Arrows;
//using FargoCalamity.Calamity.Ammos.Bullets;
using FargoCalamity.NPCs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using FargoCalamity.NPCs;
using System.Security.Cryptography.X509Certificates;

namespace FargoCalamity
{
    internal class FargoCalamityGlobalNPC : GlobalNPC
    {
        // int counter = 0;
        // private NPCShop npcShop1;
        // private NPCShop npcShop2;
        // public override bool InstancePerEntity => true;
        // public FargoCalamityGlobalNPC()
        // {
        //     DarkSquirrel darkSquirrel = ModContent.GetInstance<DarkSquirrel>();
        //     npcShop1 = darkSquirrel.NpcShop1;
        //     npcShop2 = darkSquirrel.NpcShop2;
        //     darkSquirrel.AddShops();
        //     npcShop1.Register();
        //     npcShop2.Register();
        // }

        public override void ModifyShop(NPCShop shop)
        {
            if (shop.NpcType != ModLoader.GetMod("FargoCalamity").Find<ModNPC>("DarkSquirrel").Type)
            {
                return;
            }

            Mod fargoCalamity = ModLoader.GetMod("FargoCalamity");

            Dictionary<string, Type> enchantTypes = new Dictionary<string, Type>
            {
                { "AerospecEnchant", typeof(AerospecEnchant) },
                { "AstralEnchant", typeof(AstralEnchant) },
                { "AtaxiaEnchant", typeof(AtaxiaEnchant) },
                { "AuricEnchant", typeof(AuricEnchant) },
                { "BloodflareEnchant", typeof(BloodflareEnchant) },
                { "BrimflameEnchant", typeof(BrimflameEnchant) },
                { "DaedalusEnchant", typeof(DaedalusEnchant) },
                { "DemonShadeEnchant", typeof(DemonShadeEnchant) },
                { "FathomSwarmerEnchant", typeof(FathomSwarmerEnchant) },
                { "FearmongerEnchant", typeof(FearmongerEnchant) },
                { "GodSlayerEnchant", typeof(MolluskEnchant) },
                { "OmegaBlueEnchant", typeof(OmegaBlueEnchant) },
                { "PlagueReaperEnchant", typeof(PlagueReaperEnchant) },
                { "ReaverEnchant", typeof(ReaverEnchant) },
                { "SilvaEnchant", typeof(SilvaEnchant) },
                { "SnowRuffianEnchant", typeof(SnowRuffianEnchant) },
                { "StatigelEnchant", typeof(StatigelEnchant) },
                { "SulphurousEnchant", typeof(SulphurousEnchant) },
                { "TarragonEnchant", typeof(TarragonEnchant) },
                { "UmbraphileEnchant", typeof(UmbraphileEnchant) },
                { "VictideEnchant", typeof(VictideEnchant) },
                { "WulfrumEnchant", typeof(WulfrumEnchant) },
                { "XerocEnchant", typeof(XerocEnchant) },
                { "RogueEssence", typeof(RogueEssence) },
                { "AnnihilationForce", typeof(AnnihilationForce) },
                { "DesolationForce", typeof(DesolationForce) },
                { "DevastationForce", typeof(DevastationForce) },
                { "ExaltationForce", typeof(ExaltationForce) },
                { "CalamitySoul", typeof(CalamitySoul) },
                { "RogueSoul", typeof(RogueSoul) },
                { "SoulOfEternity", typeof(SoulOfEternity) },
                { "universe", typeof(universe) },
            };

            foreach (KeyValuePair<string, Type> enchantType in enchantTypes)
            {
                ModItem modItem = fargoCalamity.Find<ModItem>(enchantType.Key);
                if (modItem != null)
                {
                    int enchantItemType = modItem.Item.type;
                    shop.Add(enchantItemType, new Condition("HasItem", () =>
                    {
                        return Main.LocalPlayer.HasItem(enchantItemType);
                    }));
                }
            }
        }
    }
}
            // { "IcecleQuiver", typeof(IcecleQuiver)},
            // { "ArcticQuiver", typeof(ArcticQuiver)},
            // { "BloodfireQuiver", typeof(BloodfireQuiver)},
            // { "VanquisherQuiver", typeof(VanquisherQuiver)},
            // { "TerraQuiver", typeof(TerraQuiver)},
            // { "ElysianQuiver", typeof(ElysianQuiver)},
            // { "NapalmQuiver", typeof(NapalmQuiver)},
            // { "AccelerationPouch", typeof(AccelerationPouch)},
            // { "BloodfirePouch", typeof(BloodfirePouch)},
            // { "BubonicPouch", typeof(BubonicPouch)},
            // { "EnhancedNanoPouch", typeof(EnhancedNanoPouch)},
            // { "FlashPouch", typeof(FlashPouch)},
            // { "GodSlayerPouch", typeof(GodSlayerPouch)},
            // { "HolyFirePouch",typeof(HolyFirePouch)},
            // { "HyperiusPouch", typeof(HyperiusPouch)},
            // { "IcyPouch", typeof(IcyPouch)},
            // { "MarksmanPouch", typeof(MarksmanPouch)},
            // { "MortarPouch", typeof(MortarPouch)},
            // { "RubberMortarPouch", typeof(RubberMortarPouch)},
            // { "SuperballPouch", typeof(SuperballPouch)},
            // { "VeriumPouch", typeof(VeriumPouch)},
        /*};

            foreach (KeyValuePair<string, Type> enchantType in enchantTypes)
            {
                //counter = 0;
                ModItem modItem = fargoCalamity.Find<ModItem>(enchantType.Key);
                if (modItem != null)
                {
                    int enchantItemType = modItem.Item.type;
                    
                    //if (counter <= 39)
                    //{
                        shop.Add(enchantItemType, new Condition("HasItem", () =>
                        {
                            return Main.LocalPlayer.HasItem(enchantItemType);
                        }));*/
                        //if (Main.LocalPlayer.HasItem(enchantItemType)) counter++;
                    //}
                    // else
                    // {
                    //     npcShop2.Add(enchantItemType, new Condition("HasItem", () =>
                    //     {
                    //         return Main.LocalPlayer.HasItem(enchantItemType);
                    //     }));
                    // }
        
