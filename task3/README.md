# Task 3 - Matrix Multiplication

## Introduction
The purpose of this task is to implement matrix multiplication using two different approaches: Python with NumPy and a C-like programming language. I choised C++ as the C-like language.
Matrix multiplication is only possible when the number of columns in the first matrix is equal to the number of rows in the second matrix.
For example, if matrix A has size `n × m` and matrix B has size `m × k`, the resulting matrix will have size `n × k`.
The programs were implemented without hard-coded matrix sizes. The dimensions and matrix values can be provided by the user.

---

## Python Implementation

The Python implementation uses the NumPy library.
The user enters rows, columns and values of both matrices. The input values are stored in NumPy arrays. Before multiplication, the program checks whether the number of columns in matrix A is equal to the number of rows in matrix B.
Matrix multiplication is performed using NumPy's matrix multiplication functionality.

---

## C++ Implementation

The C++ implementation uses `vector<vector<double>>` to represent matrices.
The dimensions of both matrices are entered by the user. That means the program can work with matrices of different sizes instead of using a fixed matrix size.
Matrix multiplication is implemented using three loops.
For every element of the result matrix, the program multiplies the corresponding elements from a row of matrix A and a column of matrix B and adds them together.
```cpp
for (int i = 0; i < n; i++) {
    for (int j = 0; j < k; j++) {
        for (int x = 0; x < m; x++) {
            result[i][j] += matrixA[i][x] * matrixB[x][j];
        }
    }
} 
```
Unlike the NumPy implementation, the C++ version requires the matrix multiplication algorithm to be implemented manually.


## ChatGPT Implementation
After completing my own implementation, I asked ChatGPT to implement the same matrix multiplication task in C++.
The prompt explained that the program should perform matrix multiplication, include unit tests, and measure execution time for matrices of different sizes.
ChatGPT used vector<vector<double>> to store the matrices and implemented matrix multiplication in a separate function.
---
## Execution Time
The C++ implementation was tested using square matrices of three different sizes. I had some problems implementing the unit tests directly in my code file, so I used an online compiler to run the unit tests and measure the execution time.

My Implementation:
| Matrix Size | Execution Time |
|-------------|---------------:|
| 100 x 100   | 14.645 ms      |
| 200 x 200   | 120.647 ms     |
| 400 x 400   | 1101.332 ms    |

When the matrix size increased from 100 × 100 to 200 × 200, the execution time increased from 14.645 ms to 120.647 ms, which is approximately 8.2 times longer.
When the matrix size increased from 200 × 200 to 400 × 400, the execution time increased by approximately 9.1 times.
This behavior is expected because the standard matrix multiplication algorithm uses three nested loops and has approximately O(n³) time complexity for square matrices.

ChatGPT Implementation:
| Matrix Size | Execution Time |
|-------------|---------------:|
| 100 x 100   | 19.001 ms      |
| 200 x 200   | 147.672 ms     |
| 400 x 400   | 1202.296 ms    |

## Comparison
In these tests, my implementation was faster for all three matrix sizes. However, execution time can vary between runs because it depends on the computer, compiler settings, and other processes running on the system. Therefore, these results should not be interpreted as an absolute performance difference.
The AI implementation contains more validation and error handling, which makes the code more longer. My implementation is simpler and focuses mainly on matrix multiplication, user input.

## Conclusion
This task demonstrated the difference between implementing matrix operations using a high-level numerical library (numpy) and implementing the algorithm manually in C++.
NumPy provides a simple way to perform matrix multiplication. The C++ implementation requires more code, but it makes the matrix multiplication process more openly and gives more control over the implementation.
The ChatGPT implementation had more checking than my original implementation. It checked additional error cases such as empty matrices. However, this also increased the size of the code. My implementation was shorter and produced lower execution times in the performed tests.
## References
1. https://www.geeksforgeeks.org/python/matrix-multiplication-in-numpy/
2. https://www.geeksforgeeks.org/python/take-matrix-input-from-user-in-python/
3. https://www.w3schools.com/c/c_arrays_multi.php
4. https://www.w3schools.com/cpp/cpp_vectors.asp
