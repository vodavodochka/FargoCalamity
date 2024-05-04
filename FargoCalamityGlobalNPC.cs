using FargoCalamity.Calamity.Enchantments;
using FargoCalamity.Calamity.Essences;
using FargoCalamity.Calamity.Forces;
using FargoCalamity.Calamity.Souls;
using FargoCalamity.Calamity.Ammos.Arrows;
using FargoCalamity.Calamity.Ammos.Bullets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using FargoCalamity.NPCs;

namespace FargoCalamity
{
    internal class FargoCalamityGlobalNPC : GlobalNPC
    {
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
                { "IcecleQuiver", typeof(IcecleQuiver)},
                { "ArcticQuiver", typeof(ArcticQuiver)},
                { "BloodfireQuiver", typeof(BloodfireQuiver)},
                { "VanquisherQuiver", typeof(VanquisherQuiver)},
                { "TerraQuiver", typeof(TerraQuiver)},
                { "ElysianQuiver", typeof(ElysianQuiver)},
                { "NapalmQuiver", typeof(NapalmQuiver)},
                { "AccelerationPouch", typeof(AccelerationPouch)},
                { "BloodfirePouch", typeof(BloodfirePouch)},
                { "BubonicPouch", typeof(BubonicPouch)},
                { "EnhancedNanoPouch", typeof(EnhancedNanoPouch)},
                { "FlashPouch", typeof(FlashPouch)},
                { "GodSlayerPouch", typeof(GodSlayerPouch)},
                { "HolyFirePouch",typeof(HolyFirePouch)},
                { "HyperiusPouch", typeof(HyperiusPouch)},
                { "IcyPouch", typeof(IcyPouch)},
                { "MarksmanPouch", typeof(MarksmanPouch)},
                { "MortarPouch", typeof(MortarPouch)},
                { "RubberMortarPouch", typeof(RubberMortarPouch)},
                { "SuperballPouch", typeof(SuperballPouch)},
                { "VeriumPouch", typeof(VeriumPouch)},
            };

            int shopIndex = shop2Active ? 1 : 0;
            NPCShop currentShop = shopIndex == 0 ? shop : fargoCalamity.GetNPC(shop.NpcType).Shop2;

            foreach (KeyValuePair<string, Type> enchantType in enchantTypes)
            {
                ModItem modItem = fargoCalamity.Find<ModItem>(enchantType.Key);
                if (modItem != null)
                {
                    int enchantItemType = modItem.Item.type;
                    if (!currentShop.Item.Any(item => item.type == enchantItemType))
                    {
                        currentShop.Add(enchantItemType, new Condition("HasItem", () =>
                        {
                            return Main.LocalPlayer.HasItem(enchantItemType);
                        }));
                    }
                    else if (shopIndex == 0)
                    {
                        shop2Active = true;
                        break;
                    }
                }
            }

        }
        public void SwitchShop(NPC npc)
        {
            DarkSquirrel darkSquirrel = (DarkSquirrel)npc.ModNPC;
            darkSquirrel.shop2Active = !darkSquirrel.shop2Active;
            RecalculateShop(npc);
        }
    }
}
