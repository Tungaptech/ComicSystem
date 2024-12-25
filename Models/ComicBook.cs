namespace Comic.Models;
public class ComicBook
{
    public int ComicBookId { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public decimal PricePerDay { get; set; }
    public int Quantity { get; set; }
}
