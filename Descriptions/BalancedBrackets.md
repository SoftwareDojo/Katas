# Description

Given string of brackets, determine whether each sequence of brackets is balanced. If a string is balanced, return true; otherwise, return false.


A bracket is considered to be any one of the following characters: (, ), {, }, [, or ].

Two brackets are considered to be a matched pair if the an opening bracket (i.e., (, [, or {) occurs to the left of a closing bracket (i.e., ), ], or }) of the exact same type. There are three types of matched pairs of brackets: [], {}, and ().

A matching pair of brackets is not balanced if the set of brackets it encloses are not matched. For example, {[(])} is not balanced because the contents in between { and } are not balanced. The pair of square brackets encloses a single, unbalanced opening bracket, (, and the pair of parentheses encloses a single, unbalanced closing square bracket, ].

By this logic, we say a sequence of brackets is considered to be balanced if the following conditions are met:

•It contains no unmatched brackets.


•The subset of brackets enclosed within the confines of a matched pair of brackets is also a matched pair of brackets.


Given strings of brackets, determine whether each sequence of brackets is balanced. If a string is balanced, return true; otherwise, return false.


# Sample
```
Input: 1 Output: 1
Input: 2 Output: 2
Input: 3 Output: fizz
Input: 4 Output: 4
Input: 5 Output: buzz
Input: 6 Output: fizz
...
Input: 10 Output: buzz
...
Input: 15 Output: fizzbuzz
...
```