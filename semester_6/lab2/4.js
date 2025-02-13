function processMatrix(matrix) {
    try {
        const n = matrix.length;
        if (!matrix.every(row => row.length === n)) {
            throw new Error("Матрица должна быть квадратной (n x n).");
        }

        for (let i = 0; i < n; i++) {
            for (let j = 0; j < n; j++) {
                if (typeof matrix[i][j] !== 'number') {
                    throw new Error("Матрица должна содержать только числа.");
                }
            }
        }

        let minMainDiag = matrix[0][0];
        let maxMainDiag = matrix[0][0];
        for (let i = 0; i < n; i++) {
            if (matrix[i][i] < minMainDiag) {
                minMainDiag = matrix[i][i];
            }
            if (matrix[i][i] > maxMainDiag) {
                maxMainDiag = matrix[i][i];
            }
        }

        const productMainDiag = minMainDiag * maxMainDiag;

        for (let i = 0; i < n; i++) {
            matrix[i][n - i - 1] *= maxMainDiag;
        }

        return {
            productMainDiag,
            updatedMatrix: matrix
        };
    } catch (error) {
        console.error("Ошибка:", error.message);
        return null;
    }
}

const matrix = [
    [2, 3, 4],
    [5, 6, 7],
    [8, 9, 1]
];

const result = processMatrix(matrix);

if (result) {
    console.log("Произведение минимального и максимального элементов главной диагонали:", result.productMainDiag);
    console.log("Обновленная матрица после умножения побочной диагонали:", result.updatedMatrix);
}