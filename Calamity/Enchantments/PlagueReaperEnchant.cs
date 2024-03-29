﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Armor.PlagueReaper;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Magic;
using System;
using CalamityMod.Projectiles.Rogue;
using CalamityMod;

namespace FargoCalamity.Calamity.Enchantments
{
    public class PlagueReaperEnchant : ModItem
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
            Item.value = 300000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            if (SoulConfig.Instance.calamityToggles.PlagueReaperArmour)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("PlagueReaperMask").UpdateArmorSet(player);
            }
            if (SoulConfig.Instance.calamityToggles.PlagueHive)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("PlagueHive").UpdateAccessory(player, hideVisual);
            }
            if (SoulConfig.Instance.calamityToggles.PlaguedFuelPack)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("PlaguedFuelPack").UpdateAccessory(player, hideVisual);
            }
            if (SoulConfig.Instance.calamityToggles.TheCamper)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("TheCamper").UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

           Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ModContent.ItemType<PlagueReaperMask>());
            recipe.AddIngredient(ModContent.ItemType<PlagueReaperVest>());
            recipe.AddIngredient(ModContent.ItemType<PlagueReaperStriders>());
            recipe.AddIngredient(ModContent.ItemType<PlagueHive>());
            recipe.AddIngredient(ModContent.ItemType<PlaguedFuelPack>());
            recipe.AddIngredient(ModContent.ItemType<TheCamper>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();
        }
    }
}
