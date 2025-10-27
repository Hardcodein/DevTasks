namespace DirectoryService.Contracts.Locations.Requests;

public record CreateLocationRequest(string Name, AddressDTO Address, string TimeZone);
