using PhoenixBussiness.Interfaces;
using PhoenixDataAccess.Models;
using PhoenixWeb.ViewModels;
using PhoenixWeb.ViewModels.Guest;

namespace PhoenixWeb.Services;

public class GuestService
{
    private readonly IGuestRepository _repository;

    public GuestService(IGuestRepository repository)
    {
        _repository = repository;
    }

    public void Insert(RegisterVM viewModel)
    {
        var model = new Guest()
        {
            Username = viewModel.Username,
            Password = BCrypt.Net.BCrypt.HashPassword(viewModel.Password),
            FirstName = viewModel.FirstName,
            MiddleName = viewModel.MiddleName,
            LastName = viewModel.LastName,
            BirthDate = viewModel.BirthDate,
            Gender = viewModel.Gender,
            Citizenship = viewModel.Citizenship,
            IdNumber = viewModel.IdNumber
        };
        _repository.Insert(model);
    } 
}
