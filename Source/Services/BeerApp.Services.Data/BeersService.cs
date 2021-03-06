﻿namespace BeerApp.Services.Data
{
    using System.Linq;
    using BeerApp.Data.Common.Repositories.Contracts;
    using BeerApp.Data.Models;
    using Web;

    public class BeersService : IBeersService
    {
        private readonly IDbRepository<Beer> beers;
        private readonly IIdentifierProvider identifierProvider;
        private readonly IDeletableEntityRepository<Beer> deleteableRepo;

        public BeersService(IDbRepository<Beer> beers, IIdentifierProvider identifierProvider, IDeletableEntityRepository<Beer> deleteableRepo)
        {
            this.beers = beers;
            this.identifierProvider = identifierProvider;
            this.deleteableRepo = deleteableRepo;
        }

        public int Add(Beer beer)
        {
            this.beers.Add(beer);
            this.beers.Save();
            return beer.Id;
        }

        public IQueryable<Beer> GetAll()
        {
            return this.beers.All();
        }

        public Beer GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var beer = this.beers.GetById(intId);

            return beer;
        }

        public Beer GetByIntId(int id)
        {
            var beer = this.beers.GetById(id);

            return beer;
        }

        public int AdminCreate(Beer entity)
        {
            this.deleteableRepo.Add(entity);
            this.deleteableRepo.SaveChanges();
            return entity.Id;
        }

        public int AdminUpdate(Beer entity)
        {
            this.deleteableRepo.Update(entity);
            this.deleteableRepo.SaveChanges();
            return entity.Id;
        }

        public void AdminDestroy(int id)
        {
            this.deleteableRepo.Delete(id);
            this.deleteableRepo.SaveChanges();
        }

        public void AdminDispose()
        {
            this.deleteableRepo.Dispose();
        }
    }
}
