CREATE DATABASE UniversityDB_Dormanchuk
ON PRIMARY
(
    NAME = UniversityDB_Dormanchuk_data,
    FILENAME = 'C:\Users\kosad\Desktop\Лабы 2026 C#\lab_C#\lab1\UniversityDB_Dormanchuk_data.mdf',
    SIZE = 10MB,
    MAXSIZE = 100MB,
    FILEGROWTH = 5MB
)
LOG ON
(
    NAME = UniversityDB_Dormanchuk_log,
    FILENAME = 'C:\Users\kosad\Desktop\Лабы 2026 C#\lab_C#\lab1\UniversityDB_Dormanchuk_log.ldf',
    SIZE = 5MB,
    MAXSIZE = 50MB,
    FILEGROWTH = 1MB
)