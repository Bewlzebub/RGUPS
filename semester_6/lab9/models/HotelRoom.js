class HotelRoom {
    constructor(coderoom, numberPeople, comfortType, price, dateroom) {
        this.coderoom = coderoom;
        this.numberPeople = numberPeople;
        this.comfortType = comfortType;
        this.price = price;
        this.dateroom = new Date(dateroom);
    }

    addPeople(count) {
        this.numberPeople += count;
    }

    removePeople(count) {
        this.numberPeople = Math.max(0, this.numberPeople - count);
    }

    compareTo(other) {
        return this.price - other.price;
    }

    toString() {
        return `Код комнаты: ${this.coderoom}, Количество человек: ${this.numberPeople}, Комфортность: ${this.comfortType}, Цена: ${this.price}, Дата заселения: ${this.dateroom.toDateString()}`;
    }
}

module.exports = HotelRoom;