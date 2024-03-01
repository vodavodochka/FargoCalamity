using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Armor.Daedalus;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Pets;
using FargoCalamity.Calamity.Enchantments;

namespace FargoCalamity.Calamity.Enchantments
{
    public class DaedalusEnchant : ModItem
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
            Item.value = 500000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            if (SoulConfig.Instance.calamityToggles.DaedalusArmour)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("DaedalusHeadMelee").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("DaedalusHeadMagic").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("DaedalusHeadSummon").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("DaedalusHeadRanged").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("DaedalusHeadRogue").UpdateArmorSet(player);
            }
            
            if (SoulConfig.Instance.calamityToggles.PermafrostsConcoction)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("PermafrostsConcoction").UpdateAccessory(player, hideVisual);
            }
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("SnowRuffianEnchant").UpdateAccessory(player, hideVisual);            
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddRecipeGroup("FargoCalamity:AnyDaedalusHelmet");
            recipe.AddIngredient(ModContent.ItemType<DaedalusBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<DaedalusLeggings>());
            recipe.AddIngredient(ModContent.ItemType<SnowRuffianEnchant>());
            recipe.AddIngredient(ModContent.ItemType<PermafrostsConcoction>());
            //recipe.AddIngredient(ModContent.ItemType<CrystalBlade>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();
        }
    }
}
