using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace NetTraderSystem.Tests
{
    public class Tests
    {
        TradingPlatform platform;
        List<Product> products;

        [SetUp]
        public void Setup()
        {
            platform = new TradingPlatform(8);
            products = new List<Product>();
            for (int i = 0;  i < 10; i++)
            {
                products.Add(new Product($"P{i}", $"C{i}", i + 8));
            }

        }

        [Test]
        public void Test1()
        {
            Assert.That(platform.Products, Is.Not.Null);
            Assert.That(platform.Products, Has.Count.EqualTo(0));
        }

        [Test]
        public void TestAddingSuccessfully()
        {
            for (int i = 0;i < 8;i++)
            {
                Assert.That(platform.AddProduct(products[i]), Is.EqualTo($"Product {products[i].Name} added successfully"));
            }
        }

        [Test]
        public void TestAddingOverLimit()
        {
            for (int i = 0; i < 8; i++)
            {
                platform.AddProduct(products[i]);
            }
            Assert.That(platform.AddProduct(products[8]), Is.EqualTo("Inventory is full"));
        }

        [Test]
        public void TestRemovingProduct()
        {
            for (int i = 0; i < 8; i++)
            {
                platform.AddProduct(products[i]);
            }
            platform.RemoveProduct(products[7]);
            Assert.That(platform.Products.Count, Is.EqualTo(7));
            Assert.That(platform.Products.SequenceEqual(products.Take(7)), Is.True);
        }

        [Test]
        public void TestRemoveProductWhenEmpty()
        {
            Assert.That(platform.RemoveProduct(products[1]), Is.False);
        }
        [Test]
        public void TestRemoveWhenNonExisting()
        {
            for (int i = 0; i < 8; i++)
            {
                platform.AddProduct(products[i]);
            }
            platform.RemoveProduct(products[8]);
            Assert.That(platform.Products.Count, Is.EqualTo(8));
            Assert.That(platform.Products.SequenceEqual(products.Take(8)), Is.True);
        }

        [Test]
        public void TestSellingFromEmpty()
        {

            Assert.That(platform.SellProduct(products[8]), Is.Null);
        }
        [Test]
        public void TestSellingNonExisting()
        {
            for (int i = 0; i < 8; i++)
            {
                platform.AddProduct(products[i]);
            }
            Assert.That(platform.SellProduct(products[8]), Is.Null);
        }

        [Test]
        public void TestSellingExisting()
        {
            for (int i = 0; i < 8; i++)
            {
                platform.AddProduct(products[i]);
            }
            Assert.That(platform.SellProduct(products[5]), Is.EqualTo(products[5]));
        }

        [Test]
        public void TestInventoryReport()
        {
            for (int i = 0; i < 8; i++)
            {
                platform.AddProduct(products[i]);
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Inventory Report:");
            sb.AppendLine($"Available Products: 8");

            foreach (var product in products.Take(8))
            {
                sb.AppendLine(product.ToString());
            }

            Assert.That(platform.InventoryReport(), Is.EqualTo( sb.ToString().TrimEnd()));
        }
    }
}