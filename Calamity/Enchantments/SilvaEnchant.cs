using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.Localization;
using CalamityMod.Items.Armor.Silva;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Pets;
using CalamityMod.Items.Weapons.Magic;

namespace FargoCalamity.Calamity.Enchantments
{
    public class SilvaEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");
        public int dragonTimer = 60;

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
            Item.value = 20000000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.SilvaArmour))
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("SilvaHeadMagic").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("SilvaHeadSummon").UpdateArmorSet(player);
            }
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.TheAmalgam))
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("TheAmalgam").UpdateAccessory(player, hideVisual);
            }
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.GodlySoulArtifact))
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("GodlySoulArtifact").UpdateAccessory(player, hideVisual);
            }
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.YharimsGift))
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("YharimsGift").UpdateAccessory(player, hideVisual);
            }
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.DynamoStemCells))         
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("DynamoStemCells").UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddRecipeGroup("FargoCalamity:AnySilvaHelmet");
            recipe.AddIngredient(ModContent.ItemType<SilvaArmor>());
            recipe.AddIngredient(ModContent.ItemType<SilvaLeggings>());
            recipe.AddIngredient(ModContent.ItemType<TheAmalgam>());
            recipe.AddIngredient(ModContent.ItemType<GodlySoulArtifact>());
            recipe.AddIngredient(ModContent.ItemType<YharimsGift>());

            recipe.AddTile(calamity, "DraedonsForge");
            recipe.Register();
        }
    }
}
