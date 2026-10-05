import numpy as np

rows_a = int(input("Rows of matrix A: "))
cols_a = int(input("Columns of matrix A: "))

rows_b = int(input("Rows of matrix B: "))
cols_b = int(input("Columns of matrix B: "))

if cols_a != rows_b:
    print("Matrices cannot be multiplied.")
    exit()

print("Enter matrix A:")

vals = list(map(int, input().split()))

mat_A = np.array(vals).reshape(rows_a, cols_a)

print("Enter matrix B:")

vals = list(map(int, input().split()))

mat_B = np.array(vals).reshape(rows_b, cols_b)

result = np.matmul(mat_A, mat_B)

print("Result:")
print(result)