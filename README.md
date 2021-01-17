# C-Sharp-Primes
Prime generator written in C#

I've been comparing the efficient of C#, Java and Python when dealing with large arrays of integers.

This generator is able to calculate all primes up to 1 billion in about 19 seconds using the sieve of Eratothenes algorithm.

It is about 2-3% slower than java, and about 9 times faster than python.  (Both using the same algorithm.)

Usage:

  Primes 1000000000



The number after "Primes" is the limit to calculate to.

The executable is included in this repo.  (Always be careful running foreign executables!  Compiling from source is prefered!)
