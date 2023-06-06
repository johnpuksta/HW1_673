# Pollard's Rho Algorithm For Discrete Logarithms
 This algorithm is finding the value of B for a^B = mod P, where only a and P are given. <br /> <br />
 Three subgroups are used to iterate two chains, the tortoise and the hare, which Brent's cycle detection algorithm detects a collision between the two chains.<br /> <br />
 This repo accurately solves 40 and 60 bit DLPs, but experiences trouble with anything larger.<br /> <br />
