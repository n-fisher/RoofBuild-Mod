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
            soundDragSustain = SoundDefOf.Designate_DragAreaAdd;
            soundDragChanged = SoundDefOf.Designate_DragStandard_Changed;
            soundSucceeded = SoundDefOf.Designate_AreaAdd;
        }  

        public override AcceptanceReport CanDesignateCell(IntVec3 c)
        {
            if (!c.InBounds(Map))
            { 
                return false;
            }
            if (c.Fogged(Map)) 
            {
                return false;
            }
            if (!RoofCollapseUtility.WithinRangeOfRoofHolder(c, Map, true))
            {
                return false;
            }
            bool flag = Map.areaManager.BuildRoof[c];
            if (mode == DesignateMode.Add)
            {
                return !flag;
            }
            return flag;
        }
    }
}
