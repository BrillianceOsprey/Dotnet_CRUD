using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet_CRUD.Domain.DBContexts;
using Dotnet_CRUD.Domain.Repository.Interfaces;
using Dotnet_CRUD.Infrastructure.Interfaces;
using Dotnet_CRUD.Shared.Dtos;
using Dotnet_CRUD.Shared.Extension;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_CRUD.Infrastructure
{
    public class CharactersRepository : ICharacterRepository
    {
        public IDBUnitOfWork _DBUnitOfWork;
        public dotnet_DBContext _DBContext;

        public CharactersRepository(IDBUnitOfWork dBUnitOfWork)
        {
            _DBUnitOfWork = dBUnitOfWork;
            _DBContext = dBUnitOfWork.DBContext;
        }

        public async Task<ResCodeMessage> getAllCharacterList()
        {
            List<Character> the_list = await _DBContext.Characters.ToListAsync();

            Mapper _mapper = MapperExtension.GetMapper<Character, CharacterDTO>();
            List<CharacterDTO> character = _mapper.Map<List<CharacterDTO>>(the_list);

            var res = new ResCodeMessage()
            {
                v_data = character,
            };
            return res;
        }


        public async Task<ResCodeMessage> addCharacter(AddCharacterDto character)
        {
            Mapper _mapper = MapperExtension.GetMapper<AddCharacterDto, Character>();
            Character character_data = _mapper.Map<Character>(character);
            character_data.Id = Guid.NewGuid().ToString();
            _DBContext.Characters.Add(character_data);
            _DBUnitOfWork.Commit();

            _mapper = MapperExtension.GetMapper<Character, CharacterDTO>();
            CharacterDTO return_character = _mapper.Map<CharacterDTO>(character_data);
            var res = new ResCodeMessage()
            {
                v_data = return_character,
            };
            return res;
        }

        public async Task<ResCodeMessage> updateCharacter(UpdateCharacterDto character)
        {
            try
            {
                var res = new ResCodeMessage();

                Mapper _mapper = MapperExtension.GetMapper<UpdateCharacterDto, Character>();
                Character check_character_data = _mapper.Map<Character>(character);

                // Character character_data = _DBContext.Characters.Where(x=>x.Id==check_character_data.Id).FirstOrDefault();
                Character? character_data = await _DBContext.Characters.FirstOrDefaultAsync(c => c.Id == check_character_data.Id);
                // if (character_data == null) throw new Exception("Character is not found.");
                if (character_data == null)
                {
                    res = new ResCodeMessage()
                    {
                        v_rescode = "003",
                        v_resmessage = "Character is not found."
                    };

                }
                else
                {

                    character_data.Name = character.Name;
                    character_data.Class = check_character_data.Class;

                    _DBContext.Characters.Update(character_data);
                    _DBUnitOfWork.Commit();

                    _mapper = MapperExtension.GetMapper<Character, CharacterDTO>();
                    CharacterDTO return_character = _mapper.Map<CharacterDTO>(character_data);
                    res = new ResCodeMessage()
                    {
                        v_data = return_character,
                    };

                }

                return res;

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public async Task<ResCodeMessage> deleteCharacter(string characterID)
        {
            try
            {
                var res = new ResCodeMessage();


                Character? character_data = await _DBContext.Characters.FirstOrDefaultAsync(c => c.Id == characterID);
                if (character_data == null)
                {
                    res = new ResCodeMessage()
                    {
                        v_rescode = "003",
                        v_resmessage = "Character is not found."
                    };

                }
                else
                {

                    _DBContext.Characters.Remove(character_data);
                    _DBUnitOfWork.Commit();

                }

                return res;

            }
            catch (Exception e)
            {
                throw e;
            }
        }



    }
}