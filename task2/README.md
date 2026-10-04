# Memory Management in Lists and Tuples Using Python

## Experiment
After running this code:

```python
tpl = (1, 2, 3)
lst = [1, 2, 3]

print("Size of tuple: " + str(tpl.__sizeof__()))
print("Size of list: " + str(lst.__sizeof__()))
```

We get:

The output is:
```text
Size of tuple: 48
Size of list: 72
``` 
So question is - why are two different data structures with same amount of elements have a such  gap in matter of size?

## Introduction
Lists and tuples are data structures used to store sequences of elements,but they differ significantly in terms of memory management, mutability, and performance characteristics.


## Lists
Lists in Python are mutable sequences which means their elements can be modified after the list is created. Due to this mutability, lists in Python have some additional overhead.

## References
1. https://www.geeksforgeeks.org/python/memory-management-in-lists-and-tuples-using-python/
