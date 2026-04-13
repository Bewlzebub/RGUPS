using System;
using System.Collections.Generic;

namespace lab10.Tables;

public partial class Дисциплины
{
    public int КодДисциплины { get; set; }

    public string Название { get; set; } = null!;

    public int Кафедра { get; set; }

    public int Преподаватель { get; set; }

    public int КолВоЧасов { get; set; }

    public string ВидКонтроля { get; set; } = null!;

    public virtual ICollection<Ведомости> Ведомостиs { get; set; } = new List<Ведомости>();

    public virtual Кафедры КафедраNavigation { get; set; } = null!;

    public virtual Преподаватели ПреподавательNavigation { get; set; } = null!;
}
