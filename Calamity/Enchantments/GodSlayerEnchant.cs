using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using Terraria.Localization;
using CalamityMod.Items.Armor.GodSlayer;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Pets;
using CalamityMod.Items.Weapons.Summon;
using CalamityMod.Items.Armor.Vanity;

namespace FargoCalamity.Calamity.Enchantments
{
    public class GodSlayerEnchant : ModItem
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
            Item.rare = 10;
            Item.value = 10000000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.GodSlayerArmour))
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("GodSlayerHeadMelee").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("GodSlayerHeadRogue").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("GodSlayerHeadRanged").UpdateArmorSet(player);
            }
            
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.NebulousCore))
                ModLoader.GetMod("CalamityMod").Find<ModItem>("NebulousCore").UpdateAccessory(player, hideVisual);
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.DraedonsHeart))
                ModLoader.GetMod("CalamityMod").Find<ModItem>("DraedonsHeart").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddRecipeGroup("FargoCalamity:AnyGodslayerHelmet");
            recipe.AddIngredient(ModContent.ItemType<GodSlayerChestplate>());
            recipe.AddIngredient(ModContent.ItemType<GodSlayerLeggings>());
            recipe.AddIngredient(ModContent.ItemType<NebulousCore>());
            recipe.AddIngredient(ModContent.ItemType<DimensionalSoulArtifact>());
            recipe.AddIngredient(ModContent.ItemType<DraedonsHeart>());


            recipe.AddTile(calamity, "DraedonsForge");
            recipe.Register();
        }
    }
}
