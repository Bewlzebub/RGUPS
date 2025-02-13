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
  
  const roomSet = new Set();
  
  function addRoom(room) {
    roomSet.add(room);
  }
  
  function removeRoom(coderoom) {
    for (let room of roomSet) {
      if (room.coderoom === coderoom) {
        roomSet.delete(room);
        console.log(`Комната с кодом ${coderoom} удалена.`);
        return;
      }
    }
    console.log(`Комната с кодом ${coderoom} не найдена.`);
  }
  
  function editRoom(coderoom, field, newValue) {
    for (let room of roomSet) {
      if (room.coderoom === coderoom) {
        room[field] = newValue;
        console.log(`Комната с кодом ${coderoom} обновлена.`);
        return;
      }
    }
    console.log(`Комната с кодом ${coderoom} не найдена.`);
  }
  
  function findRoomsByField(field, value) {
    const results = [...roomSet].filter(room => room[field] === value);
    console.log(`Результаты поиска по ${field} = ${value}:`);
    results.forEach(room => console.log(room.toString()));
  }
  
  function sortRoomsByYearAscending() {
    const sortedRooms = [...roomSet].sort((a, b) => a.dateroom - b.dateroom);
    console.log("Комнаты, отсортированные по возрастанию года заселения:");
    sortedRooms.forEach(room => console.log(room.toString()));
  }
  
  function sortRoomsByPeopleDescending() {
    const sortedRooms = [...roomSet].sort((a, b) => b.numberPeople - a.numberPeople);
    console.log("Комнаты, отсортированные по убыванию количества человек:");
    sortedRooms.forEach(room => console.log(room.toString()));
  }
  
  function reverseRooms() {
    const reversedRooms = [...roomSet].reverse();
    console.log("Перевернутый контейнер:");
    reversedRooms.forEach(room => console.log(room.toString()));
  }
  
  function findMaxAndMinRooms() {
    const maxRoom = [...roomSet].reduce((max, room) => (room.price > max.price ? room : max), [...roomSet][0]);
    const minRoom = [...roomSet].reduce((min, room) => (room.price < min.price ? room : min), [...roomSet][0]);
    console.log("Максимальная комната:");
    console.log(maxRoom.toString());
    console.log("Минимальная комната:");
    console.log(minRoom.toString());
  }
  
  function clearRooms() {
    roomSet.clear();
    console.log("Контейнер очищен.");
  }
  
  function printRooms() {
    console.log("Список всех комнат:");
    roomSet.forEach(room => console.log(room.toString()));
  }
  
  addRoom(new Room("101", 2, "Высокая", 5000, "2023-05-15"));
  addRoom(new Room("102", 4, "Средняя", 3000, "2022-11-20"));
  addRoom(new Room("103", 3, "Высокая", 4500, "2024-01-10"));
  addRoom(new Room("104", 1, "Низкая", 2000, "2021-12-25"));
  
  printRooms();
  sortRoomsByYearAscending();
  sortRoomsByPeopleDescending();
  findMaxAndMinRooms();
  reverseRooms();
  findRoomsByField("comfortType", "Высокая");
  editRoom("101", "price", 5500);
  removeRoom("102");
  clearRooms();