using eTrade.Business.Abstract.ReadServices;
using eTrade.Business.Abstract.Services;
using eTrade.Business.Abstract.Services.Authentication;
using eTrade.Business.Abstract.WriteServices;
using eTrade.Business.Concrete.ReadManager;
using eTrade.Business.Concrete.ServiceManager;
using eTrade.Business.Concrete.WriteManager;
using eTrade.Business.CrossCuttingConcern.Validators.ProductValidator;
using eTrade.DataAccess.Concrete.EntityFramework.Context.PostgreSQL;
using eTrade.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using eTrade.Business.CrossCuttingConcern.Validators.CustomerValidator;
using eTrade.Core.CrossCuttingConcern.ViewModels.CustomerVMs;
using eTrade.Core.CrossCuttingConcern.ViewModels.OrderVMs;
using eTrade.Core.CrossCuttingConcern.ViewModels.ProductVMs;
using eTrade.Business.CrossCuttingConcern.Validators.OrderValidator;
using eTrade.Business.CrossCuttingConcern.Jwt.Token;
using Microsoft.AspNetCore.Identity;

namespace eTrade.Business.DependencyResolver.DependencyInjection.ServiceDependency
{
    public static class ServiceInjection
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql("User ID=etraderoot@etardedatabase;Password=password;Host=etradedatabase.postgres.database.azure.com;Port=5432;Database=postgres;"));

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddScoped<IBasketReadService, BasketReadManager>();
            services.AddScoped<IBasketWriteService, BasketWriteManager>();
            services.AddScoped<IBasketItemReadService, BasketItemReadManager>();
            services.AddScoped<IBasketItemWriteService, BasketItemWriteManager>();
            services.AddScoped<ICompletedOrderReadService, CompletedOrderReadManager>();
            services.AddScoped<ICompletedOrderWriteService, CompletedOrderWriteManager>();
            services.AddScoped<ICompletedOrderReadService, CompletedOrderReadManager>();
            services.AddScoped<ICompletedOrderWriteService, CompletedOrderWriteManager>();
            services.AddScoped<ICustomerReadService, CustomerReadManager>();
            services.AddScoped<ICustomerWriteService, CustomerWriteManager>();
            services.AddScoped<IEndpointReadService, EndpointReadManager>();
            services.AddScoped<IEndpointWriteService, EndpointWriteManager>();
            services.AddScoped<IFileReadService, FileReadManager>();
            services.AddScoped<IFileWriteService, FileWriteManager>();
            services.AddScoped<IInvoiceReadService, InvoiceReadManager>();
            services.AddScoped<IInvoiceWriteService, InvoiceWriteManager>();
            services.AddScoped<IMenuReadService, MenuReadManager>();
            services.AddScoped<IMenuWriteService, MenuWriteManager>();
            services.AddScoped<IOrderReadService, OrderReadManager>();
            services.AddScoped<IOrderWriteService, OrderWriteManager>();
            services.AddScoped<IProductReadService, ProductReadManager>();
            services.AddScoped<IProductWriteService, ProductWriteManager>();
            services.AddScoped<IProductImageReadService, ProductImageReadManager>();
            services.AddScoped<IProductImageWriteService, ProductImageWriteManager>();

            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IInternalAuthService, AuthManager>();
            services.AddScoped<IExternalAuthService, AuthManager>();
            services.AddScoped<IAuthEndpointService, AuthEndpointManager>();
            services.AddScoped<IApplicationService, ApplicationManager>();
            services.AddScoped<IBasketService, BasketManager>();
            services.AddScoped<IMailService, MailManager>();
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IQRCodeService, QRCodeManager>();
            services.AddScoped<IRoleService, RoleManager>();
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<IUserService, UserManager>();

            services.AddScoped<IValidator<CustomerCreateVM>, CreateCustomerValidator>();
            services.AddScoped<IValidator<CustomerUpdateVM>, UpdateCustomerValidator>();
            services.AddScoped<IValidator<OrderCreateVM>, CreateOrderValidator>();
            services.AddScoped<IValidator<OrderUpdateVM>, UpdateOrderValidator>();
            services.AddScoped<IValidator<ProductCreateVM>, CreateProductValidator>();
            services.AddScoped<IValidator<ProductUpdateVM>, UpdateProductValidator>();
        }
    }
}
