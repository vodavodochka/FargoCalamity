using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Armor.FathomSwarmer;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Pets;
using CalamityMod.Buffs.Pets;
using CalamityMod.Projectiles.Pets;
using FargoCalamity.Calamity.Enchantments;

namespace FargoCalamity.Calamity.Enchantments
{
    public class FathomSwarmerEnchant : ModItem
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
            if (!FargoCalamity.Instance.CalamityLoaded) return;
            if (SoulConfig.Instance.calamityToggles.FathomSwarmerArmour)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("FathomSwarmerVisage").UpdateArmorSet(player);
            }
            if (SoulConfig.Instance.calamityToggles.CorrosiveSpine)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("CorrosiveSpine").UpdateAccessory(player, hideVisual);
            }
            if (SoulConfig.Instance.calamityToggles.LumenousAmulet)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("LumenousAmulet").UpdateAccessory(player, hideVisual);
            }
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("SulphurousEnchant").UpdateAccessory(player, hideVisual);

            if (Collision.DrownCollision(player.position, player.width, player.height, player.gravDir))
            {
                player.GetDamage(DamageClass.Summon) += 0.1f;
            }
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ModContent.ItemType<FathomSwarmerVisage>());
            recipe.AddIngredient(ModContent.ItemType<FathomSwarmerBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<FathomSwarmerBoots>());
            recipe.AddIngredient(ModContent.ItemType<SulphurousEnchant>());
            recipe.AddIngredient(ModContent.ItemType<CorrosiveSpine>());
            recipe.AddIngredient(ModContent.ItemType<LumenousAmulet>());


            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();
        }
    }
}
