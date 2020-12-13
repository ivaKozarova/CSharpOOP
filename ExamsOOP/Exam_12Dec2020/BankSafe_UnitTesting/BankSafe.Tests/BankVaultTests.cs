using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private Item item;
        private BankVault bankVault;

        [SetUp]
        public void Setup()
        {
            this.item = new Item("Sasho", "A12");
            this.bankVault = new BankVault();
        }

        [Test]
        public void ItemConstructorShouldWorkCorrectly()
        {
            var expectedOwener = "Sasho";
            var expectedIdItem = "A12";

            Assert.AreEqual(expectedOwener, this.item.Owner);
            Assert.AreEqual(expectedIdItem, this.item.ItemId);
        }
        [Test]
        public void BankVaultConstructorShouldWorkCorrectly()
        {
            Assert.AreEqual(12, this.bankVault.VaultCells.Count);
        }

        [Test]
        public void DoesAddThrowExceptionIfTryToAddItemToInvalidCell()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.bankVault.AddItem("Z12", this.item);
            });
        }
        [Test]
        public void DoesAddItemThrowExceptionIfTryToAddItemToNotEmptyCell()
        {
            this.bankVault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() =>
            {
                Item item2 = new Item("Niki", "A234");
                this.bankVault.AddItem("A1", item2);
            });

        }
        [Test]
        public void AddItemShouldWorkCorrectly()
        {
            this.bankVault.AddItem("A2", item);

            var expectedName = "Sasho";
            var expectedId = "A12";

            var item2 = this.bankVault.VaultCells["A2"];

            Assert.AreEqual(expectedName, item2.Owner);
            Assert.AreEqual(expectedId, item2.ItemId);
        }
        [Test]
        public void RemoveShouldThrowsExceptionIfCellDoesntExist()
        {
            this.bankVault.AddItem("A1",item);
            Assert.Throws<ArgumentException>(() =>
            {
                this.bankVault.RemoveItem("A2", item);
            });
        }
        [Test]
        public void RemoveShouldThrowExceptionIfItemOnCellIsNotSame()

        {
            this.bankVault.AddItem("A1", item);
            Item item2 = new Item("Niki", "A234");
            this.bankVault.AddItem("A2", item2);

            Assert.Throws<ArgumentException>(() =>
            {
                this.bankVault.RemoveItem("A1", item2);
            });
        }
        [Test]
        public void RemoveShouldWorkCorrectly()
        {
            this.bankVault.AddItem("A1", item);

            this.bankVault.RemoveItem("A1", item);

            Item expected = null;

            Assert.AreEqual(expected, this.bankVault.VaultCells["A1"]);
        }  


    }
}