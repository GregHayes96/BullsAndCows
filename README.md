# BullsAndCows
Bulls and cows number game using C#


Version 3.0

Whats new:
*added randomisation to the game. I need to work out some of the bugs so that the guess is stored in an array so the numbers can be compared.
*When the game does reset, you get a full reset of the numbers stored with no repeat numbers. passes the check each time


Bulls and cows is a game where the player guesses 4 digits.
If the digit is in the correct spot, its a bull
If the digit is in the wrong spot but its a correct number, its a cow
No repeat numbers

Example:
Guess - 1234  Answer - 1593
1 bulls, 1 cows

Guess - 1234  Answer - 4153
0 bulls, 2 cows


Structure:

The program will be run as a user defined object, with a player inputing the guess by using the method of the class. 
