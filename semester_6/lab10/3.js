class Train {
    constructor(nazn, numr, time) {
      this.nazn = nazn; 
      this.numr = numr; 
      this.time = time; 
    }
  
    printInfo() {
      console.log(`Поезд до ${this.nazn}, Номер: ${this.numr}, Отправление: ${this.time}`);
    }
  }
  
  const customInterface = (train) => {
    return `Поезд ${train.numr} направляется в ${train.nazn} в ${train.time}`;
  };
  
  const comparator = (train1, train2) => {
    return train1.time.localeCompare(train2.time); 
  };
  
  const consumer = (train) => {
    train.printInfo(); 
  };
  
  const trains = [
    new Train("Москва", 101, "12:30"),
    new Train("Санкт-Петербург", 102, "10:15"),
    new Train("Казань", 103, "14:45"),
  ];
  
  console.log("Пример использования собственного интерфейса:");
  trains.forEach((train) => console.log(customInterface(train)));
  
  console.log("\nСортировка поездов по времени отправления:");
  trains.sort((train1, train2) => {
    return comparator(train1, train2);
  });
  trains.forEach((train) => train.printInfo());
  
  console.log("\nИспользование Consumer:");
  trains.forEach((train) => consumer(train));
  
  console.log("\nСсылки на методы и конструктор:");
  const methodReference = trains[0].printInfo.bind(trains[0]); 
  methodReference(); 
  
  const trainConstructor = Train; 
  const newTrain = new trainConstructor("Новосибирск", 104, "16:00"); 
  newTrain.printInfo(); 