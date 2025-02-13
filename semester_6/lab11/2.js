class Queue {
    constructor(capacity) {
      this.capacity = capacity; 
      this.items = []; 
    }
  
    enqueue(item) {
      if (this.items.length >= this.capacity) {
        throw new Error("Очередь переполнена!");
      }
      this.items.push(item);
    }
  
    dequeue() {
      if (this.items.length === 0) {
        throw new Error("Очередь пуста!");
      }
      return this.items.shift();
    }
  
    isEmpty() {
      return this.items.length === 0;
    }
  
    size() {
      return this.items.length;
    }
  
    display() {
      console.log("Содержимое очереди:", this.items);
    }
  }
  
  class Credit {
    constructor(clientName, loanAmount, years) {
      this.clientName = clientName; 
      this.loanAmount = loanAmount; 
      this.years = years; 
    }
  
    displayInfo() {
      console.log(
        `Клиент: ${this.clientName}, Сумма кредита: ${this.loanAmount}, Срок: ${this.years} лет`
      );
    }
  }
  
  console.log("Тестирование с типом String:");
  const stringQueue = new Queue(3);
  stringQueue.enqueue("Первый");
  stringQueue.enqueue("Второй");
  stringQueue.enqueue("Третий");
  stringQueue.display();
  stringQueue.dequeue();
  stringQueue.display();
  
  console.log("\nТестирование с типом Number:");
  const numberQueue = new Queue(2);
  numberQueue.enqueue(100);
  numberQueue.enqueue(200);
  numberQueue.display();
  numberQueue.dequeue();
  numberQueue.display();
  
  console.log("\nТестирование с типом Double:");
  const doubleQueue = new Queue(2);
  doubleQueue.enqueue(10.5);
  doubleQueue.enqueue(20.75);
  doubleQueue.display();
  doubleQueue.dequeue();
  doubleQueue.display();
  
  console.log("\nТестирование с пользовательским типом Credit:");
  const creditQueue = new Queue(2);
  const credit1 = new Credit("Иван Иванов", 500000, 15);
  const credit2 = new Credit("Мария Петрова", 300000, 10);
  
  creditQueue.enqueue(credit1);
  creditQueue.enqueue(credit2);
  creditQueue.display();
  
  const dequeuedCredit = creditQueue.dequeue();
  console.log("Удаленный элемент из очереди:");
  dequeuedCredit.displayInfo();
  
  creditQueue.display();