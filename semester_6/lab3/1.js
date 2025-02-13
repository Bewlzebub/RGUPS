const readline = require('readline');

const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
});

let stringArray = [];

function showMenu() {
  console.log("\nМеню:");
  console.log("1) Ввод массива строк с клавиатуры");
  console.log("2) Вывести на экран номера позиций, в которых встречается символ ';'");
  console.log("3) Заменить все слова 'Pascal' на 'C++'");
  console.log("4) Удалить все цифры");
  console.log("5) Сортировка первой строки по алфавитному порядку по возрастанию");
  console.log("6) Исправить ошибки: добавить пробелы после точек");
  console.log("7) Вывод массива строк на консоль");
  console.log("0) Выход");
  rl.question("Выберите действие: ", handleMenu);
}

function handleMenu(choice) {
  switch (choice) {
    case "1":
      inputStrings();
      break;
    case "2":
      findSemicolonPositions();
      break;
    case "3":
      replacePascalWithCpp();
      break;
    case "4":
      removeDigits();
      break;
    case "5":
      sortFirstString();
      break;
    case "6":
      fixSpacingAfterDots();
      break;
    case "7":
      printStrings();
      break;
    case "0":
      rl.close();
      break;
    default:
      console.log("Неверный выбор. Попробуйте снова.");
      showMenu();
  }
}

// 1) Ввод массива строк с клавиатуры
function inputStrings() {
  rl.question("Введите строки через запятую: ", (input) => {
    stringArray = input.split(",").map((str) => str.trim());
    console.log("Массив строк успешно сохранен.");
    showMenu();
  });
}

// 2) Вывести на экран номера позиций, в которых встречается символ ';'
function findSemicolonPositions() {
  stringArray.forEach((str, index) => {
    const positions = [];
    for (let i = 0; i < str.length; i++) {
      if (str[i] === ";") {
        positions.push(i);
      }
    }
    console.log(`Строка ${index + 1}: позиции символа ';' - ${positions.join(", ") || "нет"}`);
  });
  showMenu();
}

// 3) Заменить все слова 'Pascal' на 'C++'
function replacePascalWithCpp() {
  stringArray = stringArray.map((str) => str.replace(/Pascal/g, "C++"));
  console.log("Все слова 'Pascal' заменены на 'C++'.");
  showMenu();
}

// 4) Удалить все цифры
function removeDigits() {
  stringArray = stringArray.map((str) => str.replace(/\d/g, ""));
  console.log("Все цифры удалены.");
  showMenu();
}

// 5) Сортировка первой строки по алфавитному порядку по возрастанию
function sortFirstString() {
  if (stringArray.length > 0) {
    stringArray[0] = stringArray[0].split("").sort().join("");
    console.log("Первая строка отсортирована по алфавиту.");
  } else {
    console.log("Массив строк пуст.");
  }
  showMenu();
}

// 6) Исправить ошибки: добавить пробелы после точек
function fixSpacingAfterDots() {
  stringArray = stringArray.map((str) => str.replace(/\.([^\s])/g, ". $1"));
  console.log("Ошибки исправлены: пробелы добавлены после точек.");
  showMenu();
}

// 7) Вывод массива строк на консоль
function printStrings() {
  console.log("Массив строк:");
  stringArray.forEach((str, index) => {
    console.log(`${index + 1}: ${str}`);
  });
  showMenu();
}

console.log("Добро пожаловать в программу обработки массива строк!");
showMenu();