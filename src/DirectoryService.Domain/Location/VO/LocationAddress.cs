namespace DevTasks.Domain.Location.VO;

public record LocationAddress
{
    private LocationAddress(
        string mailIndex, 
        string city,
        string district, 
        string street,
        string numberofHouse)
    {
        MailIndex = mailIndex;
        City = city;
        District = district;
        Street = street;
        NumberofHouse = numberofHouse;
    }
    public string MailIndex { get; }
    public string City { get; }
    public string District { get; }
    public string Street { get; }
    public string NumberofHouse { get; }

    public static Result<LocationAddress> Create(
        string mailIndex, 
        string city, 
        string district, 
        string street,
        string numberofHouse)
    {
        if(string.IsNullOrWhiteSpace(mailIndex)
           || string.IsNullOrWhiteSpace(city) 
           || string.IsNullOrWhiteSpace(district) 
           || string.IsNullOrWhiteSpace(street) 
           || string.IsNullOrWhiteSpace(numberofHouse))
           return Result.Failure<LocationAddress>("Invalid address information.");
        
        var locationAddress =  new LocationAddress(mailIndex, city, district, street, numberofHouse);
        
        return Result.Success(locationAddress);
    }
}