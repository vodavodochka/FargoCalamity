using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using System.ComponentModel;
using FargowiltasSouls;
using FargowiltasSouls.Core.ModPlayers;
using FargowiltasSouls.Content.Buffs.Boss;

namespace FargoCalamity
{
    class SoulConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;
        public static SoulConfig Instance;

        private void SetAll(bool val)
        {
            IEnumerable<FieldInfo> configs = typeof(SoulConfig).GetFields(BindingFlags.Public | BindingFlags.Instance).Where(i => i.FieldType == true.GetType());
            foreach (FieldInfo config in configs)
            {
                config.SetValue(this, val);
            }
            IEnumerable<FieldInfo> calamityConfigs = typeof(CalamityToggles).GetFields(BindingFlags.Public | BindingFlags.Instance).Where(i => i.FieldType == true.GetType());
            foreach (FieldInfo calamityConfig in calamityConfigs)
            {
                calamityConfig.SetValue(calamityToggles, val);
            }
        }

        [Label("Toggle All On")]
        public bool PresetA
        {
            get => false;
            set
            {
                if (value)
                {
                    SetAll(true);
                }
            }
        }

        [Label("Toggle All Off")]
        public bool PresetB
        {
            get => false;
            set
            {
                if (value)
                {
                    SetAll(false);
                }
            }
        }

        [Label("Header")]
        public CalamityToggles calamityToggles = new CalamityToggles();

        public override void OnLoaded()
        {
            Instance = this;
        }
    }

    public class CalamityToggles
    {
        //XerocEnchantmnet
        [Header("XerocEnchantment")]
        [Label("Empyrean Armour")]
        [DefaultValue(true)]
        public bool EmpyreanArmour;

        [Label("The Community")]
        [DefaultValue(true)]
        public bool TheCommunity;

        //WulfrumEnchantment
        [Header("WulfrumEnchantment")]
        [Label("Trinket of Chi")]
        [DefaultValue(true)]
        public bool TrinketofChi;

        //VictideEnchantment
        [Header("VictideEnchantment")]
        [Label("Victide Armour")]
        [DefaultValue(true)]
        public bool VictideArmour;

        [Label("Ocean Crest")]
        [DefaultValue(true)]
        public bool OceanCrest;

        [Label("Luxor's Gift")]
        [DefaultValue(true)]
        public bool LuxorsGift;

        //UmbraphileEnchantment
        [Header("UmbraphileEnchantment")]
        [Label("Umbraphile Armour")]
        [DefaultValue(true)]
        public bool UmbraphileArmour;

        [Label("Thief's Dime")]
        [DefaultValue(true)]
        public bool ThiefsDime;

        [Label("Vampiric Talisman")]
        [DefaultValue(true)]
        public bool VampiricTalisman;

        [Label("Momentum Capacitor")]
        [DefaultValue(true)]
        public bool MomentumCapacitor;

        //TarragonEnchantment
        [Header("TarragonEnchantment")]
        [Label("Tarragon Armour")]
        [DefaultValue(true)]
        public bool TarragonArmour;

        [Label("Blazing Core")]
        [DefaultValue(true)]
        public bool BlazingCore;

        [Label("Dark Sun Ring")]
        [DefaultValue(true)]
        public bool DarkSunRing;

        //SulphurousEnchantment
        [Header("SulphurousEnchantment")]
        [Label("Sulphurous Armour")]
        [DefaultValue(true)]
        public bool SulphurousArmour;

        [Label("Sand Cloak")]
        [DefaultValue(true)]
        public bool SandCloak;

        [Label("Alluring Bait")]
        [DefaultValue(true)]
        public bool AlluringBait;

        //StatigelEnchantment
        [Header("StatigelEnchantment")]
        [Label("Statigel Armour")]
        [DefaultValue(true)]
        public bool StatigelArmour;

        [Label("Fungal Symbiote")]
        [DefaultValue(true)]
        public bool FungalSymbiote;

        [Label("ManaOverloader")]
        [DefaultValue(true)]
        public bool ManaOverloader;

        [Label("Counter Scarf")]
        [DefaultValue(true)]
        public bool CounterScarf;

        //SnowRuffianEnchantment
        [Header("SnowRuffianEnchantment")]
        [Label("Snow Ruffian Armour")]
        [DefaultValue(true)]
        public bool SnowRuffianArmour;

        [Label("Scuttlers Jewel")]
        [DefaultValue(true)]
        public bool ScuttlersJewel;

        //SilvaEnchantment
        [Header("SilvaEnchantment")]
        [Label("Silva Armour")]
        [DefaultValue(true)]
        public bool SilvaArmour;

        [Label("The Amalgam")]
        [DefaultValue(true)]
        public bool TheAmalgam;

        [Label("Godly Soul Artifact")]
        [DefaultValue(true)]
        public bool GodlySoulArtifact;

        [Label("Yharim's Gift")]
        [DefaultValue(true)]
        public bool YharimsGift;

        [Label("Dynamo Stem Cells")]
        [DefaultValue(true)]
        public bool DynamoStemCells;
        
        //ReaverEnchantment
        [Header("ReaverEnchantment")]
        [Label("Reaver Armour")]
        [DefaultValue(true)]
        public bool ReaverArmour;

        //PlagueReaperEnchantment
        [Header("PlagueReaperEnchantment")]
        [Label("Plague Reaper Armour")]
        [DefaultValue(true)]
        public bool PlagueReaperArmour;

        [Label("Plague Hive")]
        [DefaultValue(true)]
        public bool PlagueHive;

        [Label("Plagued Fuel Pack")]
        [DefaultValue(true)]
        public bool PlaguedFuelPack;

        [Label("The Camper")]
        [DefaultValue(true)]
        public bool TheCamper;

        //OmegaBlueEnchantment
        [Header("OmegaBlueEnchantment")]
        [Label("Omega Blue Armour")]
        [DefaultValue(true)]
        public bool OmegaBlueArmour;

        [Label("Abyssal Diving Suit")]
        [DefaultValue(true)]
        public bool AbyssalDivingSuit;

        [Label("Reaper Tooth Necklace")]
        [DefaultValue(true)]
        public bool ReaperToothNecklace;

        [Label("Mutated Truffle")]
        [DefaultValue(true)]
        public bool MutatedTruffle;

        //MolluskEnchantment
        [Header("MolluskEnchantment")]
        [Label("Mollusk Armour")]
        [DefaultValue(true)]
        public bool MolluskArmour;

        [Label("Giant Pearl")]
        [DefaultValue(true)]
        public bool GiantPearl;

        [Label("Aquatic Emblem")]
        [DefaultValue(true)]
        public bool AquaticEmblem;

        //GodSlayerEnchantment
        [Header("GodSlayerEnchantment")]
        [Label("God Slayer Armour")]
        [DefaultValue(true)]
        public bool GodSlayerArmour;

        [Label("Nebulous Core")]
        [DefaultValue(true)]
        public bool NebulousCore;

        [Label("Draedon's Heart")]
        [DefaultValue(true)]
        public bool DraedonsHeart;

        //FearmongerEnchantment
        [Header("FearmongerEnchantment")]
        [Label("Fearmonger Armour")]
        [DefaultValue(true)]
        public bool FearmongerArmour;

        [Label("Spectral Veil")]
        [DefaultValue(true)]
        public bool SpectralVeil;

        [Label("Statis' Void Sash")]
        [DefaultValue(true)]
        public bool StatisBeltOfCurses;

        //FathomSwarmerEnchantment
        [Header("FathomSwarmerEnchantment")]
        [Label("Fathom Swarmer Armour")]
        [DefaultValue(true)]
        public bool FathomSwarmerArmour;

        [Label("Corrosive Spine")]
        [DefaultValue(true)]
        public bool CorrosiveSpine;

        [Label("Lumenous Amulet")]
        [DefaultValue(true)]
        public bool LumenousAmulet;

        //DemonShadeEnchant
        [Header("DemonShadeEnchantment")]
        [Label("Demon Shade Armour")]
        [DefaultValue(true)]
        public bool DemonshadeArmour;

        [Label("Profaned Soul Crystal")]
        [DefaultValue(true)]
        public bool ProfanedSoulCrystal;

        //DaedalusEnchant
        [Header("DaedalusEnchantment")]
        [Label("Daedalus Armour")]
        [DefaultValue(true)]
        public bool DaedalusArmour;

        [Label("Permafrost's Concoction")]
        [DefaultValue(true)]
        public bool PermafrostsConcoction;

        //BrimflameEnchant
        [Header("BrimflameEnchantment")]
        [Label("Brimflame Armour")]
        [DefaultValue(true)]
        public bool BrimflameArmour;

        //BloodflareEnchantment
        [Header("BloodflareEnchantment")]
        [Label("Bloodflare Armour")]
        [DefaultValue(true)]
        public bool BloodflareArmour;

        [Label("Chalice Of The BloodGod")]
        [DefaultValue(true)]
        public bool ChaliceOfTheBloodGod;

        [Label("EldritchSoulArtifact")]
        [DefaultValue(true)]
        public bool EldritchSoulArtifact;

        //AuricEnchantment
        [Header("AuricEnchantment")]
        [Label("Auric Armour")]
        [DefaultValue(true)]
        public bool AuricArmour;

        [Label("Heart of the Elements")]
        [DefaultValue(true)]
        public bool HeartoftheElements;

        [Label("The Sponge")]
        [DefaultValue(true)]
        public bool TheSponge;

        //AtaxiaEnchantment
        [Header("AtaxiaEnchantment")]
        [Label("Hydrothermic Armour")]
        [DefaultValue(true)]
        public bool HydrothermicArmour;

        [Label("Hallowed Rune")]
        [DefaultValue(true)]
        public bool HallowedRune;

        [Label("Ethereal Extorter")]
        [DefaultValue(true)]
        public bool EtherealExtorter;

        //AstralEnchantment
        [Header("AstralEnchantment")]
        [Label("Astral Armour")]
        [DefaultValue(true)]
        public bool AstralArmour;

        [Label("Purity")]
        [DefaultValue(true)]
        public bool Purity;

        [Label("GravistarSabaton")]
        [DefaultValue(true)]
        public bool GravistarSabaton;

        //AerospecEnchantment
        [Header("AerospecEnchantment")]
        [Label("Aerospec Armour")]
        [DefaultValue(true)]
        public bool AerospecArmour;

        [Label("Gladiator's Locket")]
        [DefaultValue(true)]
        public bool GladiatorsLocket;

        [Label("Unstable Prism")]
        [DefaultValue(true)]
        public bool UnstablePrism;
    }
}
