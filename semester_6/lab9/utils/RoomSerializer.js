const StandardRoom = require('../models/StandardRoom');
const SemiLuxRoom = require('../models/SemiLuxRoom');
const LuxRoom = require('../models/LuxRoom');

class RoomSerializer {
    static serialize(room) {
        return JSON.stringify(room);
    }

    static deserialize(jsonString) {
        const data = JSON.parse(jsonString);
        if (data.minStay !== undefined && data.maxStay !== undefined) {
            return new LuxRoom(data.coderoom, data.numberPeople, data.comfortType, data.price, data.dateroom, data.minStay, data.maxStay);
        } else if (data.minStay !== undefined) {
            return new SemiLuxRoom(data.coderoom, data.numberPeople, data.comfortType, data.price, data.dateroom, data.minStay);
        } else {
            return new StandardRoom(data.coderoom, data.numberPeople, data.comfortType, data.price, data.dateroom);
        }
    }
}

module.exports = RoomSerializer;