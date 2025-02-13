class Student {
    getInfo() {
      throw new Error("Метод getInfo() должен быть реализован");
    }
  
    getPerformance() {
      throw new Error("Метод getPerformance() должен быть реализован");
    }
  
    getAttendance() {
      throw new Error("Метод getAttendance() должен быть реализован");
    }
  
    getScholarship() {
      throw new Error("Метод getScholarship() должен быть реализован");
    }
  
    defaultMethod() {
      console.log("Это метод по умолчанию из интерфейса Student");
    }
  
    static maxRetakes() {
      return 3;
    }
  }
  
class ExcellentStudent extends Student {
    constructor(name) {
      super();
      this.name = name;
    }
  
    getInfo() {
      return `Студент: ${this.name}, статус: Отличник`;
    }
  
    getPerformance() {
      return "Успеваемость: Отлично";
    }
  
    getAttendance() {
      return "Посещаемость: 100%";
    }
  
    getScholarship() {
      return "Стипендия: 10000 руб.";
    }
  }
  
class GoodStudent extends Student {
    constructor(name) {
      super();
      this.name = name;
    }
  
    getInfo() {
      return `Студент: ${this.name}, статус: Хорошист`;
    }
  
    getPerformance() {
      return "Успеваемость: Хорошо";
    }
  
    getAttendance() {
      return "Посещаемость: 90%";
    }
  
    getScholarship() {
      return "Стипендия: 7000 руб.";
    }
  }
  
class AverageStudent extends Student {
    constructor(name) {
      super();
      this.name = name;
    }
  
    getInfo() {
      return `Студент: ${this.name}, статус: Троечник`;
    }
  
    getPerformance() {
      return "Успеваемость: Удовлетворительно";
    }
  
    getAttendance() {
      return "Посещаемость: 75%";
    }
  
    getScholarship() {
      return "Стипендия: Не начисляется";
    }
  }
  
class PoorStudent extends Student {
    constructor(name) {
      super();
      this.name = name;
      this.retakes = 0;
    }
  
    getInfo() {
      return `Студент: ${this.name}, статус: Двоечник`;
    }
  
    getPerformance() {
      return "Успеваемость: Неудовлетворительно";
    }
  
    getAttendance() {
      return "Посещаемость: 50%";
    }
  
    getScholarship() {
      return `Стипендия: Не начисляется. Пересдачи: ${this.retakes}/${Student.maxRetakes()}`;
    }
  
    addRetake() {
      if (this.retakes < Student.maxRetakes()) {
        this.retakes++;
      } else {
        console.log(`${this.name} отчислен за неуспеваемость.`);
      }
    }
  }
  
  const students = [
    new ExcellentStudent("Иван"),
    new GoodStudent("Мария"),
    new AverageStudent("Петр"),
    new PoorStudent("Алексей"),
  ];
  
  students.forEach((student) => {
    console.log(student.getInfo());
    console.log(student.getPerformance());
    console.log(student.getAttendance());
    console.log(student.getScholarship());
    student.defaultMethod();
    console.log("--------------------");
  });
  
  const poorStudent = students.find((s) => s instanceof PoorStudent);
  if (poorStudent) {
    poorStudent.addRetake();
    poorStudent.addRetake();
    poorStudent.addRetake();
    poorStudent.addRetake(); 
  }