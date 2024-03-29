﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using CalamityMod.Items.Armor.Sulphurous;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.CalPlayer;
using CalamityMod;
using CalamityMod.Items.Weapons.Summon;
using CalamityMod.Items.Pets;
using CalamityMod.Buffs.Pets;
using CalamityMod.Projectiles.Pets;

namespace FargoCalamity.Calamity.Enchantments
{
    public class SulphurousEnchant : ModItem
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
            Item.value = 50000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            if (SoulConfig.Instance.calamityToggles.SulphurousArmour)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("SulphurousHelmet").UpdateArmorSet(player);
            }
            if (SoulConfig.Instance.calamityToggles.SandCloak)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("SandCloak").UpdateAccessory(player, hideVisual);
            }
            if (SoulConfig.Instance.calamityToggles.AlluringBait)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("AlluringBait").UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ModContent.ItemType<SulphurousHelmet>());
            recipe.AddIngredient(ModContent.ItemType<SulphurousBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<SulphurousLeggings>());
            recipe.AddIngredient(ModContent.ItemType<SandCloak>());
            recipe.AddIngredient(ModContent.ItemType<AlluringBait>());
            recipe.AddIngredient(ModContent.ItemType<CausticCroakerStaff>());


            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
    }
}
