﻿namespace BeerApp.Services.Data
{
    using System.Linq;
    using BeerApp.Data.Models;

    public interface IBeersService
    {
        IQueryable<Beer> GetAll();

        Beer GetById(string id);

        int Add(Beer beer);

        void Update(Beer beer);

        void Delete(Beer beer);

        void Dispose();
    }
}
