using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace MonogameProject.MyEngine.Rendering
{
    public enum PivotType
    {        
        absolute,
        relative
    }

    public enum PivotPosition
    {
        TopLeft,
        TopCenter,
        TopRight,
        CenterLeft,
        Center,
        CenterRight,
        BottomLeft,
        BottomCenter,
        BottomRight
    }

    public readonly struct Pivot
    {
        public readonly Vector2 pivot;
        public readonly PivotType pivotType;

        public Pivot()
        {
            pivot = new Vector2(0.5f, 0.5f);
            pivotType = PivotType.relative;
        }
        public Pivot(Vector2 pivot, PivotType pivotType = PivotType.absolute)
        {
            this.pivot = pivot;
            this.pivotType = pivotType;
        }
    }
    internal static class PivotHelper
    {
        public static Dictionary<PivotPosition, Func<Pivot>> originByPosition = new Dictionary<PivotPosition, Func<Pivot>> { 
            { PivotPosition.TopLeft, () => new Pivot(new Vector2(0,0), PivotType.relative) },
            { PivotPosition.TopCenter, () => new Pivot(new Vector2(0.5f,0), PivotType.relative) },
            { PivotPosition.TopRight, () => new Pivot(new Vector2(1,0), PivotType.relative) },
            { PivotPosition.CenterLeft, () => new Pivot(new Vector2(0,0.5f), PivotType.relative) },
            { PivotPosition.Center, () => new Pivot(new Vector2(0.5f,0.5f), PivotType.relative) },
            { PivotPosition.CenterRight, () => new Pivot(new Vector2(1,0.5f), PivotType.relative) },
            { PivotPosition.BottomLeft, () => new Pivot(new Vector2(0,1), PivotType.relative) },
            { PivotPosition.BottomCenter, () => new Pivot(new Vector2(0.5f,1), PivotType.relative) },
            { PivotPosition.BottomRight, () => new Pivot(new Vector2(1,1), PivotType.relative) },
        };

    public static Vector2 RelativeToAbsolute(Vector2 relativePivot, Vector2 size)
        {
            return new Vector2(
                relativePivot.X * size.X,
                relativePivot.Y * size.Y);
        }

        public static Vector2 AbsoluteToRelative(Vector2 pivot, Vector2 size)
        {
            return new Vector2(
                pivot.X / size.X,
                pivot.Y / size.Y);
        }
    }
}
