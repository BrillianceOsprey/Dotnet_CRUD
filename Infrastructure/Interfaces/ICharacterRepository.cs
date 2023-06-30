using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet_CRUD.Domain.DBContexts;
using Dotnet_CRUD.Shared.Dtos;

namespace Dotnet_CRUD.Infrastructure.Interfaces
{
    public interface ICharacterRepository
    {
        Task<ResCodeMessage> getAllCharacterList();
        Task<ResCodeMessage> addCharacter(AddCharacterDto character);
        Task<ResCodeMessage> updateCharacter(UpdateCharacterDto character);
        Task<ResCodeMessage> deleteCharacter(string characterID);
    }
}