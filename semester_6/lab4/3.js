function evaluateExpression(expression) {
    try {
      if (!/^[0-9+\-*/().\s]+$/.test(expression)) {
        throw new Error("Недопустимые символы в выражении");
      }
  
      const result = eval(expression);
      return result;
    } catch (error) {
      return `Ошибка в выражении: ${error.message}`;
    }
  }
  
  const input = "12.34 + (56.78 / 2) - 3.21";
  console.log(`Выражение: ${input}`);
  console.log(`Результат: ${evaluateExpression(input)}`);