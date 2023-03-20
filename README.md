# ECE673 HW1 - Pollard's Rho Algorithm For Discrete Logarithms
 This algorithm is finding the value of B for a^B = mod P, where only a and P are given.
 Three subgroups are used to iterate two chains, the tortoise and the hare, which Brent's cycle detection algorithm detects a colissions between the two chains.
 This repo accurately solves 40 and 60 bit DLPs, but experiences trouble with anything larger.
