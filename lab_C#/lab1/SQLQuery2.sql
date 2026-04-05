-- ============================================
-- Таблица 1: Кафедры
-- ============================================
CREATE TABLE [dbo].[Кафедры] (
    [код_кафедры]        INT IDENTITY(1,1) NOT NULL,
    [название]           VARCHAR(100) NOT NULL,
    [факультет]          VARCHAR(100) NOT NULL,
    [фио_заведующего]    VARCHAR(150) NOT NULL,
    [номер_комнаты]       INT NOT NULL,
    [номер_корпуса]       INT NOT NULL,
    [телефон]            VARCHAR(20) NOT NULL,
    [кол_во_преподавателей] INT NOT NULL DEFAULT 0,
    CONSTRAINT [PK_Кафедры] PRIMARY KEY ([код_кафедры])
);
GO

-- ============================================
-- Таблица 2: Преподаватели
-- ============================================
CREATE TABLE [dbo].[Преподаватели] (
    [код_преподавателя]      INT IDENTITY(1,1) NOT NULL,
    [фамилия]                VARCHAR(50) NOT NULL,
    [имя]                    VARCHAR(50) NOT NULL,
    [отчество]               VARCHAR(50) NULL,
    [кафедра]                INT NOT NULL,  -- ссылка на кафедру
    [год_рождения]           INT NOT NULL,
    [год_поступления]        INT NOT NULL,
    [стаж]                   INT NOT NULL DEFAULT 0,
    [должность]              VARCHAR(100) NOT NULL,
    [пол]                    CHAR(1) NOT NULL CHECK (пол IN ('М', 'Ж')),
    [адрес]                  VARCHAR(200) NULL,
    [город]                  VARCHAR(50) NOT NULL,
    [телефон]                VARCHAR(20) NOT NULL,
    CONSTRAINT [PK_Преподаватели] PRIMARY KEY ([код_преподавателя])
);
GO

-- ============================================
-- Таблица 3: Студенты
-- ============================================
CREATE TABLE [dbo].[Студенты] (
    [код_студента]       INT IDENTITY(1,1) NOT NULL,
    [фамилия]            VARCHAR(50) NOT NULL,
    [имя]                VARCHAR(50) NOT NULL,
    [отчество]           VARCHAR(50) NULL,
    [кафедра]            INT NOT NULL,  -- ссылка на кафедру
    [год_рождения]       INT NOT NULL,
    [пол]                CHAR(1) NOT NULL CHECK (пол IN ('М', 'Ж')),
    [адрес]              VARCHAR(200) NULL,
    [город]              VARCHAR(50) NOT NULL,
    [телефон]            VARCHAR(20) NOT NULL,
    CONSTRAINT [PK_Студенты] PRIMARY KEY ([код_студента])
);
GO

-- ============================================
-- Таблица 4: Дисциплины
-- ============================================
CREATE TABLE [dbo].[Дисциплины] (
    [код_дисциплины]     INT IDENTITY(1,1) NOT NULL,
    [название]           VARCHAR(100) NOT NULL,
    [кафедра]            INT NOT NULL,  -- ссылка на кафедру
    [преподаватель]      INT NOT NULL,  -- кто читает (ссылка на преподавателя)
    [кол_во_часов]       INT NOT NULL,
    [вид_контроля]       VARCHAR(50) NOT NULL CHECK (вид_контроля IN ('Экзамен', 'Зачет', 'Диф. зачет')),
    CONSTRAINT [PK_Дисциплины] PRIMARY KEY ([код_дисциплины])
);
GO

-- ============================================
-- Таблица 5: Ведомости успеваемости
-- ============================================
CREATE TABLE [dbo].[Ведомости] (
    [код_записи]         INT IDENTITY(1,1) NOT NULL,
    [преподаватель]      INT NOT NULL,  -- ссылка на преподавателя
    [дисциплина]         INT NOT NULL,  -- ссылка на дисциплину
    [студент]            INT NOT NULL,  -- ссылка на студента
    [оценка]             INT NOT NULL CHECK (оценка BETWEEN 2 AND 5),
    [дата_сдачи]         DATE NOT NULL DEFAULT GETDATE(),
    CONSTRAINT [PK_Ведомости] PRIMARY KEY ([код_записи])
);
GO