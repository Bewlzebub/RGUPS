using System;
using System.Collections.Generic;

namespace lab10_ASP.Tables;

public partial class Ведомости
{
    public int КодЗаписи { get; set; }

    public int Преподаватель { get; set; }

    public int Дисциплина { get; set; }

    public int Студент { get; set; }

    public int Оценка { get; set; }

    public DateOnly ДатаСдачи { get; set; }

    public virtual Дисциплины ДисциплинаNavigation { get; set; } = null!;

    public virtual Преподаватели ПреподавательNavigation { get; set; } = null!;

    public virtual Студенты СтудентNavigation { get; set; } = null!;
}
