﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Armor.Fearmonger;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Magic;

namespace FargoCalamity.Calamity.Enchantments
{
    public class FearmongerEnchant : ModItem
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
            Item.value = 750000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;
            if (SoulConfig.Instance.calamityToggles.FearmongerArmour)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("FearmongerGreathelm").UpdateArmorSet(player);
            }
            if (SoulConfig.Instance.calamityToggles.SpectralVeil)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("SpectralVeil").UpdateAccessory(player, hideVisual);
            }
            if (SoulConfig.Instance.calamityToggles.StatisBeltOfCurses)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("StatisBeltOfCurses").UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ModContent.ItemType<FearmongerGreathelm>());
            recipe.AddIngredient(ModContent.ItemType<FearmongerPlateMail>());
            recipe.AddIngredient(ModContent.ItemType<FearmongerGreaves>());
            recipe.AddIngredient(ModContent.ItemType<SpectralVeil>());
            recipe.AddIngredient(ModContent.ItemType<StatisCurse>());
            recipe.AddIngredient(ModContent.ItemType<FaceMelter>());


            recipe.AddTile(calamity, "DraedonsForge");
            recipe.Register();
        }
    }
}
