using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.Localization;
using CalamityMod.Items.Armor.Bloodflare;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Summon;
using CalamityMod.Items.Pets;
using FargoCalamity.Calamity.Enchantments;

namespace FargoCalamity.Calamity.Enchantments
{
    public class BloodflareEnchant : ModItem
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
            Item.value = 3000000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.BloodflareArmour))
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("BloodflareHeadMelee").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("BloodflareHeadMagic").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("BloodflareHeadRanged").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("BloodflareHeadRogue").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("BloodflareHeadSummon").UpdateArmorSet(player);
            }

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.ChaliceOfTheBloodGod))
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("ChaliceOfTheBloodGod").UpdateAccessory(player, hideVisual);
            }
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.EldritchSoulArtifact))
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("EldritchSoulArtifact").UpdateAccessory(player, hideVisual);
            }
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("BrimflameEnchant").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddRecipeGroup("FargoCalamity:AnyBloodflareHelmet");
            recipe.AddIngredient(ModContent.ItemType<BloodflareBodyArmor>());
            recipe.AddIngredient(ModContent.ItemType<BloodflareCuisses>());
            recipe.AddIngredient(ModContent.ItemType<BrimflameEnchant>());
            recipe.AddIngredient(ModContent.ItemType<ChaliceOfTheBloodGod>());
            recipe.AddIngredient(ModContent.ItemType<EldritchSoulArtifact>());


            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}
