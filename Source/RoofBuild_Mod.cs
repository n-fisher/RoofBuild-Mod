using RimWorld;
using UnityEngine;
using Verse;

namespace RoofBuild_Mod
{
    public class Designator_AreaBuildRoofMod : Designator_AreaBuildRoof
    {
        private DesignateMode mode;

        public Designator_AreaBuildRoofMod()
        {
            mode = DesignateMode.Add;
            defaultLabel = "Bounded build roof area";
            defaultDesc = "Colonists will build roofs in this area. Does not select unroofable areas.";
            icon = ContentFinder<Texture2D>.Get("UI/Designators/BuildRoofArea", true);
        }

        public override AcceptanceReport CanDesignateCell(IntVec3 c)
        {
            return c.InBounds(Map) &&
                !c.Fogged(Map) &&
                RoofCollapseUtility.WithinRangeOfRoofHolder(c, Map, true);
        }
    }
}
