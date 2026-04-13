using System;
using System.Collections.Generic;

namespace lab10.Tables;

public partial class Преподаватели
{
    public int КодПреподавателя { get; set; }

    public string Фамилия { get; set; } = null!;

    public string Имя { get; set; } = null!;

    public string? Отчество { get; set; }

    public int Кафедра { get; set; }

    public int ГодРождения { get; set; }

    public int ГодПоступления { get; set; }

    public int Стаж { get; set; }

    public string Должность { get; set; } = null!;

    public string Пол { get; set; } = null!;

    public string? Адрес { get; set; }

    public string Город { get; set; } = null!;

    public string Телефон { get; set; } = null!;

    public virtual ICollection<Ведомости> Ведомостиs { get; set; } = new List<Ведомости>();

    public virtual ICollection<Дисциплины> Дисциплиныs { get; set; } = new List<Дисциплины>();

    public virtual Кафедры КафедраNavigation { get; set; } = null!;
}
