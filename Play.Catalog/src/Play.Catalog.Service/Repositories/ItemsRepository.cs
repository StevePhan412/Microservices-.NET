using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Play.Catalog.Service.Entities;

namespace Play.Catalog.Service.Repositories;

public class ItemsRepository : IItemsRepository
{
    private const string collectionName = "items";

    private readonly IMongoCollection<Item> dbCollection;

    private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;

    public ItemsRepository(IMongoDatabase db)
    {
        //Get all items in that DB
        dbCollection = db.GetCollection<Item>(collectionName);
    }

    public async Task<IReadOnlyCollection<Item>> GetAllAsync()
    {
        return await dbCollection.Find(filterBuilder.Empty).ToListAsync();
    }

    public async Task<Item> GetAsync(Guid id)
    {
        FilterDefinition<Item> filter = filterBuilder.Eq(item => item.Id, id);
        return await dbCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(Item item)
    {
        if (item == null)
        {
            throw new ArgumentException(nameof(item));
        }

        await dbCollection.InsertOneAsync(item);
    }

    public async Task UpdateAsync(Item item)
    {
        if (item == null)
        {
            throw new ArgumentException(nameof(item));
        }

        FilterDefinition<Item> filter = filterBuilder.Eq(existingEntity => existingEntity.Id, item.Id);
        await dbCollection.ReplaceOneAsync(filter, item);
    }

    public async Task RemoveAsync(Guid id)
    {
        FilterDefinition<Item> filter = filterBuilder.Eq(existingEntity => existingEntity.Id, id);
        await dbCollection.DeleteOneAsync(filter);
    }
}