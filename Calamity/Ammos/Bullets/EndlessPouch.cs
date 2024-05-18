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
    public class BloodfirePouch : BaseAmmo
    {
        public override int AmmunitionID => ModLoader.GetMod("CalamityMod").Find<ModItem>("BloodfireBullet").Type;
    }

    public class BubonicPouch : BaseAmmo
    {
        public override int AmmunitionID => ModLoader.GetMod("CalamityMod").Find<ModItem>("BubonicRound").Type;
    }
    public class DryadsTearPouch : BaseAmmo
    {
        public override int AmmunitionID => ModLoader.GetMod("CalamityMod").Find<ModItem>("DryadsTear").Type;
    }
    public class FlashPouch : BaseAmmo
    {
        public override int AmmunitionID => ModLoader.GetMod("CalamityMod").Find<ModItem>("FlashRound").Type;
    }
    public class GodSlayerPouch : BaseAmmo
    {
        public override int AmmunitionID => ModLoader.GetMod("CalamityMod").Find<ModItem>("GodSlayerSlug").Type;
    }
    public class HailstormPouch : BaseAmmo
    {
        public override int AmmunitionID => ModLoader.GetMod("CalamityMod").Find<ModItem>("HailstormBullet").Type;
    }
    public class HallowPointPouch : BaseAmmo
    {
        public override int AmmunitionID => ModLoader.GetMod("CalamityMod").Find<ModItem>("HallowPointRound").Type;
    }
    public class HolyFirePouch : BaseAmmo
    {
        public override int AmmunitionID => ModLoader.GetMod("CalamityMod").Find<ModItem>("HolyFireBullet").Type;
    }
    public class HyperiusPouch : BaseAmmo
    {
        public override int AmmunitionID => ModLoader.GetMod("CalamityMod").Find<ModItem>("HyperiusBullet").Type;
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
}