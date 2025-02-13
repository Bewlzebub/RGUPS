class Modifier {
    modify(obj) {
      throw new Error("Method 'modify' must be implemented");
    }
  }
  
  class Book {
    constructor(author, title, publisher, year, pages) {
      this.author = author; 
      this.title = title; 
      this.publisher = publisher; 
      this.year = year; 
      this.pages = pages; 
    }
  
    printInfo() {
      console.log(
        `Книга: "${this.title}", Автор: ${this.author}, Издательство: ${this.publisher}, Год: ${this.year}, Страниц: ${this.pages}`
      );
    }
  }
  
  class BookModifier extends Modifier {
    modify(book) {
      if (!(book instanceof Book)) {
        throw new Error("Object must be an instance of Book");
      }
      book.pages += 10;
      console.log(`Изменено количество страниц книги: ${book.pages}`);
    }
  }
  
  class GenericModifier extends Modifier {
    modify(obj) {
      console.log("Объект был изменен (обобщенный модификатор)");
      return obj;
    }
  }
    
  const book1 = new Book("Лев Толстой", "Война и мир", "Русское издательство", 1869, 1225);
  const book2 = new Book("Федор Достоевский", "Преступление и наказание", "Русское издательство", 1866, 672);
  
  console.log("Информация о книгах до модификации:");
  book1.printInfo();
  book2.printInfo();
  
  const bookModifier = new BookModifier();
  console.log("\nМодификация книги с использованием BookModifier:");
  bookModifier.modify(book1);
  book1.printInfo();
  
  const genericModifier = new GenericModifier();
  console.log("\nМодификация книги с использованием GenericModifier:");
  genericModifier.modify(book2);
  book2.printInfo();