const { app, BrowserWindow } = require('electron');
const path = require('path'); 

let mainWindow;

app.on('ready', () => {
  mainWindow = new BrowserWindow({
    width: 400,
    height: 300,
    webPreferences: {
      nodeIntegration: true,
    },
  });

  const indexPath = path.join(__dirname, 'index.html');
  mainWindow.loadFile(indexPath);
});