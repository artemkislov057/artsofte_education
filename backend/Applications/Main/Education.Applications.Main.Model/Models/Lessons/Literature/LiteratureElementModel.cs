namespace Education.Applications.Main.Model.Models.Lessons.Literature;

public class LiteratureElementModel : IDisplayValue
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string CoverSrc { get; set; }
    public string[] PurchaseLinks { get; set; }

    public string GetDisplaySting()
    {
        return Name;
    }
}