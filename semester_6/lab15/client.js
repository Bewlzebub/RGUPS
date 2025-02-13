const net = require('net');

const client = net.createConnection({ port: 3000 }, () => {
  console.log('Подключение к серверу установлено');
});

client.on('data', (data) => {
  console.log('Получен сонет:');
  console.log(data.toString());
  client.end(); 
});

client.on('end', () => {
  console.log('Соединение с сервером закрыто');
});