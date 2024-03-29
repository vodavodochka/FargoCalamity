﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Armor.Statigel;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Summon;

namespace FargoCalamity.Calamity.Enchantments
{
    public class StatigelEnchant : ModItem
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
            Item.value = 200000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            FargoCalamityPlayer modPlayer = player.GetModPlayer<FargoCalamityPlayer>();
            if (SoulConfig.Instance.calamityToggles.StatigelArmour)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("StatigelHeadMelee").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("StatigelHeadMagic").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("StatigelHeadSummon").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("StatigelHeadRogue").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("StatigelHeadRanged").UpdateArmorSet(player);
            }

            if (SoulConfig.Instance.calamityToggles.FungalSymbiote)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("FungalSymbiote").UpdateAccessory(player, hideVisual);
            }
            if (SoulConfig.Instance.calamityToggles.ManaOverloader)            
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("ManaOverloader").UpdateAccessory(player, hideVisual);
            }
            if (SoulConfig.Instance.calamityToggles.CounterScarf)   
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("CounterScarf").UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddRecipeGroup("FargoCalamity:AnyStatigelHelmet");
            recipe.AddIngredient(ModContent.ItemType<StatigelArmor>());
            recipe.AddIngredient(ModContent.ItemType<StatigelGreaves>());
            recipe.AddIngredient(ModContent.ItemType<CounterScarf>());
            recipe.AddIngredient(ModContent.ItemType<ManaPolarizer>());
            recipe.AddIngredient(ModContent.ItemType<FungalSymbiote>());

            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
    }
}
