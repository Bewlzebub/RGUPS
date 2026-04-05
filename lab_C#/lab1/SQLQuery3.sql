-- ============================================
-- Связи для таблицы Преподаватели
-- ============================================
ALTER TABLE [dbo].[Преподаватели] 
ADD CONSTRAINT [FK_Преподаватели_Кафедры] 
FOREIGN KEY ([кафедра]) 
REFERENCES [dbo].[Кафедры] ([код_кафедры])
ON UPDATE CASCADE;

-- ============================================
-- Связи для таблицы Студенты
-- ============================================
ALTER TABLE [dbo].[Студенты] 
ADD CONSTRAINT [FK_Студенты_Кафедры] 
FOREIGN KEY ([кафедра]) 
REFERENCES [dbo].[Кафедры] ([код_кафедры])
ON UPDATE CASCADE;

-- ============================================
-- Связи для таблицы Дисциплины
-- ============================================
ALTER TABLE [dbo].[Дисциплины] 
ADD CONSTRAINT [FK_Дисциплины_Кафедры] 
FOREIGN KEY ([кафедра]) 
REFERENCES [dbo].[Кафедры] ([код_кафедры]);

ALTER TABLE [dbo].[Дисциплины] 
ADD CONSTRAINT [FK_Дисциплины_Преподаватели] 
FOREIGN KEY ([преподаватель]) 
REFERENCES [dbo].[Преподаватели] ([код_преподавателя]);

-- ============================================
-- Связи для таблицы Ведомости
-- ============================================
ALTER TABLE [dbo].[Ведомости] 
ADD CONSTRAINT [FK_Ведомости_Преподаватели] 
FOREIGN KEY ([преподаватель]) 
REFERENCES [dbo].[Преподаватели] ([код_преподавателя]);

ALTER TABLE [dbo].[Ведомости] 
ADD CONSTRAINT [FK_Ведомости_Дисциплины] 
FOREIGN KEY ([дисциплина]) 
REFERENCES [dbo].[Дисциплины] ([код_дисциплины]);

ALTER TABLE [dbo].[Ведомости] 
ADD CONSTRAINT [FK_Ведомости_Студенты] 
FOREIGN KEY ([студент]) 
REFERENCES [dbo].[Студенты] ([код_студента]);
GO

-- ============================================
-- Вывод схемы связей (замена визуальной диаграммы)
-- ============================================
SELECT 
    OBJECT_NAME(f.parent_object_id) AS 'Дочерняя таблица',
    COL_NAME(fc.parent_object_id, fc.parent_column_id) AS 'Внешний ключ',
    '→' AS '→',
    OBJECT_NAME(f.referenced_object_id) AS 'Родительская таблица',
    COL_NAME(fc.referenced_object_id, fc.referenced_column_id) AS 'Первичный ключ'
FROM sys.foreign_keys f
JOIN sys.foreign_key_columns fc ON f.object_id = fc.constraint_object_id
ORDER BY OBJECT_NAME(f.parent_object_id);
GO