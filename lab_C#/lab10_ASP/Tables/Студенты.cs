using System;
using System.Collections.Generic;

namespace lab10_ASP.Tables;

public partial class Студенты
{
    public int КодСтудента { get; set; }

    public string Фамилия { get; set; } = null!;

    public string Имя { get; set; } = null!;

    public string? Отчество { get; set; }

    public int Кафедра { get; set; }

    public int ГодРождения { get; set; }

    public string Пол { get; set; } = null!;

    public string? Адрес { get; set; }

    public string Город { get; set; } = null!;

    public string Телефон { get; set; } = null!;

    public virtual ICollection<Ведомости> Ведомостиs { get; set; } = new List<Ведомости>();

    public virtual Кафедры КафедраNavigation { get; set; } = null!;
}
