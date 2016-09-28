using System;
using System.Collections.Generic;

namespace IdiomExercise2015
{
    public class CustomerBook
    {
        public const String CUSTOMER_NAME_EMPTY = "Customer name can not be empty";
        public const String CUSTOMER_ALREADY_EXISTS = "Customer already exists";
        public const string INVALID_CUSTOMER_NAME = "Invalid Customer name";

        private IList<String> customerNames = new List<String>();

        public void AddCustomerNamed(String name)
        {
            if (name.Length == 0) throw new Exception(CUSTOMER_NAME_EMPTY);
            if (ContainsCustomerNamed(name)) throw new Exception(CUSTOMER_ALREADY_EXISTS);

            customerNames.Add(name);
        }

        public bool IsEmpty()
        {
            return this.NumberOfCustomers() == 0;
        }

        public int NumberOfCustomers()
        {
            return customerNames.Count;
        }


        public bool ContainsCustomerNamed(String name)
        {
            return customerNames.Contains(name);
        }

        public void RemoveCustomerNamed(String name)
        {
            if (!customerNames.Remove(name))
                throw new InvalidOperationException(INVALID_CUSTOMER_NAME);
        }


    }

}
