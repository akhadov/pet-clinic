using AutoMapper;
using PetShop.Data.Contexts;
using PetShop.Data.IRepositories;
using PetShop.Data.Repositories;
using PetShop.Domain.Entities;
using PetShop.Service.DTOs;
using PetShop.Service.Interfaces;
using PetShop.Service.Mappers;
using PetShop.Service.Services;

namespace PetShop.Test
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            AppDbContext dbContext = new AppDbContext();

            IUnitOfWork unitOfWork = new UnitOfWork(dbContext);

            IMapper mapper = new MapperConfiguration(p =>
            {
                p.AddProfile<MappingProfile>();
            }).CreateMapper();

            #region  create
            //CustomerForCreationDto dto = new CustomerForCreationDto()
            //{
            //    Name = "Pozxvy",
            //    Address = "asd",
            //    Phone = "122sdfzs4",
            //    Gender = Domain.Enums.Gender.Male,
            //};
            //Customer dto1 = new Customer()
            //{
            //    Name = "Johzxvn",
            //    Address = "azxvcsd",
            //    Phone = "12234546574",
            //    Gender = Domain.Enums.Gender.Female,
            //};

            ICustomerService customerService = new CustomerService();
            //ICustomerRepository customerRepository = new CustomerRepository(dbContext);

            //await customerRepository.CreateAsync(dto1);

            //await customerService.CreateAsync(dto);
            // var r = customerService.GetAsync(p => p.Phone == dto.Phone);

            //await customerService.GetAllAsync();
            //Console.WriteLine(r);
            #endregion

            #region update
            //await customerService.UpdateAsync(2, new CustomerForCreationDto()
            //{
            //    Name = "NewName",
            //    Gender = Domain.Enums.Gender.Male,
            //    Address = "NewAddress",
            //    Phone = "+998121231212"
            //});
            #endregion

            #region get all
            //var customers = await customerService.GetAllAsync(p => p.Id > 1);

            //foreach (var customer in customers)
            //{
            //    Console.WriteLine($"{customer.Name} {customer.Id}");
            //}
            #endregion

            var cus = await customerService.GetAsync(p => p.Id == 2);
            Console.WriteLine(cus.Name);
            //await customerService.DeleteAsync(p => p.Id == 1);
        }


    }
}
