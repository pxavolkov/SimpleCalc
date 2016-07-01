using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CalcService.BL;
using CalcService.Models;
using NUnit.Framework;

namespace CalcService.Tests
{
    [TestFixture]
    public class ManagerTests
    {
        public IManager Manager;

        [SetUp]
        public void Setup()
        {
            Manager = new Manager();
        }

        [Test]
        public void CalculateNullDto()
        {
            Assert.Throws<ArgumentException>(() => Manager.Calculate(null));
        }

        [Test]
        public void CalculateAdd()
        {
            var result = Manager.Calculate(new CalculateDto {OperandA = 3, OperandB = 5, Operation = new Addition().OperationId});
            Assert.AreEqual(8, result);
        }
    }
}