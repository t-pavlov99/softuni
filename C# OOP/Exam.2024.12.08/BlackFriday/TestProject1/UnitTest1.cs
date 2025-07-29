using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BlackFriday;
using BlackFriday.Models.Contracts;
using BlackFriday.Repositories.Contracts;
using NUnit.Framework;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

[TestFixture]
public class Tests_1002
{
    // MUST exist within project, otherwise a Compile Time Error will be thrown.
    private static readonly Assembly ProjectAssembly = typeof(StartUp).Assembly;


    [Test]
    public void ValidateProductProperties()
    {
        var type = GetType("Product");

        var properties = new[]
        {
            new Property(typeof(string), "ProductName", "Private"),
            new Property(typeof(double), "BasePrice", "Private"),
            new Property(typeof(double), "BlackFridayPrice", "Family"),
            new Property(typeof(bool), "IsSold", "Private"),
        };

        ValidateProperties(type, properties);
    }
    private class Property
    {
        public Property(Type type, string name, string modifier)
        {
            this.Type = type;
            this.Name = name;
            this.Modifier = modifier;
        }

        public Type Type { get; }

        public string Name { get; }

        public string Modifier { get; }
    }

    private static void ValidateProperties(Type type, IEnumerable<Property> properties)
    {
        foreach (var expectedProperty in properties)
        {
            var expectedType = expectedProperty.Type;
            var propertyName = expectedProperty.Name;
            var modifier = expectedProperty.Modifier;

            var actualProperty = type.GetProperty(propertyName);
            Assert.That(actualProperty, Is.Not.Null, $"{type}.{propertyName} does not exist!");

            var propertySetResult = GetAccessModifier(actualProperty);
            Assert.That(propertySetResult, Is.EqualTo(modifier).Or.EqualTo(null), $"Set method doesn't have correct access modifier!");

            var actualType = actualProperty.PropertyType;
            Assert.That(actualType, Is.EqualTo(expectedType), $"{type}.{propertyName} has the wrong type!");
        }
    }

    private static string GetAccessModifier(PropertyInfo actualProperty)
    {
        if (actualProperty.SetMethod == null)
            return null;

        if (actualProperty.SetMethod.IsPrivate)
            return "Private";

        if (actualProperty.SetMethod.IsPublic)
            return "Public";

        if (actualProperty.SetMethod.IsFamily)
            return "Family";

        return null;
    }

    private static Type GetCollectionType(Type modelType)
    {
        var collectionType = typeof(ICollection<>).MakeGenericType(modelType);
        return collectionType;
    }

    private static Type GetType(string name)
    {
        var type = ProjectAssembly
            .GetTypes()
            .FirstOrDefault(t => t.Name == name);

        return type;
    }
}