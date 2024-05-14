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

namespace FargoCalamity.Calamity.Ammos.Arrows
{
    public class IcecleQuiver : BaseAmmo
    {
        public override int AmmunitionID => ModLoader.GetMod("CalamityMod").Find<ModItem>("IcicleArrow").Type;
    }
    public class BloodfireQuiver : BaseAmmo
    {
        public override int AmmunitionID => ModLoader.GetMod("CalamityMod").Find<ModItem>("BloodfireArrow").Type;
    }
    public class VanquisherQuiver : BaseAmmo
    {
        public override int AmmunitionID => ModLoader.GetMod("CalamityMod").Find<ModItem>("VanquisherArrow").Type;
    }
    public class SproutingQuiver : BaseAmmo
    {
        public override int AmmunitionID => ModLoader.GetMod("CalamityMod").Find<ModItem>("TerraArrow").Type;
    }
    public class ElysianQuiver : BaseAmmo
    {
        public override int AmmunitionID => ModLoader.GetMod("CalamityMod").Find<ModItem>("ElysianArrow").Type;
    }
    public class NapalmQuiver : BaseAmmo
    {
        public override int AmmunitionID => ModLoader.GetMod("CalamityMod").Find<ModItem>("NapalmArrow").Type;
    }
}
