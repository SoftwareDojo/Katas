# Description

The game of Yatzy is a simple dice game. Each player rolls five six-sided dice. They can re-roll some or all of the dice up to three times (including the original roll). Your task is to score a given roll in a given category. You do not have to program the random dice rolling or the game.

* Ones, Twos, Threes, Fours, Fives, Sixes: sum of the dice that reads one, two, three, four, five or six.
* Pair: sum of the two highest matching dice.
* Two pairs: sum of these two pairs.
* Three of a kind: sum of three dice with the same number.
* Four of a kind: sum of four dice with the same number.
* Small straight: 1,2,3,4,5 scores 15.
* Large straight: 2,3,4,5,6 scores 20.
* Full house: sum of two of a kind and three of a kind.
* Yatzy: all dice have the same number, scores 50.
* Chance: sum of all dice.

# Sample
```
Input: 1, 2, 1, 1, 1 Output Ones: 4
Input: 5, 3, 6, 6, 5 Output Pair: 12
Input: 5, 3, 5, 4, 5 Output Three: 15
Input: 6, 2, 2, 2, 6 Output Full house: 18
Input: 4, 4, 4, 4, 4 Output Yatzy: 50
Input: 3, 3, 4, 5, 1 Output Chance: 16
```