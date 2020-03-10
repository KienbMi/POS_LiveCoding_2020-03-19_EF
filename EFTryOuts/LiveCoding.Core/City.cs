namespace LiveCoding.Core
{
  public class City
  {
    public int Id { get; set; }
    public int PostalCode { get; set; }
    public string Name { get; set; }

    public City(int postalCode, string name)
    {
      PostalCode = postalCode;
      Name = name;
    }
  }
}
