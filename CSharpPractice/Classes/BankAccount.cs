using CSharpPractice.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace CSharpPractice.Classes
{
    public class BankAccount : IInformation
    {
        //Properties
        private double _balance;

        public double Balance
        {
            get 
            {
                if (_balance < 1000000)
                    return _balance;
                return 1000000;
            }

            //Protected allows this setter to be accessed from the current class
            //or any class that is inherited from the base class.
            //This is protected because we don't want anybody outside this class to 'SET'
            //a balance.
            protected set 
            { 
                if (value > 0)
                    _balance = value;
                else
                    _balance = 0;
            }
        }

        //Constructor
        public BankAccount()
        {
            Balance = 100;
        }

        public BankAccount(double initialBalance)
        {
            Balance = initialBalance;
        }

        //Methods.
        //NOTE: to allow this method to be overrideable, mark as 'virtual'.
        //  Then in the class that is inheriting this method, mark as 'override'
        public virtual double  AddToBalance(double balanceToBeAdded)
        {
            Balance += balanceToBeAdded;

            return balanceToBeAdded;
        }

        public string GetInformation()
        {
            return $"Your current balance is: {Balance:c}";
        }
    }

    //Inheritance
    public class ChildBankAccount : BankAccount
    {
        //Constructor
        public ChildBankAccount()
        {
            Balance = 10;
        }

        //NOTE: Base method needs to be marked virtual before marking this override.
        //Overiding is when you want to use something similar to the base method, but add additional functionality.
        public override double AddToBalance(double balanceToBeAdded)
        {
            if (balanceToBeAdded > 1000)
                balanceToBeAdded = 1000;    //cap at $1000
            if (balanceToBeAdded < -1000)
                balanceToBeAdded = -1000;   //cap at $1000 withdraw

            return base.AddToBalance(balanceToBeAdded);
        }
    }
}
