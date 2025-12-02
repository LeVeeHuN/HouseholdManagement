using HHMBApp.Application.DTOs.Expense;
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
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly ICategoryService _categoryService;

        public ExpenseService(IExpenseRepository expenseRepository, ICategoryService categoryService)
        {
            _expenseRepository = expenseRepository;
            _categoryService = categoryService;
        }

        public async Task<CreateExpenseResponseDto> CreateExpense(CreateExpenseDto request)
        {
            // Check if category exists for household
            var categories = await _categoryService.GetCategories(request.HouseholdId);
            Category? category = categories.FirstOrDefault(c => c.Id == request.CategoryId);

            if (category == null)
            {
                return new CreateExpenseResponseDto
                {
                    Id = Guid.Empty,
                    Response = CreateExpenseResponseStatus.CreateExpenseError,
                    Title = request.Title,
                    Description = request.Description,
                    CategoryId = request.CategoryId,
                    UserId = request.UserId,
                    HouseholdId = request.HouseholdId,
                    ReceiptBase64 = request.ReceiptBase64,
                    Date = request.Date,
                    Amount = request.Amount
                };
            }

            // Create the expense to add
            Expense newExpense = new Expense
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                HouseholdId = request.HouseholdId,
                Amount = request.Amount,
                Date = request.Date,
                CategoryId = request.CategoryId,
                Title = request.Title,
                Description = request.Description,
                ReceiptBase64 = request.ReceiptBase64
            };

            Expense? addedExpense = await _expenseRepository.Create(newExpense);

            if (addedExpense == null)
            {
                return new CreateExpenseResponseDto
                {
                    Id = Guid.Empty,
                    Response = CreateExpenseResponseStatus.CreateExpenseError,
                    Title = request.Title,
                    Description = request.Description,
                    CategoryId = request.CategoryId,
                    UserId = request.UserId,
                    HouseholdId = request.HouseholdId,
                    ReceiptBase64 = request.ReceiptBase64,
                    Date = request.Date,
                    Amount = request.Amount
                };
            }

            return new CreateExpenseResponseDto
            {
                Id = addedExpense.Id,
                Response = CreateExpenseResponseStatus.OK,
                Title = addedExpense.Title,
                Description = addedExpense.Description,
                CategoryId = addedExpense.CategoryId,
                UserId = addedExpense.UserId,
                HouseholdId = addedExpense.HouseholdId,
                ReceiptBase64 = addedExpense.ReceiptBase64,
                Date = addedExpense.Date,
                Amount = addedExpense.Amount
            };
        }

        public async Task<DeleteExpenseResponseDto> DeleteExpense(Guid id, Guid householdId)
        {
            // Check if expense belongs to given household
            Expense? expense = await _expenseRepository.Read(id);

            if (expense == null || expense.HouseholdId != householdId)
            {
                return new DeleteExpenseResponseDto
                {
                    Id = id,
                    Response = DeleteExpenseResponseStatus.DeleteExpenseError
                };
            }

            Expense? deletedExpense = await _expenseRepository.Delete(id);
            if (deletedExpense == null)
            {
                return new DeleteExpenseResponseDto
                {
                    Id = id,
                    Response = DeleteExpenseResponseStatus.DeleteExpenseError
                };
            }

            return new DeleteExpenseResponseDto
            {
                Id = id,
                Response = DeleteExpenseResponseStatus.OK
            };
        }

        public async Task<IEnumerable<Expense>> ReadExpenses(Guid householdId)
        {
            var expenses = await _expenseRepository.ReadAll();
            return expenses.Where(e => e.HouseholdId == householdId);
        }

        public async Task<CreateExpenseResponseDto> UpdateExpense(UpdateExpenseDto request)
        {
            // Check if expense exists and belongs to given household
            Expense? existingExpense = await _expenseRepository.Read(request.Id);
            if (existingExpense == null || existingExpense.HouseholdId != request.HouseholdId)
            {
                return new CreateExpenseResponseDto
                {
                    Id = Guid.Empty,
                    Response = CreateExpenseResponseStatus.UpdateExpenseError,
                    Title = request.Title,
                    Description = request.Description,
                    CategoryId = request.CategoryId,
                    UserId = request.UserId,
                    HouseholdId = request.HouseholdId,
                    ReceiptBase64 = request.ReceiptBase64,
                    Date = request.Date,
                    Amount = request.Amount
                };
            }

            // Update the expense
            Expense expenseToUpdate = new Expense
            {
                Id = request.Id,
                UserId = request.UserId,
                HouseholdId = request.HouseholdId,
                Amount = request.Amount,
                Date = request.Date,
                CategoryId = request.CategoryId,
                Title = request.Title,
                Description = request.Description,
                ReceiptBase64 = request.ReceiptBase64
            };

            Expense? updatedExpense = await _expenseRepository.Update(expenseToUpdate);

            if (updatedExpense == null)
            {
                return new CreateExpenseResponseDto
                {
                    Id = Guid.Empty,
                    Response = CreateExpenseResponseStatus.UpdateExpenseError,
                    Title = request.Title,
                    Description = request.Description,
                    CategoryId = request.CategoryId,
                    UserId = request.UserId,
                    HouseholdId = request.HouseholdId,
                    ReceiptBase64 = request.ReceiptBase64,
                    Date = request.Date,
                    Amount = request.Amount
                };
            }

            return new CreateExpenseResponseDto
            {
                Id = updatedExpense.Id,
                Response = CreateExpenseResponseStatus.OK,
                Title = updatedExpense.Title,
                Description = updatedExpense.Description,
                CategoryId = updatedExpense.CategoryId,
                UserId = updatedExpense.UserId,
                HouseholdId = updatedExpense.HouseholdId,
                ReceiptBase64 = updatedExpense.ReceiptBase64,
                Date = updatedExpense.Date,
                Amount = updatedExpense.Amount
            };
        }
    }
}
