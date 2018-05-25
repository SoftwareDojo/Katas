# Description

Write a function that takes a string and can determine whether you can spell the word with the given collection of blocks.

* once a letter on a block is used that block cannot be used again
* the function should be case-insensitive
* blocks => (B O) (X K) (D Q) (C P) (N A) (G T) (R E) (T G) (Q D) (F S) (J W) (H U) (V I) (A N) (O B) (E R) (F S) (L Y) (P C) (Z M))

# Sample
```
Input: "A" Output: true
Input: "treat" Output: true
Input: "book" Output: false
Input: "COMMON" Output: false
```

# Extentions

* Support different collections of blocks.