using System;
using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace Play.Identity.Service.Entities
{
    [CollectionName("Users")]
    public class ApplicationRole : MongoIdentityRole<Guid>
    {
    }
}