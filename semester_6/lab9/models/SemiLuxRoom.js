const HotelRoom = require('./HotelRoom');

class SemiLuxRoom extends HotelRoom {
    constructor(coderoom, numberPeople, comfortType, price, dateroom, minStay) {
        super(coderoom, numberPeople, comfortType, price, dateroom);
        this.minStay = minStay;
    }

    toString() {
        return `Комната полулюкс: ${super.toString()}, Минимальный срок проживания: ${this.minStay}`;
    }

    compareTo(other) {
        return this.minStay - other.minStay;
    }
}

module.exports = SemiLuxRoom;