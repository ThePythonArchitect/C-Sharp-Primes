using System;

namespace Prime_Generator
{
    class Primes
    {
        static void Main(string[] args)
        {
            /*
            //verify that a single arguement was given
            //and that it was an integer
            if (args.Length != 1)
            {
                Console.WriteLine("Takes only 1 arguement.");
                System.Environment.Exit(1);
            }
            bool is_int = int.TryParse(args[0], out int limit);
            if (!is_int)
            {
                Console.WriteLine("Takes an integer as an arguement.");
                System.Environment.Exit(1);
            }
            //verify that limit is above 2
            if (limit <= 2)
            {
                Console.WriteLine("Requires an integer above 2.");
                System.Environment.Exit(1);
            }
            //now limit is a valid integer
            */
            int limit = 1000000000;

            Console.WriteLine($"Sieving started.");

            //begin the timer
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //create a sieve
            bool[] sieve = new bool[limit];

            //mark 0 and 1 as composite
            sieve[0] = true;
            sieve[1] = true;

            //mark all multiples of 2 as composite
            //false = prime, true = composite
            for (int x = 4; x < limit; x += 2)
            {
                sieve[x] = true;
            }

            //need a way to keep track of how many primes have
            //been found thus far, 2 is already baked in
            long prime_count = 1;

            bool root_reached = false; 

            //now the main sieving algorithm
            for (long potential = 3; potential < limit; potential += 2)
            {
                if (sieve[potential]) { continue; }
                else
                {
                    //increment prime count
                    prime_count += 1;
                }
                if (root_reached) { continue; }
                //mark all multiples of the prime
                long square = potential * potential;
                if (square > limit) { root_reached = true; }
                for (long multiple = square; multiple < limit; multiple += potential)
                {
                    sieve[multiple] = true;
                }
                
            }

            //collect all the primes from the sieve
            //
            //index starts at 1 since 2 is already baked in
            int index = 1;
            int[] primes = new int[prime_count];
            primes[0] = 2;
            for (int x = 3; x < limit; x += 2)
            {
                if (sieve[x] == false)
                {
                    //x is a prime in the sieve
                    try
                    {
                        primes[index] = x;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"{e.Message}\nindex={index}, x={x}");
                    }
                    
                    //increment index
                    index += 1;
                }
            }

            //end the timer
            watch.Stop();
            var end_time = watch.ElapsedMilliseconds;

            //display results to the console
            Console.WriteLine($"Sieving completed in {end_time} ms.");
            Console.WriteLine($"Display last 10 primes: {string.Join(",", primes[^10..^0])}");
            Console.WriteLine($"");
        }
    }
}
