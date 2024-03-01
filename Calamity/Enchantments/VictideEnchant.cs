using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Armor.Victide;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Fishing.SunkenSeaCatches;

namespace FargoCalamity.Calamity.Enchantments
{
    public class VictideEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public virtual bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.rare = 2;
            Item.value = 80000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            if (SoulConfig.Instance.calamityToggles.VictideArmour)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("VictideHeadMelee").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("VictideHeadRanged").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("VictideHeadMagic").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("VictideHeadSummon").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("VictideHeadRogue").UpdateArmorSet(player);
            }
            if (SoulConfig.Instance.calamityToggles.OceanCrest)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("OceanCrest").UpdateAccessory(player, hideVisual);
            }

            if (SoulConfig.Instance.calamityToggles.LuxorsGift)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("LuxorsGift").UpdateAccessory(player, hideVisual);
            }
        }


        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddRecipeGroup("FargoCalamity:AnyVictideHelmet");
            recipe.AddIngredient(ModContent.ItemType<VictideBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<VictideGreaves>());
            recipe.AddIngredient(ModContent.ItemType<OceanCrest>());
            recipe.AddIngredient(ModContent.ItemType<LuxorsGift>());
            recipe.AddIngredient(ModContent.ItemType<TeardropCleaver>());
            
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
    }
}
