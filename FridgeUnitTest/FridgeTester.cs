﻿using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fridge;


namespace FridgeUnitTest
{
    [TestClass]
    public class FridgeTester
    {
//Kjell testar på nytt
        //maria testar II
        private string inventoryItemMeatballs = "Meatballs";


        [TestMethod]
        public void ToEmptyFridgeAddOneInventoryItem()
        {
            FridgeWorker currentFridge = new FridgeWorker();
           
            currentFridge.AddIngredientToFridge(inventoryItemMeatballs, 10);

        }
        
        [TestMethod]
        public void ToEmptyFridgeAddTwoIdenticalInventoryItem()
        {
            FridgeWorker currentFridge = new FridgeWorker();

            currentFridge.AddIngredientToFridge(inventoryItemMeatballs, 10);
            currentFridge.AddIngredientToFridge(inventoryItemMeatballs, 10);

            Assert.AreEqual( 1, currentFridge.InventoryList.Count);
            Assert.AreEqual(20, currentFridge.InventoryList[0].Quantity);
        }

        [TestMethod]
        public void DoesInventoryItemExist()
        {
            FridgeWorker currentFridge = new FridgeWorker();

            currentFridge.AddIngredientToFridge(inventoryItemMeatballs, 10);

            FridgeInventory result = currentFridge.GetInventoryItem(inventoryItemMeatballs);
            Assert.AreEqual(10, result.Quantity);
        }

        [TestMethod]
        public void FromEmptyFridgeIsItemAvailable()
        {
            FridgeWorker currentFridge = new FridgeWorker();
            Assert.AreEqual(false, currentFridge.IsItemAvailable(inventoryItemMeatballs, 7));
        }

        [TestMethod]
        public void FromFullFridgeIsItemAvailable()
        {
            FridgeWorker currentFridge = new FridgeWorker();

            currentFridge.AddIngredientToFridge(inventoryItemMeatballs, 10);

            Assert.AreEqual(true, currentFridge.IsItemAvailable(inventoryItemMeatballs, 7));
        }

        [TestMethod]
        public void FromFullFridgeRemoveExistingInventoryItem()
        {
            string invItem1 = "Meatballs";
            string invItem2 = "Potato";
            string invItem3 = "Pasta";
            string invItem4 = "Sauce";
            FridgeWorker currentFridge = new FridgeWorker();

            currentFridge.AddIngredientToFridge(invItem1, 10);
            currentFridge.AddIngredientToFridge(invItem2, 50);
            currentFridge.AddIngredientToFridge(invItem3, 4);
            currentFridge.AddIngredientToFridge(invItem4, 10);

            Double result = currentFridge.TakeItemFromFridge(invItem1, 7);
            Assert.AreEqual(3, result);

            result = currentFridge.TakeItemFromFridge(invItem1, 7);
            Assert.AreEqual(-4, result);
        }

        [TestMethod]
        public void FromFullFridgeRemoveNonExistingInventoryItem()
        {
            string invItem1 = "Meatballs";
            string invItem2 = "Potato";
            string invItem3 = "Pasta";
            string invRemoveItem = "Sauce";
            FridgeWorker currentFridge = new FridgeWorker();

            currentFridge.AddIngredientToFridge(invItem1, 10);
            currentFridge.AddIngredientToFridge(invItem2, 50);
            currentFridge.AddIngredientToFridge(invItem3, 4);

            Double result = currentFridge.TakeItemFromFridge(invRemoveItem, 5);

            Assert.AreEqual(-5, result);
        }

        [TestMethod]
        public void FromEmptyFridgeRemoveInventoryItem()
        {
            FridgeWorker currentFridge = new FridgeWorker();
            Double result = currentFridge.TakeItemFromFridge(inventoryItemMeatballs, 5);
            Assert.AreEqual(-5, result);
        }
 
    }
}
