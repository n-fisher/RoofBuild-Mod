using RimWorld;
using UnityEngine;
using Verse;

namespace RoofBuild_Mod
{
    public class Designator_AreaBuildRoofExpandMod : Designator_AreaBuildRoofExpand
    {
        private DesignateMode mode;

        public Designator_AreaBuildRoofExpandMod()
        {
            this.mode = DesignateMode.Add;
            this.defaultLabel = "Bounded expand roof area";
            this.defaultDesc = "Colonists will build roofs in this area. Does not select unroofable areas.";
            this.icon = ContentFinder<Texture2D>.Get("UI/Designators/BuildRoofAreaExpand", true);
            this.soundDragSustain = SoundDefOf.DesignateDragAreaAdd;
            this.soundDragChanged = SoundDefOf.DesignateDragAreaAddChanged;
            this.soundSucceeded = SoundDefOf.DesignateAreaAdd;
        }  

        public override AcceptanceReport CanDesignateCell(IntVec3 c)
        {
            if (!c.InBounds(base.Map))
            {
                return false;
            }
            if (c.Fogged(base.Map))
            {
                return false;
            }
            if (!RoofCollapseUtility.WithinRangeOfRoofHolder(c, base.Map))
            {
                return false;
            }
            bool flag = base.Map.areaManager.BuildRoof[c];
            if (this.mode == DesignateMode.Add)
            {
                return !flag;
            }
            return flag;
        }
    }
}
