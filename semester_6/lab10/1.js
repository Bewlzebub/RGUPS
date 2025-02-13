class Shape {
    constructor() {
      if (new.target === Shape) {
        throw new Error("Нельзя создать экземпляр абстрактного класса Shape");
      }
    }
  
    getPerimeter() {
      throw new Error("Метод getPerimeter() должен быть переопределен");
    }
  
    getArea() {
      throw new Error("Метод getArea() должен быть переопределен");
    }
  
    displayInfo() {
      throw new Error("Метод displayInfo() должен быть переопределен");
    }
  }
  
  class Point extends Shape {
    constructor(x, y) {
      super();
      this._x = x; 
      this._y = y;
    }
  
    getPerimeter() {
      return 0; 
    }
  
    getArea() {
      return 0; 
    }
  
    displayInfo() {
      console.log(`Класс: Точка, координаты: (${this._x}, ${this._y})`);
    }
  
    displayFields() {
      console.log(`Координаты точки: x = ${this._x}, y = ${this._y}`);
    }
  }
  
  class Polygon extends Point {
    constructor(x, y, sides, sideLength) {
      super(x, y);
      this._sides = sides;
      this._sideLength = sideLength; 
    }
  
    getPerimeter() {
      return this._sides * this._sideLength; 
    }
  
    getArea() {
      const apothem = this._sideLength / (2 * Math.tan(Math.PI / this._sides));
      return (this.getPerimeter() * apothem) / 2;
    }
  
    displayInfo() {
      console.log(
        `Класс: Многоугольник, количество сторон: ${this._sides}, длина стороны: ${this._sideLength}`
      );
    }
  
    displayFields() {
      console.log(
        `Многоугольник: x = ${this._x}, y = ${this._y}, стороны = ${this._sides}, длина стороны = ${this._sideLength}`
      );
    }
  }
  
  class Polyhedron extends Polygon {
    constructor(x, y, sides, sideLength, height) {
      super(x, y, sides, sideLength);
      this._height = height; 
    }
  
    getArea() {
      const baseArea = super.getArea(); 
      const lateralArea = this.getPerimeter() * this._height; 
      return 2 * baseArea + lateralArea; 
    }
  
    getVolume() {
      const baseArea = super.getArea();
      return baseArea * this._height; 
    }
  
    displayInfo() {
      console.log(
        `Класс: Многогранник, количество сторон: ${this._sides}, длина стороны: ${this._sideLength}, высота: ${this._height}`
      );
    }
  
    displayFields() {
      console.log(
        `Многогранник: x = ${this._x}, y = ${this._y}, стороны = ${this._sides}, длина стороны = ${this._sideLength}, высота = ${this._height}`
      );
    }
  }
  
  const shapes = [];
  
  const point = new Point(1, 2);
  const polygon = new Polygon(0, 0, 5, 10); 
  const polyhedron = new Polyhedron(0, 0, 4, 8, 12); 
  
  shapes.push(point, polygon, polyhedron);
  
  shapes.forEach((shape) => {
    shape.displayInfo();
    console.log(`Периметр: ${shape.getPerimeter()}`);
    console.log(`Площадь: ${shape.getArea()}`);
    if (shape instanceof Polyhedron) {
      console.log(`Объем: ${shape.getVolume()}`);
    }
    shape.displayFields();
    console.log("----------");
  });