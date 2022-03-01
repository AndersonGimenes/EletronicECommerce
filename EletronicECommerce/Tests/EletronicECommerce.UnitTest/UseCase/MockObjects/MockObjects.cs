using System;
using System.Collections.Generic;
using EletronicECommerce.Domain.DTOs;
using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.Domain.Entities.Enums;
using EletronicECommerce.Domain.Entities.Shared;
using EletronicECommerce.Domain.Entities.Store;
using EletronicECommerce.Domain.Entities.ValeuObjects;
using EletronicECommerce.Domain.Extensions;

namespace EletronicECommerce.UnitTest.UseCase.MockObjects
{
    internal static class MockObjects
    {
        internal static Category NewCategoryInstance(string name)
        {
            var category = new Category();

            category.SetValuesProperties(
                new Dictionary<string, dynamic>{
                    {nameof(Category.Name), name}
                }
            );

            return category;
        }

        internal static Customer NewCustomerInstance(string document, Guid user)
        {
            var customer = new Customer();

            customer.SetValuesProperties(
                new Dictionary<string, dynamic>{
                    {nameof(Customer.FullName), NewNameInstance()},
                    {nameof(Customer.Document), NewDocumentInstance(document)},
                    {nameof(Customer.Addresses), NewAddressesInstance()},
                    {nameof(Customer.UserIdentifier), user}
                }
            );

            return customer;
        }

        internal static Name NewNameInstance()
        {
            var name = new Name();

            name.SetValuesProperties(
                new Dictionary<string, dynamic>{
                    {nameof(Name.FirstName), "Robert"},
                    {nameof(Name.Surname), "DelValle"}
                }
            );

            return name;
        }

        internal static Document NewDocumentInstance(string documentNumber)
        {
            var document = new Document();

            document.SetValuesProperties(
                new Dictionary<string, dynamic>{
                    {nameof(Document.Number), documentNumber},
                    {nameof(Document.DocumentType), DocumentType.CPF}
                }
            );

            return document;
        }

        internal static List<Address> NewAddressesInstance()
        {
            var address = new Address();

            address.SetValuesProperties(
                new Dictionary<string, dynamic>{
                    {nameof(Address.Street), "Jhon boyd dunlop street"},
                    {nameof(Address.Number), "123"},
                    {nameof(Address.Neighborhood), "New Life"},
                    {nameof(Address.City), "Campinas"},
                    {nameof(Address.State), "SP"},
                    {nameof(Address.Country), "Brazil"},
                    {nameof(Address.AddressType), Enum.Parse(typeof(AddressType), "BillingAddress")}
                }
            );

            return new List<Address> { address };
        }

        internal static User NewUserInstance(string email, string password)
        {
            var user = new User();

            user.SetValuesProperties(
                new Dictionary<string, dynamic>{
                    {nameof(User.Email), email},
                    {nameof(User.Password), password},
                    {nameof(User.Role), RoleType.CommonUser}
                }
            );

            return user;
        }

        internal static Payment NewPaymentInstance()
        {
            var payment = new Payment();

            payment.SetValuesProperties
            (
                new Dictionary<string, dynamic>
                {
                    {nameof(Payment.MerchantOrderId), "bbc7a54a-bd0d-4383-b5ce-16ef73fe5786"},
                    {nameof(Payment.CardNumber), "1234123412341231"},
                    {nameof(Payment.Holder), "Nome Do Cartao"},
                    {nameof(Payment.ExpirationDate), "12/2030"},
                    {nameof(Payment.SecurityCode), "123"},
                    {nameof(Payment.Brand), "Visa"},
                    {nameof(Payment.Amount), 15700},
                    {nameof(Payment.Installments), 1},
                    {nameof(Payment.CustomerId), Guid.Parse("e8a01408-1981-4d48-9d2f-b378ae709489")},
                }
            );

            return payment;
        }

        internal static Product NewProductInstance(List<Stock> stocks, decimal salePrice)
        {
            var product = new Product();

            product.SetValuesProperties
            (
                new Dictionary<string, dynamic>
                {
                    {nameof(Product.Name), "Playstation 5"},
                    {nameof(Product.Code), "PS5"},
                    {nameof(Product.SalePrice), salePrice},
                    {nameof(Product.Stocks), stocks},
                    {nameof(Product.CategoryIdentifier), Guid.NewGuid()}
                }
            );

            return product;
        }

        internal static Stock NewStokObject(decimal purchasePrice, int quantity)
        {
            var stock = new Stock();

            stock.SetValuesProperties
            (
                new Dictionary<string, dynamic>
                {
                    {nameof(Stock.PurchasePrice), purchasePrice},
                    {nameof(Stock.Quantity), quantity}
                }
            );

            return stock;
        }

        internal static List<Stock> NewStoksInstance(decimal purchasePrice, int quantity)
        {
            var stock = new Stock();

            stock.SetValuesProperties
            (
                new Dictionary<string, dynamic>
                {
                    {nameof(Stock.PurchasePrice), purchasePrice},
                    {nameof(Stock.Quantity), quantity}
                }
            );

            return new List<Stock> { stock };
        }

        internal static Order NewOrderInstance(params Guid[] productIds)
        {
            var order = new Order();

            order.SetValuesProperties
            (
                new Dictionary<string, dynamic>
                {
                    {nameof(order.Products), productIds},
                    {nameof(order.StatusOrder), StatusOrder.Selected},
                    {nameof(order.TypePayment), TypePayment.CreditCard}
                }
            );

            return order;
        }
    }
}