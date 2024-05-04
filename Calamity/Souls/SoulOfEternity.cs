using Terraria;
using Microsoft.Xna.Framework;
using System.Collections.ObjectModel;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Rogue;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Content.Items.Accessories.Expert;
using FargoCalamity.Calamity.Essences;
using FargoCalamity.Calamity.Souls;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Content.Items.Accessories.Masomode;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler.Content;

namespace FargoCalamity.Calamity.Souls
{
    public class SoulOfEternity : FlightMasteryWings
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public override bool HasSupersonicSpeed => true;

        public override bool Eternity => true;
        public override int NumFrames => 10;

        public static int WingSlotID
        {
            get;
            private set;
        }

        public virtual bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            WingSlotID = Item.wingSlot;

            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 10));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.rare = ItemRarityID.Red;
            Item.value = 200000000;
            Item.shieldSlot = 5;
            Item.defense = 100;

            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = 180;
            Item.useAnimation = 180;
            Item.UseSound = SoundID.Item6;
            
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("universe").UpdateAccessory(player, hideVisual);
            ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("DimensionSoul").UpdateAccessory(player, hideVisual);
            ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("TerrariaSoul").UpdateAccessory(player, hideVisual);
            ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("MasochistSoul").UpdateAccessory(player, hideVisual);

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DimensionSoul>());
            recipe.AddIngredient(ModContent.ItemType<TerrariaSoul>());
            recipe.AddIngredient(ModContent.ItemType<MasochistSoul>());
            recipe.AddIngredient(ModContent.ItemType<universe>());
            
            recipe.AddIngredient(ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("EternalEnergy").Type, 10);
            recipe.AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"));

            recipe.Register();
        }
    }
}
