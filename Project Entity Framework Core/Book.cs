using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Entity_Framework_Core;

public class Book
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public int Publication { get; set; }
    public string Genre { get; set; } = "не указан";

    public int? UserId { get; set; }
    public User User { get; set; }
}
