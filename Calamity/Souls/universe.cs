using Terraria;
using Microsoft.Xna.Framework;
using System.Collections.ObjectModel;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.DataStructures;
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

namespace FargoCalamity.Calamity.Souls
{
    public class universe : BaseSoul
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public virtual bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 7));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.value = 5000000;
            Item.rare = -12;
            Item.expert = true;
            Item.defense = 4;

            Item.width = 5;
            Item.height = 5;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("RogueSoul").UpdateAccessory(player, hideVisual);
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("CalamitySoul").UpdateAccessory(player, hideVisual);
            ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("UniverseSoul").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<UniverseCore>());
            recipe.AddIngredient(ModContent.ItemType<BerserkerSoul>());
            recipe.AddIngredient(ModContent.ItemType<SnipersSoul>());
            recipe.AddIngredient(ModContent.ItemType<ArchWizardsSoul>());
            recipe.AddIngredient(ModContent.ItemType<ConjuristsSoul>());
            recipe.AddIngredient(ModContent.ItemType<RogueSoul>());
            recipe.AddIngredient(ModContent.ItemType<CalamitySoul>());
            recipe.AddIngredient(ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("AbomEnergy").Type, 10);
            recipe.AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"));

            recipe.Register();
        }
    }
}
