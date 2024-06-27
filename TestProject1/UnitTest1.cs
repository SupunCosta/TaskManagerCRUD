using TaskManager.Controllers;
using TaskManager.Interfaces;
using TaskManager.Models;
using TaskManager.Repository;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.That(actual, Is.EqualTo(expected).Within(0.001), "Account not debited correctly");
        }


       
    }
}