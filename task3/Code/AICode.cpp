#include <iostream>
#include <vector>
#include <stdexcept>
#include <cassert>
#include <chrono>
#include <random>
#include <iomanip>
#include <cmath>

using Matrix = std::vector<std::vector<double>>;


// ----------------------------------------------------
// Matrix multiplication
// ----------------------------------------------------
Matrix multiply(const Matrix& A, const Matrix& B)
{
    if (A.empty() || B.empty() ||
        A[0].empty() || B[0].empty())
    {
        throw std::invalid_argument("Matrices must not be empty");
    }

    std::size_t n = A.size();       // rows of A
    std::size_t m = A[0].size();    // columns of A

    std::size_t q = B.size();       // rows of B
    std::size_t p = B[0].size();    // columns of B


    // Check that A is rectangular
    for (const auto& row : A)
    {
        if (row.size() != m)
            throw std::invalid_argument("Matrix A is not rectangular");
    }


    // Check that B is rectangular
    for (const auto& row : B)
    {
        if (row.size() != p)
            throw std::invalid_argument("Matrix B is not rectangular");
    }


    // Matrix multiplication is possible only if
    // columns(A) == rows(B)
    if (m != q)
    {
        throw std::invalid_argument(
            "Number of columns in A must equal number of rows in B"
        );
    }


    Matrix C(n, std::vector<double>(p, 0.0));


    for (std::size_t i = 0; i < n; i++)
    {
        for (std::size_t k = 0; k < m; k++)
        {
            for (std::size_t j = 0; j < p; j++)
            {
                C[i][j] += A[i][k] * B[k][j];
            }
        }
    }

    return C;
}


// ----------------------------------------------------
// Compare matrices
// ----------------------------------------------------
bool equalMatrices(
    const Matrix& A,
    const Matrix& B,
    double epsilon = 1e-9)
{
    if (A.size() != B.size())
        return false;

    for (std::size_t i = 0; i < A.size(); i++)
    {
        if (A[i].size() != B[i].size())
            return false;

        for (std::size_t j = 0; j < A[i].size(); j++)
        {
            if (std::abs(A[i][j] - B[i][j]) > epsilon)
                return false;
        }
    }

    return true;
}


// ----------------------------------------------------
// Unit tests
// ----------------------------------------------------
void runUnitTests()
{
    // Test 1: 2x2 matrices
    {
        Matrix A{
            {1, 2},
            {3, 4}
        };

        Matrix B{
            {5, 6},
            {7, 8}
        };

        Matrix expected{
            {19, 22},
            {43, 50}
        };

        assert(equalMatrices(multiply(A, B), expected));
    }


    // Test 2: Rectangular matrices
    {
        Matrix A{
            {1, 2, 3},
            {4, 5, 6}
        };

        Matrix B{
            {7, 8},
            {9, 10},
            {11, 12}
        };

        Matrix expected{
            {58, 64},
            {139, 154}
        };

        assert(equalMatrices(multiply(A, B), expected));
    }


    // Test 3: Identity matrix
    {
        Matrix A{
            {3, -2},
            {5, 4}
        };

        Matrix I{
            {1, 0},
            {0, 1}
        };

        assert(equalMatrices(multiply(A, I), A));
    }


    // Test 4: Zero matrix
    {
        Matrix A{
            {1, 2},
            {3, 4}
        };

        Matrix Z{
            {0, 0},
            {0, 0}
        };

        Matrix expected{
            {0, 0},
            {0, 0}
        };

        assert(equalMatrices(multiply(A, Z), expected));
    }


    // Test 5: Row multiplied by column
    {
        Matrix A{
            {1, 2, 3}
        };

        Matrix B{
            {4},
            {5},
            {6}
        };

        Matrix expected{
            {32}
        };

        assert(equalMatrices(multiply(A, B), expected));
    }


    // Test 6: Invalid matrix dimensions
    {
        bool exceptionThrown = false;

        try
        {
            Matrix A{
                {1, 2, 3}
            };

            Matrix B{
                {1, 2},
                {3, 4}
            };

            multiply(A, B);
        }
        catch (const std::invalid_argument&)
        {
            exceptionThrown = true;
        }

        assert(exceptionThrown);
    }


    std::cout << "All unit tests passed.\n";
}


// ----------------------------------------------------
// Create random matrix for performance testing
// ----------------------------------------------------
Matrix randomMatrix(std::size_t rows, std::size_t columns)
{
    std::mt19937 generator(42);

    std::uniform_real_distribution<double>
        distribution(-10.0, 10.0);

    Matrix matrix(
        rows,
        std::vector<double>(columns)
    );

    for (auto& row : matrix)
    {
        for (double& value : row)
        {
            value = distribution(generator);
        }
    }

    return matrix;
}


// ----------------------------------------------------
// Execution time test
// ----------------------------------------------------
void benchmark(std::size_t n)
{
    Matrix A = randomMatrix(n, n);
    Matrix B = randomMatrix(n, n);

    auto start =
        std::chrono::high_resolution_clock::now();

    Matrix C = multiply(A, B);

    auto end =
        std::chrono::high_resolution_clock::now();

    std::chrono::duration<double, std::milli>
        elapsed = end - start;

    std::cout
        << n << "x" << n
        << ": "
        << std::fixed
        << std::setprecision(3)
        << elapsed.count()
        << " ms\n";

    // Prevent compiler from treating C as completely unused
    volatile double value = C[0][0];
    (void)value;
}


// ----------------------------------------------------
// Main
// ----------------------------------------------------
int main()
{
    runUnitTests();

    std::cout << "\nExecution time:\n";

    benchmark(100);
    benchmark(200);
    benchmark(400);

    return 0;
}