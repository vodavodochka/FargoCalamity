using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CalamityMod.CalPlayer;
using Terraria.Localization;
using System.Collections.Generic;
using CalamityMod.Items.Armor.OmegaBlue;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Weapons.Summon;

namespace FargoCalamity.Calamity.Enchantments
{
    public class OmegaBlueEnchant : ModItem
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
            Item.rare = 13;
            Item.value = 1000000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.OmegaBlueArmour))
                ModLoader.GetMod("CalamityMod").Find<ModItem>("OmegaBlueHelmet").UpdateArmorSet(player);
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.AbyssalDivingSuit))
                ModLoader.GetMod("CalamityMod").Find<ModItem>("AbyssalDivingSuit").UpdateAccessory(player, hideVisual);
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.ReaperToothNecklace))
                ModLoader.GetMod("CalamityMod").Find<ModItem>("ReaperToothNecklace").UpdateAccessory(player, hideVisual);
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.MutatedTruffle))
                ModLoader.GetMod("CalamityMod").Find<ModItem>("MutatedTruffle").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ModContent.ItemType<OmegaBlueHelmet>());
            recipe.AddIngredient(ModContent.ItemType<OmegaBlueChestplate>());
            recipe.AddIngredient(ModContent.ItemType<OmegaBlueTentacles>());

            recipe.AddIngredient(ModContent.ItemType<AbyssalDivingSuit>());
            recipe.AddIngredient(ModContent.ItemType<ReaperToothNecklace>());
            recipe.AddIngredient(ModContent.ItemType<MutatedTruffle>());
            
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}
