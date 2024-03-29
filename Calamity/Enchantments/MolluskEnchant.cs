﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor.Mollusk;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Fishing.AstralCatches;
using CalamityMod.Items.Fishing.SunkenSeaCatches;
using CalamityMod.Projectiles.Pets;
using CalamityMod.Buffs.Pets;
using FargoCalamity.Calamity.Enchantments;

namespace FargoCalamity.Calamity.Enchantments
{
    public class MolluskEnchant : ModItem
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
            Item.rare = 5;
            Item.value = 150000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            if (SoulConfig.Instance.calamityToggles.MolluskArmour)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("MolluskShellmet").UpdateArmorSet(player);
                player.maxMinions += 4;
            }
            if (SoulConfig.Instance.calamityToggles.GiantPearl)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("GiantPearl").UpdateAccessory(player, hideVisual);
            }
            if (SoulConfig.Instance.calamityToggles.AquaticEmblem)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("AquaticEmblem").UpdateAccessory(player, hideVisual);
            }
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("VictideEnchant").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ModContent.ItemType<MolluskShellmet>());
            recipe.AddIngredient(ModContent.ItemType<MolluskShellplate>());
            recipe.AddIngredient(ModContent.ItemType<MolluskShelleggings>());
            recipe.AddIngredient(ModContent.ItemType<VictideEnchant>());
            recipe.AddIngredient(ModContent.ItemType<GiantPearl>());
            recipe.AddIngredient(ModContent.ItemType<AquaticEmblem>());
            //recipe.AddIngredient(ModContent.ItemType<EnchantedPearl>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();
        }
    }
}
