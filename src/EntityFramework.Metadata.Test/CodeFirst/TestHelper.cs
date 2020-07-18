using FluentAssertions;

namespace EntityFramework.Metadata.Test.CodeFirst
{
    public static class TestHelper
    {
        public static IPropertyMap HasColumnName(this IPropertyMap c, string columnName)
        {
            columnName.Should().Be(c.ColumnName,
                $"Property {c.PropertyName} should be mapped to col {columnName}, but was mapped to {c.ColumnName}");
            return c;
        }

        public static IPropertyMap IsPk(this IPropertyMap c, bool isPk = true)
        {
            isPk.Should().Be(c.IsPk, $"Property {c.PropertyName} pk flag should be {isPk}, but was {c.IsPk}");
            return c;
        }

        public static IPropertyMap IsFk(this IPropertyMap c, bool isFk = true)
        {
            isFk.Should().Be(c.IsFk, $"Property {c.PropertyName} fk flag should be {isFk}, but was {c.IsFk}");
            return c;
        }

        public static IPropertyMap FixedLength(this IPropertyMap c, bool fixedLength = true)
        {
            fixedLength.Should().Be(c.FixedLength,
                $"Property {c.PropertyName} fixedLength flag should be {fixedLength}, but was {c.FixedLength}");
            return c;
        }

        public static IPropertyMap Unicode(this IPropertyMap c, bool unicode = true)
        {
            unicode.Should().Be(c.Unicode, $"Property {c.PropertyName} unicode flag should be {unicode}, but was {c.Unicode}");
            return c;
        }

        public static IPropertyMap IsNavigationProperty(this IPropertyMap c, bool isNavProp = true)
        {
            string message = $"Property {c.PropertyName} navigationProperty flag should be {isNavProp}, but was {c.IsNavigationProperty}";
            isNavProp.Should().Be(c.IsNavigationProperty, message);
            return c;
        }

        public static IPropertyMap MaxLength(this IPropertyMap c, int maxLength)
        {
            string message = $"Property {c.PropertyName} max length should be {maxLength}, but was {c.MaxLength}";
            maxLength.Should().Be(c.MaxLength, message);
            return c;
        }

        public static IPropertyMap NavigationPropertyName(this IPropertyMap c, string navigationProperty)
        {
            string message =
                $"Property {c.PropertyName} navigation property should be '{navigationProperty}', but was '{c.NavigationPropertyName}'";
            navigationProperty.Should().Be(c.NavigationPropertyName, message);
            return c;
        }

        public static IPropertyMap ForeignKeyPropertyName(this IPropertyMap c, string fkProperty)
        {
            string message = $"Property {c.PropertyName} fk property should be '{fkProperty}', but was '{c.ForeignKeyPropertyName}'";
            fkProperty.Should().Be(c.ForeignKeyPropertyName, message);
            return c;
        }

        public static IPropertyMap ForeignKey(this IPropertyMap c, IPropertyMap fk)
        {
            string message = $"Property {c.PropertyName} fk does not match";
            fk.Should().Be(c.ForeignKey, message);
            return c;
        }

        public static IPropertyMap NavigationProperty(this IPropertyMap c, IPropertyMap navigationProperty)
        {
            string message = $"Property {c.PropertyName} navigation property does not match";
            navigationProperty.Should().Be(c.NavigationProperty, message);
            return c;
        }

        public static IPropertyMap IsDiscriminator(this IPropertyMap c, bool isDiscriminator = true)
        {
            string message = $"Property {c.PropertyName} discriminator flag should be '{isDiscriminator}', but was '{c.IsDiscriminator}'";
            isDiscriminator.Should().Be(c.IsDiscriminator, message);
            return c;
        }

        public static IPropertyMap IsIdentity(this IPropertyMap c, bool isIdentity = true)
        {
            string message = $"Property {c.PropertyName} identity flag should be '{isIdentity}', but was '{c.IsIdentity}'";
            isIdentity.Should().Be(c.IsIdentity, message);
            return c;
        }

        public static IPropertyMap IsRequired(this IPropertyMap c, bool isRequired = true)
        {
            string message = $"Property {c.PropertyName} required flag should be '{isRequired}', but was '{c.IsRequired}'";
            isRequired.Should().Be(c.IsRequired, message);
            return c;
        }

        public static IPropertyMap HasPrecision(this IPropertyMap c, byte precision)
        {
            string message = string.Format("Property {0} precision should be '{1}', but was '{2}'", c.PropertyName, precision, c.Precision);
            precision.Should().Be(c.Precision, message);
            return c;
        }

        public static IPropertyMap HasScale(this IPropertyMap c, byte scale)
        {
            string message = $"Property {c.PropertyName} scale should be '{scale}', but was '{c.Scale}'";
            scale.Should().Be(c.Scale, message);
            return c;
        }
    }
}