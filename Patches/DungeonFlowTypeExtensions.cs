using System;
using System.Collections.Generic;

namespace FacilityOrMansion.Patches
{
    public static class DungeonFlowTypeExtensions
    {
        public static IntWithRarity[] SetDungeonFlowTypeRarity(this RoundManager manager)
        {
            FacilityOrMansionBase.mls.LogInfo("Entered SetDungeonFlowTypeRarity");
            List<IntWithRarity> list = new List<IntWithRarity>();

            for (int i = 0; i < manager.dungeonFlowTypes.Length; i++)
            {
                IntWithRarity intWithRarity = new IntWithRarity();
                intWithRarity.id = i;

                FacilityOrMansionBase.mls.LogInfo("DungeonFlow Name = " + manager.dungeonFlowTypes[i].dungeonFlow.name);

                int mansionRarity = FacilityOrMansionBase.mansionOnly.Value ? 150 : 0;
                int facilityRarity = FacilityOrMansionBase.facilityOnly.Value ? 300 : 0;

                intWithRarity.rarity = mansionRarity > facilityRarity ? mansionRarity : facilityRarity;

                FacilityOrMansionBase.mls.LogInfo(string.Format("New Rarity = {0}", intWithRarity.rarity));
                list.Add(intWithRarity);
            }

            return list.ToArray();
        }
    }
}
