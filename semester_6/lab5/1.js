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
  
  const rooms = [
    new Room("101", 2, "Высокая", 5000, "2023-05-15"),
    new Room("102", 4, "Средняя", 3000, "2022-11-20"),
    new Room("103", 3, "Высокая", 4500, "2024-01-10"),
    new Room("104", 1, "Низкая", 2000, "2021-12-25"),
  ];
  
  function getHighestComfortRooms(rooms) {
    const highestComfortRooms = rooms.filter(room => room.comfortType === "Высокая");
    console.log("Комнаты с наивысшей комфортностью:");
    highestComfortRooms.forEach(room => console.log(room.toString()));
  }
  
  function getRoomWithMaxPeople(rooms) {
    const maxPeopleRoom = rooms.reduce((maxRoom, room) => (room.numberPeople > maxRoom.numberPeople ? room : maxRoom), rooms[0]);
    console.log("Комната с максимальным количеством заселенных людей:");
    console.log(maxPeopleRoom.toString());
  }
  
  function getRoomsFrom2022(rooms) {
    const currentDate = new Date();
    const filteredRooms = rooms.filter(room => room.dateroom >= new Date("2022-01-01") && room.dateroom <= currentDate);
    console.log("Комнаты, заселенные с 2022 года по текущую дату:");
    filteredRooms.forEach(room => console.log(room.toString()));
  }
  
  getHighestComfortRooms(rooms);
  getRoomWithMaxPeople(rooms);
  getRoomsFrom2022(rooms);