using System;
using System.Collections.Generic;

namespace lab10_ASP.Tables;

public partial class Кафедры
{
    public int КодКафедры { get; set; }

    public string Название { get; set; } = null!;

    public string Факультет { get; set; } = null!;

    public string ФиоЗаведующего { get; set; } = null!;

    public int НомерКомнаты { get; set; }

    public int НомерКорпуса { get; set; }

    public string Телефон { get; set; } = null!;

    public int КолВоПреподавателей { get; set; }

    public virtual ICollection<Дисциплины> Дисциплиныs { get; set; } = new List<Дисциплины>();

    public virtual ICollection<Преподаватели> Преподавателиs { get; set; } = new List<Преподаватели>();

    public virtual ICollection<Студенты> Студентыs { get; set; } = new List<Студенты>();
}
