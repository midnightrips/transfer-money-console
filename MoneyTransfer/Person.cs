using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransfer
{
    internal class Person
    {
        public string name;
        public Wallet wallet; //changed it from private to public...
        public int amountToTransfer;
        public Person giver;
        public Person receiver;


        public Person(string name, int cash)
        {
            //TODO 2: Assign the value of the 'name' parameter to the 'name' member variable. One line.

            this.name = name;

            //TODO 3: Instantiate a new 'Wallet' object, passing the 'cash' parameter into its constructor. Assign this new Wallet to the 'wallet' member variable. One line.
            wallet = new Wallet(cash); //wallet never saves the money in the wallet

        }

        public void DisplayInfo()
        {
            //TODO 4: Use string interpolation in a ConsoleWriteLine to display the user's name and also the amount of money in their wallet (using dot notation). One line.
            Console.WriteLine($"{name} has ${wallet.money}");
        }

        public void AcceptMoney(int amount)
        {
            //TODO 7: Use an assignment operator to increase the amount of money in the person's wallet by the value of the 'amount' parameter. One line.
            wallet.money = wallet.money + amount;
        }

        public bool TransferMoney(Person receiver, int amountToTransfer)
        {
            /*TODO 8: Use a conditional to check if the 'amountToTransfer' parameter of this method is less than or equal 
             * to the amount of money in the wallet of the giver. 
             * If the parameter is less than the amount in the wallet, subtract that amount from the wallet, then 
             * call the receiver's AcceptMoney() method and pass 'amountToTransfer' into it. 
             * Also use a Console.WriteLine to describe the transaction that occurred.
             * If the parameter is greater than the amount in the giver's wallet, do not transfer any money and 
             * instead print a message describing why the transfer failed.
             */


            if (amountToTransfer <= wallet.money) // <= giver money -> how do I specify this is relative to brotherOne's wallet?
            {
                wallet.money = wallet.money - amountToTransfer; //giver's wallet is subtracted from
                receiver.AcceptMoney(amountToTransfer);
                Console.WriteLine($"{name} is sending {receiver.name} ${amountToTransfer}.");
                return true;
            }
            else
            {
                Console.WriteLine($"Transfer Declined: {name} has insufficient funds.");
                return false;
            }

        }

        public Person ChooseGiver()
        {
            Simulation giveMoney = new Simulation();
            string giverChoiceInitial = Console.ReadLine();
            string giverChoice = giverChoiceInitial.ToLower();

            if (giverChoice == "1" || giverChoice == "albert")
            {
                giver = giveMoney.brotherOne;
            }
            else if (giverChoice == "2" || giverChoice == "jacob")
            {
                giver = giveMoney.brotherTwo;
            }
            else if (giverChoice == "3" || giverChoice == "amelia")
            {
                giver = giveMoney.sister;
            }
            else if (giverChoice == "4" || giverChoice == "larisa")
            {
                giver = giveMoney.mother;
            }
            else if (giverChoice == "5" || giverChoice == "gennady")
            {
                giver = giveMoney.father;
            }
            //else if (giverChoice == "6" || giverChoice == "you" || giverChoice == "me")
            //{
            //    giver = giveMoney.you;
            //}
            else
            {
                Console.WriteLine($"{giverChoiceInitial} is not an option. Please try again.");
            }
            
            return giver;

        }

        public Person ChooseReceiver()
        {
            Simulation getMoney = new Simulation();
            string receiverChoiceInitial = Console.ReadLine();
            string receiverChoice = receiverChoiceInitial.ToLower();

            if (receiverChoice == "1" || receiverChoice == "albert") //code for if they choose themselves
            {
                receiver = getMoney.brotherOne;
            }
            else if (receiverChoice == "2" || receiverChoice == "jacob")
            {
                receiver = getMoney.brotherTwo;
            }
            else if (receiverChoice == "3" || receiverChoice == "amelia")
            {
                receiver = getMoney.sister;
            }
            else if (receiverChoice == "4" || receiverChoice == "larisa")
            {
                receiver = getMoney.mother;
            }
            else if (receiverChoice == "5" || receiverChoice == "gennady")
            {
                receiver = getMoney.father;
            }
            //else if (receiverChoice == "6" || receiverChoice == "you" || receiverChoice == "me")
            //{
            //    receiver = getMoney.you;
            //}
            else
            {
                Console.WriteLine($"{receiverChoiceInitial} is not an option. Please try again.");
            }

            return receiver;

        }

        public int ChooseAmount()
        {
            int amountToTransfer = 0;
            bool goodChoice = false;

            while (goodChoice == false)
            {
                string transferChoice = Console.ReadLine();
                amountToTransfer = int.Parse(transferChoice);
                goodChoice = true;
                //add a conditional that accounts for inputs that aren't just whole numbers
            }

            return amountToTransfer;
        }
    }
}
