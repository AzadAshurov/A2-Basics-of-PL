import numpy as np
import matplotlib.pyplot as plt

rows= int(input("Rows of matrix: "))
cols = int(input("Columns of matrix: "))

print("Enter matrix:")
vals = list(map(int, input().split()))
mat = np.array(vals).reshape(rows, cols)

print("Matrix:")
print(mat)

print("Matrix size:", rows, "x", cols)
print("Write a slicing for the matrix (row_start, row_end, col_start, col_end):")
slicing = list(map(int, input().split()))
print("Sliced matrix:")
new_mat = mat[slicing[0]-1:slicing[1], slicing[2]-1:slicing[3]]
print(new_mat)



plt.rcParams["font.size"] = 20
ax = plt.figure().add_subplot(xticks=[], yticks=[])

text = ax.text(.1, .5, str(mat), color="blue")
text = ax.text(.6, .5, str(new_mat), color="red")




plt.show()