using IdleOfTheAgesLib.UI.Styles;

using System;

using UnityEngine;
using UnityEngine.UIElements;

namespace IdleOfTheAges.UI.Styles {
    public class StyleEntry : IStyleEntry {
        private abstract class StyleData {
            public static implicit operator bool(StyleData style) => style != null;
        }

        private class StyleDataEntry<T> : StyleData where T : struct, IConvertible {
            private readonly T data;

            public static implicit operator StyleEnum<T>(StyleDataEntry<T> entry) => entry.data;
        }

        private class PaddingData : StyleData {
            public StyleLength Top => new(new Length(top, unit));
            public StyleLength Left => new(new Length(left, unit));
            public StyleLength Right => new(new Length(right, unit));
            public StyleLength Bottom => new(new Length(bottom, unit));

            private readonly LengthUnit unit;
            private readonly float top;
            private readonly float left;
            private readonly float right;
            private readonly float bottom;
        }

        private class ColorData : StyleData {
            public StyleColor Top => new(top);
            public StyleColor Left => new(left);
            public StyleColor Right => new(right);
            public StyleColor Bottom => new(bottom);

            private Color top;
            private Color left;
            private Color right;
            private Color bottom;
        }

        private class StyleUnitEntry : StyleData {
            private readonly float data;
            private readonly LengthUnit unit;

            public static implicit operator StyleLength(StyleUnitEntry value) => new(new Length(value.data, value.unit));
        }

        private class StyleColorEntry : StyleData {
            private Color data;

            public static implicit operator StyleColor(StyleColorEntry value) => new(value.data);
        }

        public string Name => name;

        public string LinkedStyle => linkedStyle;

        private readonly string name;
        private readonly string linkedStyle;
        private readonly StyleDataEntry<FlexDirection> flexDirection;
        private readonly StyleDataEntry<DisplayStyle> displayStyle;
        private readonly StyleDataEntry<Overflow> overflow;
        private readonly StyleDataEntry<Align> alignContent;
        private readonly StyleDataEntry<Align> alignItems;
        private readonly StyleDataEntry<Position> position;
        private readonly PaddingData padding;
        private readonly PaddingData margin;
        private readonly PaddingData offset;
        private readonly StyleUnitEntry height;
        private readonly StyleUnitEntry width;
        private readonly StyleColorEntry backgroundColor;
        private readonly StyleColorEntry mainColor;
        private readonly ColorData borderColor;

        public void ApplyToStyle(IStyle style) {
            if (flexDirection)
                style.flexDirection = flexDirection;

            if (displayStyle)
                style.display = displayStyle;

            if (overflow)
                style.overflow = overflow;

            if (alignContent)
                style.alignContent = alignContent;

            if (alignItems)
                style.alignItems = alignItems;

            if (position)
                style.position = position;

            if (padding) {
                style.paddingTop = padding.Top;
                style.paddingLeft = padding.Left;
                style.paddingRight = padding.Right;
                style.paddingBottom = padding.Bottom;
            }

            if (margin) {
                style.marginTop = margin.Top;
                style.marginLeft = margin.Left;
                style.marginRight = margin.Right;
                style.marginBottom = margin.Bottom;
            }

            if (height)
                style.height = height;

            if (width)
                style.width = width;

            if (backgroundColor)
                style.backgroundColor = backgroundColor;

            if (mainColor)
                style.color = mainColor;

            if (borderColor) {
                style.borderTopColor = borderColor.Top;
                style.borderLeftColor = borderColor.Left;
                style.borderRightColor = borderColor.Right;
                style.borderBottomColor = borderColor.Bottom;
            }

            if (offset) {
                style.top = offset.Top;
                style.left = offset.Left;
                style.right = offset.Right;
                style.bottom = offset.Bottom;
            }
        }
    }
}
