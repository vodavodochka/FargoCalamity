using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Armor.Astral;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Summon;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Fishing.AstralCatches;
using CalamityMod.Buffs.Pets;
using CalamityMod.Projectiles.Pets;

namespace FargoCalamity.Calamity.Enchantments
{
    public class AstralEnchant : ModItem
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
            Item.value = 1000000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            if (SoulConfig.Instance.calamityToggles.AstralArmour)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("AstralHelm").UpdateArmorSet(player);
            }
            if (SoulConfig.Instance.calamityToggles.Purity)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("Radiance").UpdateAccessory(player, hideVisual);
            }
            if (SoulConfig.Instance.calamityToggles.GravistarSabaton)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("GravistarSabaton").UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ModContent.ItemType<AstralHelm>());
            recipe.AddIngredient(ModContent.ItemType<AstralBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<AstralLeggings>());
            recipe.AddIngredient(ModContent.ItemType<Radiance>());
            recipe.AddIngredient(ModContent.ItemType<GravistarSabaton>());
            recipe.AddIngredient(ModContent.ItemType<UrsaSergeant>());

            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}
