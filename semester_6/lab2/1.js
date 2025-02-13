const sourceArray = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
const allowedValues = [2, 4, 6, 8, 10];

const filteredArray = sourceArray.filter(value => allowedValues.includes(value));

console.log(`Количество элементов с разрешенными значениями: ${filteredArray.length}`);
console.log(`Элементы с разрешенными значениями: ${filteredArray}`);