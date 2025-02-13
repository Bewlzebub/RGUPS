class Room {
    constructor(coderoom, numberPeople, comfortType, price, dateroom) {
      this.coderoom = coderoom; // Код комнаты
      this.numberPeople = numberPeople; // Количество человек
      this.comfortType = comfortType; // Комфортность
      this.price = price; // Цена
      this.dateroom = new Date(dateroom); // Дата заселения
    }
  
    addPeople(count) {
      this.numberPeople += count;
    }
  
    removePeople(count) {
      this.numberPeople = Math.max(0, this.numberPeople - count);
    }
  
    toString() {
      return `Код комнаты: ${this.coderoom}, Количество человек: ${this.numberPeople}, Комфортность: ${this.comfortType}, Цена: ${this.price}, Дата заселения: ${this.dateroom.toDateString()}`;
    }
  }
  
  const hotelMap = new Map();
  
  function addRoom(coderoom, numberPeople, comfortType, price, dateroom) {
    const room = new Room(coderoom, numberPeople, comfortType, price, dateroom);
    hotelMap.set(coderoom, room);
    console.log(`Комната ${coderoom} добавлена.`);
  }
  
  function removeRoom(coderoom) {
    if (hotelMap.delete(coderoom)) {
      console.log(`Комната ${coderoom} удалена.`);
    } else {
      console.log(`Комната ${coderoom} не найдена.`);
    }
  }
  
  function editRoom(coderoom, field, newValue) {
    const room = hotelMap.get(coderoom);
    if (room) {
      room[field] = newValue;
      console.log(`Комната ${coderoom} обновлена.`);
    } else {
      console.log(`Комната ${coderoom} не найдена.`);
    }
  }
  
  function findRoomByField(field, value) {
    const results = Array.from(hotelMap.values()).filter((room) => room[field] === value);
    if (results.length > 0) {
      console.log("Найденные комнаты:");
      results.forEach((room) => console.log(room.toString()));
    } else {
      console.log("Комнаты не найдены.");
    }
  }
  
  function sortRoomsBy(field, ascending = true) {
    const sortedRooms = Array.from(hotelMap.values()).sort((a, b) => {
      if (ascending) {
        return a[field] > b[field] ? 1 : -1;
      } else {
        return a[field] < b[field] ? 1 : -1;
      }
    });
    console.log("Отсортированные комнаты:");
    sortedRooms.forEach((room) => console.log(room.toString()));
  }
  
  function reverseContainer() {
    const reversedRooms = Array.from(hotelMap.values()).reverse();
    console.log("Перевернутый контейнер:");
    reversedRooms.forEach((room) => console.log(room.toString()));
  }
  
  function findMaxMin(field) {
    const rooms = Array.from(hotelMap.values());
    const maxRoom = rooms.reduce((max, room) => (room[field] > max[field] ? room : max), rooms[0]);
    const minRoom = rooms.reduce((min, room) => (room[field] < min[field] ? room : min), rooms[0]);
    console.log("Максимальный элемент:", maxRoom.toString());
    console.log("Минимальный элемент:", minRoom.toString());
  }
  
  function clearContainer() {
    hotelMap.clear();
    console.log("Контейнер очищен.");
  }
  
  function printContainer() {
    if (hotelMap.size === 0) {
      console.log("Контейнер пуст.");
    } else {
      console.log("Содержимое контейнера:");
      hotelMap.forEach((room) => console.log(room.toString()));
    }
  }
  
  addRoom("101", 2, "Высокая", 5000, "2023-05-15");
  addRoom("102", 4, "Средняя", 3000, "2022-11-20");
  addRoom("103", 3, "Высокая", 4500, "2024-01-10");
  addRoom("104", 1, "Низкая", 2000, "2021-12-25");
  
  printContainer();
  sortRoomsBy("dateroom", true); 
  sortRoomsBy("numberPeople", false); 
  findMaxMin("price"); 
  reverseContainer(); 
  clearContainer(); 
  printContainer();