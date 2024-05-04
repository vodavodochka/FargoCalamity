using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using CalamityMod;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Melee;

namespace FargoCalamity.Calamity.Ammos.Bullets
{
    public class AccelerationPouch : BaseAmmo
    {
        public override int AmmunitionID => ModLoader.GetMod("CalamityMod").Find<ModItem>("AccelerationRound").Type;
    }

    public class BloodfirePouch : BaseAmmo
    {
        public override int AmmunitionID => ModLoader.GetMod("CalamityMod").Find<ModItem>("BloodfireBullet").Type;
    }

    public class BubonicPouch : BaseAmmo
    {
        public override int AmmunitionID => ModLoader.GetMod("CalamityMod").Find<ModItem>("BubonicRound").Type;
    }

    public class EnhancedNanoPouch : BaseAmmo
    {
        public override int AmmunitionID => ModLoader.GetMod("CalamityMod").Find<ModItem>("EnhancedNanoRound").Type;
    }

    public class FlashPouch : BaseAmmo
    {
        public override int AmmunitionID => ModLoader.GetMod("CalamityMod").Find<ModItem>("FlashRound").Type;
    }

    public class GodSlayerPouch : BaseAmmo
    {
        public override int AmmunitionID => ModLoader.GetMod("CalamityMod").Find<ModItem>("GodSlayerSlug").Type;
    }

    public class HolyFirePouch : BaseAmmo
    {
        public override int AmmunitionID => ModLoader.GetMod("CalamityMod").Find<ModItem>("HolyFireBullet").Type;
    }

    public class HyperiusPouch : BaseAmmo
    {
        public override int AmmunitionID => ModLoader.GetMod("CalamityMod").Find<ModItem>("HyperiusBullet").Type;
    }

    public class IcyPouch : BaseAmmo
    {
        public override int AmmunitionID => ModLoader.GetMod("CalamityMod").Find<ModItem>("IcyBullet").Type;
    }

    public class MarksmanPouch : BaseAmmo
    {
        public override int AmmunitionID => ModLoader.GetMod("CalamityMod").Find<ModItem>("MarksmanRound").Type;
    }

    public class MortarPouch : BaseAmmo
    {
        public override int AmmunitionID => ModLoader.GetMod("CalamityMod").Find<ModItem>("MortarRound").Type;
    }

    public class RubberMortarPouch : BaseAmmo
    {
        public override int AmmunitionID => ModLoader.GetMod("CalamityMod").Find<ModItem>("RubberMortarRound").Type;
    }

    public class SuperballPouch : BaseAmmo
    {
        public override int AmmunitionID => ModLoader.GetMod("CalamityMod").Find<ModItem>("TerraBullet").Type;
    }

    public class VeriumPouch : BaseAmmo
    {
        public override int AmmunitionID => ModLoader.GetMod("CalamityMod").Find<ModItem>("MarksmanRound").Type;
    }
}