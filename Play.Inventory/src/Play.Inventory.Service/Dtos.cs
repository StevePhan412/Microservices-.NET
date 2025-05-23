using System;

namespace Play.Inventory.Service
{
    public record GrantItemsDto(Guid UserId, Guid CatalogItemId, int Quantity);
    public record InventoryItemDto(Guid CatalogItemId, string Name,  string Description, int Quantity, DateTimeOffset AccquiredDate);
    public record CatalogItemDto(Guid Id, string Name, string Description);
}

