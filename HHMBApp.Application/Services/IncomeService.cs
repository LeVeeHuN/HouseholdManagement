using HHMBApp.Application.DTOs.Income;
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
    public class IncomeService : IIncomeService
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly ICategoryService _categoryService;

        public IncomeService(IIncomeRepository incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }

        public async Task<CreateIncomeResponseDto> CreateIncome(CreateIncomeDto request)
        {
            var categoriesForHousehold = await _categoryService.GetCategories(request.HoueseholdId);
            Category? category = categoriesForHousehold.FirstOrDefault(c => c.Id == request.CategoryId);

            if (category == null)
            {
                return new CreateIncomeResponseDto
                {
                    Id = Guid.Empty,
                    HoueseholdId = request.HoueseholdId,
                    UserId = request.UserId,
                    CategoryId = request.CategoryId,
                    Amount = request.Amount,
                    Date = request.Date,
                    Title = request.Title,
                    Description = request.Description,
                    Result = CreateIncomeResultStatus.IncomeCreateError
                };
            }

            Income newIncome = new Income
            {
                Id = Guid.NewGuid(),
                HouseholdId = request.HoueseholdId,
                UserId = request.UserId,
                Category = category,
                Amount = request.Amount,
                Date = request.Date,
                Title = request.Title,
                Description = request.Description
            };

            Income? newIncomeAddResult = await _incomeRepository.Create(newIncome);

            if (newIncomeAddResult == null)
            {
                return new CreateIncomeResponseDto
                {
                    Id = Guid.Empty,
                    HoueseholdId = request.HoueseholdId,
                    UserId = request.UserId,
                    CategoryId = request.CategoryId,
                    Amount = request.Amount,
                    Date = request.Date,
                    Title = request.Title,
                    Description = request.Description,
                    Result = CreateIncomeResultStatus.IncomeCreateError
                };
            }

            return new CreateIncomeResponseDto
            {
                Id = newIncomeAddResult.Id,
                HoueseholdId = newIncomeAddResult.HouseholdId,
                UserId = newIncomeAddResult.UserId,
                CategoryId = newIncomeAddResult.Category.Id,
                Amount = newIncomeAddResult.Amount,
                Date = newIncomeAddResult.Date,
                Title = newIncomeAddResult.Title,
                Description = newIncomeAddResult.Description,
                Result = CreateIncomeResultStatus.Success
            };
        }

        public async Task<DeleteIncomeResponseDto> DeleteIncome(Guid id, Guid householdId)
        {
            Income? incomeToDelete = await _incomeRepository.Read(id);

            if (incomeToDelete == null)
            {
                return new DeleteIncomeResponseDto
                {
                    Id = id,
                    Result = DeleteIncomeResultStatus.IncomeDeleteError
                };
            }

            if (incomeToDelete.HouseholdId != householdId)
            {
                return new DeleteIncomeResponseDto
                {
                    Id = id,
                    Result = DeleteIncomeResultStatus.IncomeDeleteError
                };
            }

            Income? deletedIncome = await _incomeRepository.Delete(id);

            if (deletedIncome == null)
            {
                return new DeleteIncomeResponseDto
                {
                    Id = id,
                    Result = DeleteIncomeResultStatus.IncomeDeleteError
                };
            }

            return new DeleteIncomeResponseDto
            {
                Id = id,
                Result = DeleteIncomeResultStatus.Success
            };
        }

        public async Task<IEnumerable<Income>> ReadIncomes(Guid householdId)
        {
            var incomes = await _incomeRepository.ReadAll();
            return incomes.Where(i => i.HouseholdId == householdId);
        }

        public async Task<CreateIncomeResponseDto> UpdateIncome(UpdateIncomeDto request)
        {
            Income? incomeToUpdate = await _incomeRepository.Read(request.Id);

            if (incomeToUpdate == null || incomeToUpdate.HouseholdId != request.HoueseholdId)
            {
                return new CreateIncomeResponseDto
                {
                    Id = Guid.Empty,
                    HoueseholdId = request.HoueseholdId,
                    UserId = request.UserId,
                    CategoryId = request.CategoryId,
                    Amount = request.Amount,
                    Date = request.Date,
                    Title = request.Title,
                    Description = request.Description,
                    Result = CreateIncomeResultStatus.UpdateIncomeError
                };
            }

            Income? updatedIncome = await _incomeRepository.Update(new Income
            {
                Id = request.Id,
                HouseholdId = request.HoueseholdId,
                UserId = request.UserId,
                Amount = request.Amount,
                Date = request.Date,
                Title = request.Title,
                Description = request.Description,
                Category = incomeToUpdate.Category
            });

            if (updatedIncome == null)
            {
                return new CreateIncomeResponseDto
                {
                    Id = Guid.Empty,
                    HoueseholdId = request.HoueseholdId,
                    UserId = request.UserId,
                    CategoryId = request.CategoryId,
                    Amount = request.Amount,
                    Date = request.Date,
                    Title = request.Title,
                    Description = request.Description,
                    Result = CreateIncomeResultStatus.UpdateIncomeError
                };
            }

            return new CreateIncomeResponseDto
            {
                Id = updatedIncome.Id,
                HoueseholdId = updatedIncome.HouseholdId,
                UserId = updatedIncome.UserId,
                CategoryId = updatedIncome.Category.Id,
                Amount = updatedIncome.Amount,
                Date = updatedIncome.Date,
                Title = updatedIncome.Title,
                Description = updatedIncome.Description,
                Result = CreateIncomeResultStatus.Success
            };
        }
    }
}
