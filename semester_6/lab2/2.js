function findZeroIndex(arr) {
    for (let i = 0; i < arr.length; i++) {
      if (arr[i] === 0) {
        return i; 
      }
    }
    return -1; 
  }
  
  function bubbleSortAfterZero(arr) {
    const zeroIndex = findZeroIndex(arr);
    if (zeroIndex === -1) {
      console.log("Нулевой элемент не найден в массиве.");
      return arr; 
    }
  
    for (let i = zeroIndex + 1; i < arr.length; i++) {
      for (let j = zeroIndex + 1; j < arr.length - 1; j++) {
        if (arr[j] > arr[j + 1]) {
          [arr[j], arr[j + 1]] = [arr[j + 1], arr[j]];
        }
      }
    }
  
    return arr;
  }
  
  const array = [5, 3, 0, 8, 1, 7, 2];
  console.log("Исходный массив:", array);
  
  const zeroIndex = findZeroIndex(array);
  console.log("Индекс нулевого элемента:", zeroIndex);
  
  const sortedArray = bubbleSortAfterZero(array);
  console.log("Массив после сортировки элементов за нулевым:", sortedArray);