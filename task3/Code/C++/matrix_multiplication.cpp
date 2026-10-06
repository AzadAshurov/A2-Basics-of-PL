#include <iostream>
#include <vector>
using namespace std;

int main() {
    int n, m, k, q;
    cout << "Enter number of rows for matrix A: ";
    cin >> n;
    cout << "Enter number of columns for matrix A: ";
    cin >> m;
    vector<vector<double>> matrixA(n, vector<double>(m));
    cout << "Enter matrix A values:\n";
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
            cin >> matrixA[i][j];
        }
    }
    
    cout << "Enter number of rows for matrix B: ";
    cin >> q;
    cout << "Enter number of columns for matrix B: ";
    cin >> k;
  

    if (m != q) {
        cout << "Error: Number of columns in matrix A must be equal to number of rows in matrix B.\n";
        return 1;
    }
    vector<vector<double>> matrixB(q, vector<double>(k));
    cout << "Enter matrix B values:\n";

    for (int i = 0; i < q; i++) {
        for (int j = 0; j < k; j++) {
            cin >> matrixB[i][j];
        }
    }

    vector<vector<double>> result(n, vector<double>(k, 0));
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < k; j++) {
            for (int x = 0; x < m; x++) {
                result[i][j] += matrixA[i][x] * matrixB[x][j];
            }
        }
    }

    cout << "Result:\n";
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < k; j++) {
            cout << result[i][j] << " ";
        }
        cout << "\n";
    }
    cout << "End of program.\n";
    return 0;
}