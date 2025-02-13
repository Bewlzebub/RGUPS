const HotelRoom = require('./HotelRoom');

class LuxRoom extends HotelRoom {
    constructor(coderoom, numberPeople, comfortType, price, dateroom, minStay, maxStay) {
        super(coderoom, numberPeople, comfortType, price, dateroom);
        this.minStay = minStay;
        this.maxStay = maxStay;
    }

    toString() {
        return `Комната люкс: ${super.toString()}, Минимальный срок проживания: ${this.minStay}, Максимальный срок проживания: ${this.maxStay}`;
    }

    compareTo(other) {
        return this.maxStay - other.maxStay;
    }
}

module.exports = LuxRoom;