global using NUnit.Framework;
using APIServer.Models.Entity;

var listCompany = new List<Company>();
for (int i = 1; i <= 3; i++)
{
    listCompany.Add(new Company()
    {
        CompanyId = i,
        CompanyName = $"Company name {i}",
        Email = $"company{i}.work@gmail.com",
        Phone = $"091283463{i}",
        Address = $"Ha noi",
        Description = $"Desc {i}",
        Tax = $"9874236{i}0358",
        YearOfEstablishment = 2021,
        WebURL = $"http://abc{i}.com.vn",
        IsDelete = false,
        RecuirterId = 1,
    });
}