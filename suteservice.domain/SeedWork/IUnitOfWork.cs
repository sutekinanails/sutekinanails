using System;

namespace suteservice.domain.SeedWork
{
    /// <summary>
    /// The agragate of class which represents a business task related to the domain is called an "Unit of Work".
    /// Each unit of work is associated with one database context.
    /// </summary>
    /// <remarks>
    /// The unit of work class serves one purpose: to make sure that when you use multiple repositories, 
    /// they share a single database context. That way, when a unit of work is complete you can call the 
    /// SaveChanges method on that instance of the context and be assured that all related changes will be coordinated.
    /// </remarks>
    /// <reference="https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application"/>
    public interface IUnitOfWork : IDisposable
    {
         //SaveEntitiesAsync
    }
}
