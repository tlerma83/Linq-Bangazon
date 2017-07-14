using System;
using System.Collections.Generic;
using System.Linq;

namespace linq
{
    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Bank { get; set; }
    }

    public class Bank
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)

            // **************************************
            // ** Restriction/Filtering Operations **
            // **************************************
        {
            //task:  1 Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() {
                "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry"
            };

            var LFruits = from fruit in fruits
            where fruit.StartsWith("L")
            select fruit;

            foreach(var item in LFruits) {
                // Console.WriteLine($"Give me my fruitsList {item}");
            }

            // task2:  Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            var fourSixMultiples = numbers.Where(num => num % 6 == 0 | num % 4 == 0);

            foreach(int number in fourSixMultiples) {
                // Console.WriteLine($"Are there numbers?  {number}");
            }


            // *************************
            // ** Ordering Operations **
            // *************************

            // task 3: Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
            {
                "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                "Francisco", "Tre" 
            };

            // from n in names, where n = n , order n by n.descending
            //long hand
            // var descend = from n in names
            // orderby n descending
            // select n;

            // foreach(var thingy in descend) {
            //     Console.WriteLine($"ok {thingy}");
            // }

            // lamba short-hand
            var descend = names.OrderByDescending(n => n);

            foreach(string person in descend) {
                // Console.WriteLine($"Ehh? {person}");
            }
            
            // task 4: Build a collection of these numbers sorted in ascending order
            List<int> numbers2 = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };
            
            // long hand
            // var ascend = from count in numbers2
            // orderby count ascending
            // select count;

            // lambda short-hand, OrderBy ascends by Default
            var ascend = numbers2.OrderBy(num => num);

            foreach(int num in ascend) {
                // Console.WriteLine($"Asecnding numbers: {num}");
            }


            // **************************
            // ** Aggregate Operations **
            // **************************

            // task 5: Output how many numbers are in this list
            List<int> numbers3 = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            var numCount = numbers3.Count();
            // Console.WriteLine($"Number count {numCount}");



            // task 6: How much money have we made?
            List<double> purchases = new List<double>()
            {
                2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            };

            Console.WriteLine($"Money made: {purchases.Sum()}");


            // task 7: What is our most expensive product?
            List<double> prices = new List<double>()
            {
                879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
            };

            Console.WriteLine($"Max value {prices.Max()}");



            // *****************************
            // ** Partitioning Operations **
            // *****************************
            // task 8:  Store each number in the following List until a perfect square is detected.
            List<int> wheresSquaredo = new List<int>()
            {
                66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
            };
                
            var square =  wheresSquaredo.TakeWhile(num => (Math.Sqrt(num)% 1 != 0));


            // ************************
            // ** Using Custom Types **
            // ************************
            // task 9: Build a collection of customers who are millionaires
            List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
        };
            // long-hand
            // var millionares = from person in customers
            // where person.Balance >= 1000000
            // select person;

            // Lamda syntax short-hand
            var millionares = customers.Where(person => person.Balance >= 1000000);

            foreach (var item in millionares)
            {
                Console.WriteLine($"Millionares: {item.Name}");
            }

            /*  task 10: 
                Given the same customer set, display how many millionaires per bank.
                Ref: https://stackoverflow.com/questions/7325278/group-by-in-linq
                Example Output:
                WF 2
                BOA 1
                FTB 1
                CITI 1
            */

            var millionares2 = millionares.GroupBy(gropingGroup => gropingGroup.Bank);

            foreach (var groupingGrope in millionares2)
            {
                Console.WriteLine($"{groupingGrope.Key} has {groupingGrope.Count()} Customers ");
            }


            // task 11: As in the previous exercise, you're going to output the millionaires, but you will also display the full name of the bank. 
            // You also need to sort the millionaires' names, ascending by their LAST name.

            List<Bank> banks = new List<Bank>() {
                new Bank(){ Name="First Tennessee", Symbol="FTB"},
                new Bank(){ Name="Wells Fargo", Symbol="WF"},
                new Bank(){ Name="Bank of America", Symbol="BOA"},
                new Bank(){ Name="Citibank", Symbol="CITI"},
            };

             var millionaireReport = from p in millionares
             join bank in banks on p.Bank equals bank.Symbol
             select new{BankName = bank.Name, Customer = p.Name};


            foreach (var customer in millionaireReport)
            {
                Console.WriteLine($"{customer.BankName} at {customer.Customer}");
            }

        }
    }
}
