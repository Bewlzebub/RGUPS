const readline = require('readline');
const HotelManagement = require('./utils/HotelManagement');
const StandardRoom = require('./models/StandardRoom');
const SemiLuxRoom = require('./models/SemiLuxRoom');
const LuxRoom = require('./models/LuxRoom');

const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

function displayMenu() {
    console.log('1. Добавить комнату');
    console.log('2. Изменить комнату');
    console.log('3. Найти комнату');
    console.log('4. Удалить комнату');
    console.log('5. Сортировать комнаты');
    console.log('6. Сохранить в файл');
    console.log('7. Загрузить из файла');
    console.log('8. Выйти');
}

function main() {
    const hotel = new HotelManagement();

    function prompt() {
        displayMenu();
        rl.question('Выберите действие: ', (choice) => {
            switch (choice) {
                case '1':
                    rl.question('Введите код комнаты, количество человек, комфортность, цену и дату заселения через запятую: ', (input) => {
                        const [coderoom, numberPeople, comfortType, price, dateroom] = input.split(',');
                        hotel.addRoom(new StandardRoom(coderoom, parseInt(numberPeople), comfortType, parseFloat(price), dateroom));
                        console.log('Комната добавлена.');
                        prompt();
                    });
                    break;
                case '2':
                    // Логика изменения комнаты
                    break;
                case '3':
                    rl.question('Введите код комнаты для поиска: ', (coderoom) => {
                        const room = hotel.findRoom(coderoom);
                        console.log(room ? room.toString() : 'Комната не найдена.');
                        prompt();
                    });
                    break;
                case '4':
                    rl.question('Введите код комнаты для удаления: ', (coderoom) => {
                        hotel.removeRoom(coderoom);
                        console.log('Комната удалена.');
                        prompt();
                    });
                    break;
                case '5':
                    hotel.sortRooms();
                    console.log(hotel.toString());
                    prompt();
                    break;
                case '6':
                    hotel.saveToFile('semester_6/lab9/rooms.json');
                    console.log('Список комнат сохранен в файл.');
                    prompt();
                    break;
                case '7':
                    hotel.loadFromFile('semester_6/lab9/rooms.json');
                    console.log('Список комнат загружен из файла.');
                    prompt();
                    break;
                case '8':
                    rl.close();
                    return;
                default:
                    console.log('Неверный выбор. Попробуйте снова.');
                    prompt();
            }
        });
    }

    prompt();
}

main();