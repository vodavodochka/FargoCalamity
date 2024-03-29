﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CalamityMod.Projectiles;
using CalamityMod.Items.Armor.Hydrothermic;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Accessories;

namespace FargoCalamity.Calamity.Enchantments
{
    public class AtaxiaEnchant : ModItem
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
            Item.rare = 8;
            Item.value = 1000000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            if (SoulConfig.Instance.calamityToggles.HydrothermicArmour)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("HydrothermicHeadMelee").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("HydrothermicHeadMagic").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("HydrothermicHeadRanged").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("HydrothermicHeadSummon").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("HydrothermicHeadRogue").UpdateArmorSet(player);
            }
            if (SoulConfig.Instance.calamityToggles.HallowedRune)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("HallowedRune").UpdateAccessory(player, hideVisual);
            }
            if (SoulConfig.Instance.calamityToggles.EtherealExtorter)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("EtherealExtorter").UpdateAccessory(player, hideVisual); 
            }
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddRecipeGroup("FargoCalamity:AnyAtaxiaHelmet");
            recipe.AddIngredient(ModContent.ItemType<HydrothermicArmor>());
            recipe.AddIngredient(ModContent.ItemType<HydrothermicSubligar>());
            recipe.AddIngredient(ModContent.ItemType<HallowedRune>());
            recipe.AddIngredient(ModContent.ItemType<EtherealExtorter>());
            recipe.AddIngredient(ModContent.ItemType<BarracudaGun>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();
        }
    }
}
