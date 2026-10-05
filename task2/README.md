# Memory Management in Lists and Tuples Using Python

## Experiment
After running this code:

```python
tpl = (1, 2, 3)
lst = [1, 2, 3]

print("Size of tuple: " + str(tpl.__sizeof__()))
print("Size of list: " + str(lst.__sizeof__()))
```

We get output:

```text
Size of tuple: 48
Size of list: 72
``` 
So question is - why are two different data structures with same amount of elements have a such  gap in matter of size?

## Introduction
Lists and tuples are data structures used to store sequences of elements,but they differ significantly in terms of memory management, mutability, and performance characteristics.


## Lists
Lists in Python are mutable sequences which means their elements can be modified after the list is created.Elements can be added or removed without creating a new list every time. Due to this mutability, lists in Python have some additional memory.
- **Memory Overhead:** A Python list does not store its elements directly. Instead, it stores references to Python objects. In addition, the list needs extra information to manage its size and allocated memory. Because of this, lists generally require more memory than simpler fixed-size structures.
- **Over-allocation:** Python usually reserves more space than the list currently needs. For example, if the list contains 3 elements, it may have enough allocated memory for additional elements. This allows new elements to be appended without reallocating memory every time. As a result, Python uses some extra memory in exchange for better performance when the list gets bigger.

## Tuples
Tuples are immutable, which means their contents cannot be changed once they are created. This immutability provides certain optimizations in terms of memory management.
- **Less Extra Memory:** Since tuples cannot grow, they usually need less additional memory than lists.
- **Memory Efficiency:** Tuples are a good choice when the data does not need to be changed. They use less memory, especially when many tuples are used.

## Conclusion
In this case, the tuple used 48 bytes, while the list used 72 bytes. This difference reflects a main priority between flexibility and memory efficiency. Lists are more suitable when the data needs to change, while tuples are a better choice when the data should remain fixed. Therefore, the choice between them should depend on the requirements of the program rather than only on memory usage.

## References
1. https://www.geeksforgeeks.org/python/memory-management-in-lists-and-tuples-using-python/
2. https://hackernoon.com/understanding-python-memory-efficiency-tuples-vs-lists