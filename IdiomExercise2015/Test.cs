using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdiomExercise2015
{
    public static class ClosureExtension
    {
        public static MilliSeconds TimeToRun(this Action closure)
        {
            var testTimer = new TestTimer();
            testTimer.StartTimer();
            closure();
            return testTimer.TotalRunTimeInMilliSeconds();
        }
    }

    [TestClass]
    public class Test
    {

        public void shouldTakeLessThan(Action should, MilliSeconds milliseconds)
        {
            Assert.IsTrue(should.TimeToRun().LessThan(milliseconds));
        }

        private CustomerBook customerBook;
        [TestInitialize]
        public void TestSetUp()
        {
            customerBook = new CustomerBook();
        }

        [TestMethod]
        public void AddingCustomerShouldNotTakeMoreThan50Milliseconds()
        {

            var expectedTime = new MilliSeconds(50);

            shouldTakeLessThan(() => customerBook.AddCustomerNamed("John Lennon"), expectedTime);
        }

        [TestMethod]
        public void RemovingCustomerShouldNotTakeMoreThan100Milliseconds()
        {

            String paulMcCartney = "Paul McCartney";

            customerBook.AddCustomerNamed(paulMcCartney);

            var expectedTime = new MilliSeconds(100);
            this.AssertIfActionTakesLessTimeThan(
                 () => customerBook.RemoveCustomerNamed(paulMcCartney), expectedTime);

        }

        [ExpectedException(typeof(Exception), CustomerBook.CUSTOMER_NAME_EMPTY)]
        [TestMethod]
        public void CanNotAddACustomerWithEmptyName()
        {

            customerBook.AddCustomerNamed("");
            Assert.IsTrue(customerBook.IsEmpty());

        }

        //[ExpectedException(typeof(InvalidOperationException), CustomerBook.INVALID_CUSTOMER_NAME)]
        [TestMethod]
        public void CanNotRemoveNotAddedCustomer()
        {

            AssertIfActionTrhowExpectedException(() => customerBook.RemoveCustomerNamed("John Lennon"),
                 typeof(InvalidOperationException), CustomerBook.INVALID_CUSTOMER_NAME, () => customerBook.NumberOfCustomers() == 0);


        }

        private void AssertIfActionTakesLessTimeThan(Action action, MilliSeconds expectedRunTime)
        {
            var testTimer = new TestTimer();
            testTimer.StartTimer();
            action.Invoke();
            var totalRunTime = testTimer.TotalRunTimeInMilliSeconds();
            Assert.IsTrue(totalRunTime.LessThan(expectedRunTime));
        }

        private void AssertIfActionTrhowExpectedException(Action action, Type typeExpected, string expectedMessage, Func<bool> checkFunction)
        {
            try
            {
                action.Invoke();
                Assert.Fail();
            }
            catch (Exception e)
            {
                var exceptionIsTheSame = e.Message.Equals(expectedMessage) && e.GetType() == typeExpected;
                Assert.IsTrue(exceptionIsTheSame);
                Assert.IsTrue(checkFunction.Invoke());
            }
        }
    }





    public class MilliSeconds
    {
        public double Value { get; private set; }

        public MilliSeconds(double value)
        {
            Value = value;
        }

        public bool LessThan(MilliSeconds otherValue)
        {
            return this.Value < otherValue.Value;
        }
    }
    public class TestTimer
    {
        private DateTime timeBeforeRunning;

        private DateTime timeAfterRunning = DateTime.Now;


        public TestTimer StartTimer()
        {
            timeBeforeRunning = DateTime.Now;
            return this;
        }

        public MilliSeconds TotalRunTimeInMilliSeconds()
        {
            timeAfterRunning = DateTime.Now;
            return new MilliSeconds(timeAfterRunning.Subtract(timeBeforeRunning).TotalMilliseconds);
        }
    }
}
