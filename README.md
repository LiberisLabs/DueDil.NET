# DueDil.NET

A simple .NET client wrapper for DueDil

[![install from nuget](http://img.shields.io/nuget/v/DueDil.svg?style=flat-square)](https://www.nuget.org/packages/DueDil)
[![downloads](http://img.shields.io/nuget/dt/DueDil.svg?style=flat-square)](https://www.nuget.org/packages/DueDil)
[![Build status](https://ci.appveyor.com/api/projects/status/hi8ncpjqjcrf9mih/branch/master?svg=true)](https://ci.appveyor.com/project/Liberis/duedil-net/branch/master)

## Getting Started

DueDil.NET can be installed via the package manager console by executing the following commandlet

```powershell
PM> Install-Package DueDil
```

After we've installed the DueDil.NET we need to create a `IDueDilClient` object which we will use for all the interactions to DueDil. To get a `IDueDilClient` we need to first create a `DueDilClientFactory` Passing in our settings and calling the method `CreateClient`.

```csharp
var settings = new DueDilSettings("api-key");

var factory = new DueDilClientFactory(settings);

var client = factory.CreateClient();
```

## Usage

### Search Companies

To search for a company we need to start off with creating a `Terms` object with the relevent terms for our company search:

```csharp
var terms = new Terms()
            {
                Name = "L",                     //any search string
                Postcode = "NG1 1AA",           //needs to be full uk postcode, no wildcards
                Domain = "liberis.com",
                Location = "Nottingham"         //accepts the name of a city and/or the address.
            };
```

Once we have some search terms we can then pass them on to the `SearchCompanies` method:

```csharp
var result = await client.SearchCompaniesAsync(terms);
```

We can then loop round each search result:

```csharp
foreach(var item in result.Data.Response.Data)
{
    Console.WriteLine($"{item.Id} {item.Name} {item.Locale}")
}

```

### Get Company

To fetch details on a company we can just call the `GetCompany` method passing in the arguments of `Locale` and `Id`:

```csharp
var result = await client.GetCompanyAsync(Locale.Uk, "bbeaf93e71060b699a7ba9922bc286694c0aa5a3");

Console.WriteLine($"Company: {result.Data.Response.Name}")
```

## Contributing

1. Fork
1. Hack!
1. Pull Request
