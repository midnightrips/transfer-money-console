using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransfer
{
    internal class Simulation
    {

        public Person brotherOne = new Person("Albert", 5000);
        public Person brotherTwo = new Person("Jacob", 1000);
        public Person sister = new Person("Amelia", 300);
        public Person mother = new Person("Larisa", 200000);
        public Person father = new Person("Gennady", 500000);
        public Person you = new Person("you", 500); //I added an extra...going to make this a userInput situation where they can add their own name
        public Simulation()
        {
            //Person brotherOne = new Person("Albert", 5000);
            //Person brotherTwo = new Person("Jacob", 1000);
            //Person sister = new Person("Amelia", 300);
            //Person mother = new Person("Larisa", 200000);
            //Person father = new Person("Gennady", 500000);
            //Person you = new Person("you", 500);
        }

        /* Bonus story:
         * Add 3 additional Person objects to the RunSimulation() method and expand the simulation to provide the user a menu.
         * The menu should allow the user to select any of the 5 people and have them transfer a balance the user selects to one of the other people.
         */
        public void RunSimulation()
        {
            Console.WriteLine("Starting simulation");

            Console.WriteLine("Choose a family member that will transfer away some of their money:");
            Console.WriteLine($"1: {brotherOne.name}");
            Console.WriteLine($"2: {brotherTwo.name}");
            Console.WriteLine($"3: {sister.name}");
            Console.WriteLine($"4: {mother.name}");
            Console.WriteLine($"5: {father.name}");
            //Console.WriteLine($"6: {you.name}");
            Person giver = brotherOne.ChooseGiver();
            giver.DisplayInfo();

            Console.WriteLine($"Now choose a family member that will receive money from {giver.name}:");
            Console.WriteLine($"1: {brotherOne.name}");
            Console.WriteLine($"2: {brotherTwo.name}");
            Console.WriteLine($"3: {sister.name}");
            Console.WriteLine($"4: {mother.name}");
            Console.WriteLine($"5: {father.name}");
            //Console.WriteLine($"6: {you.name}");
            Person receiver = brotherOne.ChooseReceiver();
            receiver.DisplayInfo();

            Console.WriteLine($"How many USD would you like {giver.name} to transfer to {receiver.name}?");
            Console.WriteLine("(Hint: input whole numbers only and without symbols or punctuation (e.g. 10000))");
            int amountToTransfer = brotherOne.ChooseAmount();


            giver.TransferMoney(receiver, amountToTransfer);

            //TODO 10: Call the .DisplayInfo() method on each person object again, showing that each person's balance has changed. Two lines.
            giver.DisplayInfo();
            receiver.DisplayInfo();

            Console.WriteLine("Simulation complete.");
        }
    }
}
