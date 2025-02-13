function generateMatrix(rows, cols, min = 0, max = 100) {
    const matrix = [];
    for (let i = 0; i < rows; i++) {
        const row = [];
        for (let j = 0; j < cols; j++) {
            row.push(Math.floor(Math.random() * (max - min + 1)) + min);
        }
        matrix.push(row);
    }
    return matrix;
}

function findMaxInColumns(matrix) {
    const cols = matrix[0].length;
    const maxValues = new Array(cols).fill(Number.MIN_SAFE_INTEGER);

    for (let i = 0; i < matrix.length; i++) {
        for (let j = 0; j < cols; j++) {
            if (matrix[i][j] > maxValues[j]) {
                maxValues[j] = matrix[i][j];
            }
        }
    }
    return maxValues;
}

const rows = 4; 
const cols = 5; 
const matrix = generateMatrix(rows, cols);

console.log("Сгенерированная матрица:");
console.table(matrix);

const maxValues = findMaxInColumns(matrix);
console.log("Вектор максимальных значений в каждом столбце:");
console.log(maxValues);