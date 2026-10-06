import numpy as np

rows= int(input("Rows of matrix: "))
cols = int(input("Columns of matrix: "))

print("Enter matrix A:")
vals = list(map(int, input().split()))
mat = np.array(vals).reshape(rows, cols)

print("Matrix:")
print(mat)

print("Matrix size:", cols, "x", rows)
print("Write a slicing for the matrix (row_start, row_end, col_start, col_end):")
slicing = list(map(int, input().split()))
print("Sliced matrix:")
print(mat[slicing[0]-1:slicing[1], slicing[2]-1:slicing[3]])