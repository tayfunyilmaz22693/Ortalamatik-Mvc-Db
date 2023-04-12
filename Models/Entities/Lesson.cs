using System;
using System.Collections.Generic;

namespace Ortalama.Models.Entities;

public partial class Lesson
{
    internal List<Lesson> allLessons;

    public uint Id { get; set; }

    public string? LessonName { get; set; }

    public int LessonCredit { get; set; }

    public string LessonNote { get; set; } = null!;
}
