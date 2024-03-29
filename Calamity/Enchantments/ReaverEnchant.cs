﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using CalamityMod.Items.Armor.Reaver;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Summon;
using CalamityMod.Items.Pets;
using CalamityMod.Projectiles.Pets;
using CalamityMod.Buffs.Pets;

namespace FargoCalamity.Calamity.Enchantments
{
    public class ReaverEnchant : ModItem
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
            Item.rare = 7;
            Item.value = 400000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            if (SoulConfig.Instance.calamityToggles.ReaverArmour)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("ReaverHeadTank").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("ReaverHeadExplore").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("ReaverHeadMobility").UpdateArmorSet(player);
            }
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddRecipeGroup("FargoCalamity:AnyReaverHelmet");
            recipe.AddIngredient(ModContent.ItemType<ReaverScaleMail>());
            recipe.AddIngredient(ModContent.ItemType<ReaverCuisses>());
            recipe.AddIngredient(ModContent.ItemType<SandSharknadoStaff>());
            //recipe.AddIngredient(ModContent.ItemType<Triploon>());
            recipe.AddIngredient(ModContent.ItemType<ArcNovaDiffuser>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();
        }
    }
}
