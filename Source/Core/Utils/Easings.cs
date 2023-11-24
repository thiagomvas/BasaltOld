using System.Numerics;

namespace Basalt.Source.Core.Utils
{
    public static class Easings
    {
        public enum EasingType { Linear, InQuad, OutQuad, InOutQuad, InCubic, OutCubic, InOutCubic, InQuart, OutQuart, InOutQuart, InQuint, OutQuint, InOutQuint }

        public static T GetEasing<T>(EasingType type, T t) where T : INumber<T>
        {
            switch (type)
            {
                case EasingType.Linear:
                    return Linear(t);
                case EasingType.InQuad:
                    return InQuad(t);
                case EasingType.OutQuad:
                    return OutQuad(t);
                case EasingType.InOutQuad:
                    return InOutQuad(t);
                case EasingType.InCubic:
                    return InCubic(t);
                case EasingType.OutCubic:
                    return OutCubic(t);
                case EasingType.InOutCubic:
                    return InOutCubic(t);
                case EasingType.InQuart:
                    return InQuart(t);
                case EasingType.OutQuart:
                    return OutQuart(t);
                case EasingType.InOutQuart:
                    return InOutQuart(t);
                case EasingType.InQuint:
                    return InQuint(t);
                case EasingType.OutQuint:
                    return OutQuint(t);
                case EasingType.InOutQuint:
                    return InOutQuint(t);
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
        
        public static T Two<T>(this T t) where T : INumber<T> => T.One + T.One;
        public static T Linear<T>(T t) where T : INumber<T> => t;

        public static T InQuad<T>(T t) where T : INumber<T> => t * t;
        public static T OutQuad<T>(T t) where T : INumber<T> => T.One - InQuad(T.One - t);
        public static T InOutQuad<T>(T t) where T : INumber<T>
        {
            if (t < T.One / (t.Two())) return InQuad(t * t.Two()) / t.Two();
            return T.One - InQuad((T.One - t) / t.Two()) / t.Two();
        }

        public static T InCubic<T>(T t) where T : INumber<T> => t * t * t;
        public static T OutCubic<T>(T t) where T : INumber<T> => T.One - InCubic(T.One - t);
        public static T InOutCubic<T>(T t) where T : INumber<T>
        {
            if (t < T.One / (t.Two())) return InCubic(t * t.Two()) / t.Two();
            return T.One - InCubic((T.One - t) * t.Two()) / t.Two();
        }

        public static T InQuart<T>(T t) where T : INumber<T> => t * t * t * t;
        public static T OutQuart<T>(T t) where T : INumber<T> => T.One - InQuart(T.One - t);
        public static T InOutQuart<T>(T t) where T : INumber<T>
        {
            if (t < T.One / (t.Two())) return InQuart(t * t.Two()) / t.Two();
            return T.One - InQuart((T.One - t) * t.Two()) / t.Two();
        }

        public static T InQuint<T>(T t) where T : INumber<T> => t * t * t * t * t;
        public static T OutQuint<T>(T t) where T : INumber<T> => T.One - InQuint(T.One - t);

        public static T InOutQuint<T>(T t) where T : INumber<T>
        {
            if (t < T.One / (t.Two())) return InQuint(t * t.Two()) / t.Two();
            return T.One - InQuint((T.One - t) * t.Two()) / t.Two();
        }

    }
}