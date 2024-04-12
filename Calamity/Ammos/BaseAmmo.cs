using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using CalamityMod;
using CalamityMod.Items.Armor.Aerospec;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Pets;
using CalamityMod.Buffs.Pets;
using CalamityMod.Projectiles.Pets;


namespace FargoCalamity.Calamity
{
    public abstract class BaseAmmo : ModItem
    {
        public abstract int AmmunitionID { get; }


        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(AmmunitionID);
            Item.width = 26;
            Item.height = 26;
            Item.consumable = false;
            Item.maxStack = 1;
            Item.value *= 3996;
            Item.rare += 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(AmmunitionID, 3996)
                .AddTile(ModLoader.GetMod("CalamityMod").Find<ModTile>("CosmicAnvilItem").Type)
                .Register();
        }
    }
}
