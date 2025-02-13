const HotelRoom = require('./HotelRoom');

class StandardRoom extends HotelRoom {
    toString() {
        return `Стандартная комната: ${super.toString()}`;
    }
}

module.exports = StandardRoom;