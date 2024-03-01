using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CalamityMod.Items;
using CalamityMod.Items.Armor.Umbraphile;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Pets;

namespace FargoCalamity.Calamity.Enchantments
{
    public class UmbraphileEnchant : ModItem
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
            Item.value = 300000;
        }
        


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //int[] buf = player.buffType;
            //Main.NewText(Convert.ToString(ModLoader.GetMod("Fargowiltas").Find<ModNPC>("Squirrel").Type));
            
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            if (SoulConfig.Instance.calamityToggles.UmbraphileArmour)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("UmbraphileHood").UpdateArmorSet(player);
            }
            if (SoulConfig.Instance.calamityToggles.ThiefsDime)
            {
                player.AddBuff(434 , 18000, true, false);
               //ModLoader.GetMod("CalamityMod").Find<ModBuff>("ThiefsDime").Update(player, ref buffIndex);
            }
            if (SoulConfig.Instance.calamityToggles.VampiricTalisman)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("VampiricTalisman").UpdateAccessory(player, hideVisual);
            }
            if (SoulConfig.Instance.calamityToggles.MomentumCapacitor)  
            {
               ModLoader.GetMod("CalamityMod").Find<ModItem>("MomentumCapacitor").UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ModContent.ItemType<UmbraphileHood>());
            recipe.AddIngredient(ModContent.ItemType<UmbraphileRegalia>());
            recipe.AddIngredient(ModContent.ItemType<UmbraphileBoots>());
            recipe.AddIngredient(ModContent.ItemType<ThiefsDime>());
            recipe.AddIngredient(ModContent.ItemType<VampiricTalisman>());
            recipe.AddIngredient(ModContent.ItemType<MomentumCapacitor>());
            
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();
        }
    }
}
