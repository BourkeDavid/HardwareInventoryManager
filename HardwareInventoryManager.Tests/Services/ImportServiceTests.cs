﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HardwareInventoryManager.Controllers;
using HardwareInventoryManager.Models;
using HardwareInventoryManager.Services.Import;
using Moq;
using HardwareInventoryManager.Repository;
using System.Linq.Expressions;


namespace HardwareInventoryManager.Tests.Services
{
    [TestClass]
    public class ImportServiceTests
    {
        [TestMethod]
        public void Upload_CSVWithData_Processed()
        {
            // ARRANGE
            var service = new ImportService("david");

            string csvString = 
@"Model,Serial Number,Purchase Date,Warranty Period,Obsolescense Date,Price Paid,Category,Location Description
12345,LLLLLLLL1,10/03/2015,3 years,10/03/2018,100,Desktop,Room 101
456798,MMMMM1,10/03/2014,1 years,10/03/2017,200,Laptop,Room 102
";

            // ACT
            string[] lines = service.ProcessCsvLines(csvString);

            // ASSERT
            Assert.AreEqual(3, lines.Length);

        }

        [TestMethod]
        public void ProcessCsvHeader_CSVHeaderSupplied_Processed()
        {
            // ARRANGE
            var service = new ImportService("david");
            string header = "Model,Serial Number,Purchase Date,Warranty Period,Obsolescense Date,Price Paid,Category,Location Description";
            
            // ACT
            string[] headerArray = service.ProcessCsvHeader(header);

            // ASSERT
            Assert.AreEqual(8, headerArray.Length);
            Assert.AreEqual("Model", headerArray[0]);
            Assert.AreEqual("SerialNumber", headerArray[1]);
        }


        [TestMethod]
        public void ProcessLineToAsset_HeaderAndLineSupplied_Processes()
        {
            // ARRANGE
            Mock<IRepository<Lookup>> m = new Mock<IRepository<Lookup>>();
            m.Setup(x => x.Single(It.IsAny<Expression<Func<Lookup, bool>>>())).Returns(
                new Lookup
                {
                    Description = "3 Years",
                    Type = new LookupType
                    {
                        Description = "WarrantyPeriod"
                    }
                }
            );
            
            var service = new ImportService("david");
            string[] header = {
                                  "Model",
                                  "SerialNumber",
                                  "PurchaseDate",
                                  "WarrantyPeriod",
                                  "ObsolescenseDate",
                                  "PricePaid",
                                  "Category",
                                  "LocationDescription"
                              };
            string line = "12345,LLLLLLLL1,10/03/2015,3 years,10/03/2018,100,Desktop,Room 101";
            service.LookupRepository = m.Object;

            // ACT
            Asset asset = service.ProcessLineToAsset(header, line);

            // ASSERT
            Assert.IsNotNull(asset);
            Assert.AreEqual("12345", asset.Model);
            Assert.AreEqual("LLLLLLLL1", asset.SerialNumber);
            Assert.AreEqual("10/03/2015", asset.PurchaseDate.Value.ToString("dd/MM/yyyy"));
            Assert.AreEqual("3 Years", asset.WarrantyPeriod.Description);

        }
    }
}
