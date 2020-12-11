using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Store.Tests
{
    [TestFixture]
    public class StoreManagerTests
    {
        private Product product;
        StoreManager store;

        [SetUp]
        public void Setup()
        {
            this.product = new Product("Milk", 5, 1.8m);
            this.store = new StoreManager();
        }

        [Test]
        public void DoesProductConstructorWorkCorrect()
        {
            var expectedName = "Milk";
            var expectedQuantity = 5;
            var expectedPrice = 1.8m;

            Assert.AreEqual(expectedName, this.product.Name);
            Assert.AreEqual(expectedQuantity, this.product.Quantity);
            Assert.AreEqual(expectedPrice, this.product.Price);
        }

        [Test]
        public void StoreConstructorShouldWorkCorrectly()
        {
            CollectionAssert.IsEmpty(this.store.Products);
            Assert.AreEqual(0 ,this.store.Count);
        }
        [Test]
        public void DoesAddThrowExceptionIfProductisNull()
        {
           
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.store.AddProduct(null);
            });
        }
        [Test]
        public void DoesConstructorThroExceptionIfQuantityIsBelowOrEqualToZero()
        {
            Product productMilk = new Product("Milk", 0, 1.5m);

            Assert.Throws<ArgumentException>(() =>
            {
                this.store.AddProduct(productMilk);
            });
        }
        [Test]
        public void DoesAddProductsIncreaseCountOfProducts()
        {
            this.store.AddProduct(product);

            Assert.AreEqual(1, this.store.Count);
        }
        [Test]
        public void DoesBuyProductThrowExceptionIfProductNameDoesNotExist()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.store.BuyProduct("Shoes", 5);
            });
        }
        [Test]
        public void DoesBuyProductThrowExceptionIfProductQuantityIsNotEnough()
        {
            Product productMeat = new Product("Meat", 5, 2.2m);
            this.store.AddProduct(productMeat);
            this.store.AddProduct(product);

            Assert.Throws<ArgumentException>(() =>
            {
                this.store.BuyProduct("Meat", 10);
            });
        }
        [Test]
        public void DoesBuyProductsWorkCorrect()
        {
            var expectedPrice = 3 * 1.8m;
            var expectedQuantity = 2;
            this.store.AddProduct(product);

            var actualPrice = this.store.BuyProduct("Milk", 3);

            Assert.AreEqual(expectedPrice, actualPrice);
            Assert.AreEqual(expectedQuantity, this.product.Quantity);
        }

        [Test]
        public void DoesGetMostExpensiveProductReturnCorrectProduct()
        {
            this.store.AddProduct(product);
            Product product2 = new Product("Tea", 10, 1.2m);
            Product product3 = new Product("Water", 7, 0.8m);
            this.store.AddProduct(product2);
            this.store.AddProduct(product3);

            var expectedProduct = product;

            var actualProduct = this.store.GetTheMostExpensiveProduct();

            Assert.AreEqual(expectedProduct.Price, actualProduct.Price);
            
        }

    }
}