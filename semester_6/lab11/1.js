class MenuItem {
    constructor(name, weight, price) {
      this.name = name; 
      this.weight = weight; 
      this.price = price; 
    }
  }
  
  function calculateTotalCost(items) {
    if (!Array.isArray(items)) {
      throw new Error("Input must be an array of MenuItem objects.");
    }
  
    return items.reduce((total, item) => {
      if (!(item instanceof MenuItem)) {
        throw new Error("All elements in the array must be instances of MenuItem.");
      }
      return total + item.price;
    }, 0);
  }
  
  const menu = [
    new MenuItem("Мороженое", 150, 100),
    new MenuItem("Пирожное", 200, 150),
    new MenuItem("Сок", 250, 50),
  ];
  
  console.log("Меню детского кафе:");
  menu.forEach((item) => {
    console.log(`Название: ${item.name}, Вес: ${item.weight}г, Цена: ${item.price} руб.`);
  });
  
  try {
    const totalCost = calculateTotalCost(menu);
    console.log(`\nОбщая стоимость заказа: ${totalCost} руб.`);
  } catch (error) {
    console.error(error.message);
  }