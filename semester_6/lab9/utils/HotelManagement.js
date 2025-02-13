const RoomSerializer = require('./RoomSerializer');
const fs = require('fs');

class HotelManagement {
    constructor() {
        this.rooms = [];
    }

    addRoom(room) {
        this.rooms.push(room);
    }

    updateRoom(index, room) {
        this.rooms[index] = room;
    }

    findRoom(coderoom) {
        return this.rooms.find(room => room.coderoom === coderoom);
    }

    removeRoom(coderoom) {
        this.rooms = this.rooms.filter(room => room.coderoom !== coderoom);
    }

    sortRooms() {
        this.rooms.sort((a, b) => a.compareTo(b));
    }

    saveToFile(filename) {
        const data = this.rooms.map(room => RoomSerializer.serialize(room));
        fs.writeFileSync(filename, JSON.stringify(data));
    }

    loadFromFile(filename) {
        const data = JSON.parse(fs.readFileSync(filename, 'utf8'));
        this.rooms = data.map(jsonString => RoomSerializer.deserialize(jsonString));
    }

    toString() {
        return this.rooms.map(room => room.toString()).join('\n');
    }
}

module.exports = HotelManagement;