using HHMBApp.Application.DTOs.Household;
using HHMBApp.Application.Interfaces;
using HHMBApp.Domain.Entities;
using HHMBApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.Services
{
    public class HouseholdService : IHouseholdService
    {
        private readonly IHouseholdRepository _householdRepository;

        public HouseholdService(IHouseholdRepository householdRepository)
        {
            _householdRepository = householdRepository;
        }

        public async Task<UpdateHouseholdResponseDto> ChangeHouseholdName(Guid householdId, string newName)
        {
            // Check if household exists
            var result = await _householdRepository.Read(householdId);

            if (result == null)
            {
                return new UpdateHouseholdResponseDto
                {
                    Response = UpdateHouseholdStatus.UpdateHouseholdError,
                    JoinCode = string.Empty,
                    Name = string.Empty,
                    Id = Guid.Empty
                };
            }

            // It exists, proceed to update it
            result.Name = newName;
            await _householdRepository.Update(result);
            return new UpdateHouseholdResponseDto
            {
                Response = UpdateHouseholdStatus.OK,
                JoinCode = result.JoinCode,
                Name = result.Name,
                Id = result.Id
            };
        }

        public async Task<Household> CreateHousehold(string name)
        {
            Household household = new Household
            {
                Id = Guid.NewGuid(),
                Name = name,
                JoinCode = GenerateJoinCode()
            };
            await _householdRepository.Create(household);
            return household;
        }

        public async Task<Household?> GetHouseholdById(Guid id)
        {
            return await _householdRepository.Read(id);
        }

        private static string GenerateJoinCode()
        {
            // This is just like a neptun code
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string characters = letters + "0123456789";
            string joinCode = letters[Random.Shared.Next(letters.Length)].ToString();
            for (int i = 0; i < 5; i++)
            {
                joinCode += characters[Random.Shared.Next(characters.Length)];
            }
            return joinCode;
        }
    }
}
