const fs = require('fs');
const archiver = require('archiver');
const unzipper = require('adm-zip');

let collection = [
  { id: 1, name: "Item 1", value: 100 },
  { id: 2, name: "Item 2", value: 200 },
  { id: 3, name: "Item 3", value: 300 },
];

// Сохранение коллекции в бинарный файл
function saveToBinaryFile(filename, data) {
  const buffer = Buffer.from(JSON.stringify(data));
  fs.writeFileSync(filename, buffer);
  console.log(`Коллекция сохранена в бинарный файл: ${filename}`);
}

// Извлечение коллекции из бинарного файла
function loadFromBinaryFile(filename) {
  const buffer = fs.readFileSync(filename);
  const data = JSON.parse(buffer.toString());
  console.log(`Коллекция загружена из бинарного файла: ${filename}`);
  return data;
}

// Сохранение коллекции в текстовый файл
function saveToTextFile(filename, data) {
  const text = JSON.stringify(data, null, 2);
  fs.writeFileSync(filename, text, 'utf8');
  console.log(`Коллекция сохранена в текстовый файл: ${filename}`);
}

// Извлечение коллекции из текстового файла
function loadFromTextFile(filename) {
  const text = fs.readFileSync(filename, 'utf8');
  const data = JSON.parse(text);
  console.log(`Коллекция загружена из текстового файла: ${filename}`);
  return data;
}

// Сериализация коллекции
function serializeCollection(filename, data) {
  const serializedData = JSON.stringify(data);
  fs.writeFileSync(filename, serializedData, 'utf8');
  console.log(`Коллекция сериализована в файл: ${filename}`);
}

// Десериализация коллекции
function deserializeCollection(filename) {
  const serializedData = fs.readFileSync(filename, 'utf8');
  const data = JSON.parse(serializedData);
  console.log(`Коллекция десериализована из файла: ${filename}`);
  return data;
}

// Архивирование файлов
function archiveFiles(zipFilename, file) {
    const output = fs.createWriteStream(zipFilename);
    const archive = archiver('zip', { zlib: { level: 9 } }); // Используем формат ZIP

    // Обработка ошибок
    output.on('close', () => {
        console.log(`Файл архивирован в: ${zipFilename} (${archive.pointer()} байт записано)`);
    });

    archive.on('error', (err) => {
        throw err;
    });

    archive.pipe(output);

    // Добавляем файл в архив
    archive.file(file, { name: file.split('/').pop() });

    // Завершаем архивирование
    archive.finalize();
}

// Разархивирование файлов
function extractArchive(zipFilename, outputDir) {
    try {
        const zip = new unzipper(zipFilename);
        zip.extractAllTo(outputDir, true);
        console.log(`Архив ${zipFilename} разархивирован в: ${outputDir}`);
    } catch (err) {
        console.error('Ошибка при разархивировании:', err);
    }
}

// Вывод коллекции
function printCollection(data) {
  console.log("Текущая коллекция:");
  console.log(data);
}

// Пример использования
const binaryFile = 'semester_6/lab8/collection.bin';
const textFile = 'semester_6/lab8/collection.txt';
const serializedFile = 'semester_6/lab8/collection.json';
const zipFile = 'semester_6/lab8/archive.zip';
const extractedFile = 'semester_6/lab8/extracted_collection.txt';

saveToBinaryFile(binaryFile, collection);
let loadedBinaryCollection = loadFromBinaryFile(binaryFile);
printCollection(loadedBinaryCollection);

saveToTextFile(textFile, collection);
let loadedTextCollection = loadFromTextFile(textFile);
printCollection(loadedTextCollection);

serializeCollection(serializedFile, collection);
let deserializedCollection = deserializeCollection(serializedFile);
printCollection(deserializedCollection);

archiveFiles(zipFile, textFile);
extractArchive(zipFile, extractedFile);