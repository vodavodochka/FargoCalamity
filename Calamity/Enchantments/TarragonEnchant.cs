using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.Localization;
using CalamityMod.Items.Armor.Tarragon;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Magic;

namespace FargoCalamity.Calamity.Enchantments
{
    public class TarragonEnchant : ModItem
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

            if (SoulConfig.Instance.calamityToggles.TarragonArmour)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("TarragonHeadMelee").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("TarragonHeadRanged").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("TarragonHeadSummon").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("TarragonHeadMagic").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("TarragonHeadRogue").UpdateArmorSet(player);
            }
            if (SoulConfig.Instance.calamityToggles.BlazingCore)    
            {   
                ModLoader.GetMod("CalamityMod").Find<ModItem>("BlazingCore").UpdateAccessory(player, hideVisual);
            }
            if (SoulConfig.Instance.calamityToggles.DarkSunRing)  
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("DarkSunRing").UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddRecipeGroup("FargoCalamity:AnyTarragonHelmet");
            recipe.AddIngredient(ModContent.ItemType<TarragonBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<TarragonLeggings>());
            recipe.AddIngredient(ModContent.ItemType<BlazingCore>());
            recipe.AddIngredient(ModContent.ItemType<DarkSunRing>());
            recipe.AddIngredient(ModContent.ItemType<DefiledGreatsword>());

            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}
