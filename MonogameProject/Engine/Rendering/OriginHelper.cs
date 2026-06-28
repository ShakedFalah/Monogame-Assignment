using Microsoft.Xna.Framework;

namespace MonogameProject.Engine.Rendering
{
    public enum OriginType
    {        
        absolute,
        relative
    }

    public readonly struct SpriteOrigin
    {
        public readonly Vector2 origin = Vector2.Zero;
        public readonly OriginType originType = OriginType.absolute;

        public SpriteOrigin()
        {
            origin = new Vector2(0.5f, 0.5f);
            originType = OriginType.relative;
        }
        public SpriteOrigin(Vector2 origin, OriginType originType = OriginType.absolute)
        {
            this.origin = origin;
            this.originType = originType;
        }
    }
    internal static class OriginHelper
    {
        public static Vector2 RelativeToAbsolute(Vector2 relativeOrigin, Point size)
        {
            return new Vector2(
                relativeOrigin.X * size.X,
                relativeOrigin.Y * size.Y);
        }

        public static Vector2 AbsoluteToRelative(Vector2 origin, Point size)
        {
            return new Vector2(
                origin.X / size.X,
                origin.Y / size.Y);
        }
    }
}
