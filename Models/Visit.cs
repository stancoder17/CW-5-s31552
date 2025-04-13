namespace APBD05.Models;

public class Visit
{
    public DateTime Date { get; set; }
    public Animal Animal { get; set; }
    public String? Description { get; set; }
    public double Price { get; set; }
}