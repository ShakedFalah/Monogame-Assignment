using Microsoft.Xna.Framework;

namespace MonogameProject.MyEngine.Rendering
{
    internal abstract class PivotObject
    {
        public Pivot SpritePivot { get; private set; } = new Pivot();
        public Vector2 AbsolutePivot
        {
            get
            {
                if (SpritePivot.pivotType == PivotType.relative)
                {
                    return PivotHelper.RelativeToAbsolute(SpritePivot.pivot, Size);
                }

                return SpritePivot.pivot;
            }
        }

        public abstract Vector2 Size { get; }

        public void SetPivot(Pivot origin)
        {
            SpritePivot = origin;
        }

        public void SetPivot(PivotPosition position)
        {
            SpritePivot = PivotHelper.originByPosition[position]();
        }

        public void SetPivot(Vector2 origin, PivotType originType = PivotType.absolute)
        {
            SpritePivot = new Pivot(origin, originType);
        }
    }
}
