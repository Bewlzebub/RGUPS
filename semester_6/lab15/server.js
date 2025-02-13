const fs = require('fs');
const path = require('path');
const net = require('net');

const filePath = path.join(__dirname, 'sonnets.txt');
const sonnets = fs.readFileSync(filePath, 'utf-8').split('\n\n'); 

const server = net.createServer((socket) => {
  console.log('Клиент подключился');

  const randomSonnet = sonnets[Math.floor(Math.random() * sonnets.length)];

  socket.write(randomSonnet);
  socket.end();
});

server.listen(3000, () => {
  console.log('Сервер запущен на порту 3000');
});