using DATA;
using MAIN.Dtos.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test.Utils;

namespace Test.Infras
{
    public abstract class HttpFactoryBase<TEntity, TDto>
        where TEntity : class, new()
        where TDto : class, new()
    {
        public abstract string CreateUri { get; }

        protected HttpClient HttpClient { get; set; }
        protected Repository<TEntity> Repository { get; set; }

        public HttpFactoryBase(HttpClient httpClient, Repository<TEntity> repository)
        {
            HttpClient = httpClient;
            Repository = repository;
        }

        private object GetId(object entity)
        {
            var idProperty = entity.GetType().GetProperty("Id");
            return idProperty == null
                ? throw new Exception("Entity does not have Id property")
                : idProperty.GetValue(entity);
        }


        public abstract TDto FakeDto();

        public virtual async Task<TEntity> Create(TDto entity = null)
        {
            var fakeObject = FakeDto();
            if (entity != null)
            {
                ObjectUtils.CopyValues(entity, fakeObject);
            }

            var response = await HttpClient.PostAsJsonAsync(CreateUri, fakeObject);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsAsync<ActionResultDto<TEntity>>();

            var id = GetId(responseData.Data);
            return await Repository.FindAsync(id);
        }

        public virtual async Task<TEntity> Update(long? id, TDto entity = null)
        {
            var fakeObject = FakeDto();
            if (entity != null)
            {
                ObjectUtils.CopyValues(entity, fakeObject);
            }

            string path = id != null ? $"{CreateUri}/{id}" : CreateUri;

            var response = await HttpClient.PutAsJsonAsync(path, fakeObject);
            response.EnsureSuccessStatusCode();
           
            return await Repository.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> CreateMany(int count, TDto baseDto = null)
        {
            var list = new List<TEntity>();
            for (int i = 0; i < count; i++)
            {
                list.Add(await Create(baseDto));
            }

            return list;
        }

        public virtual IQueryable<TEntity> FindInDatabase(Expression<Func<TEntity, bool>> expression)
        {
            return Repository.GetAll().Where(expression);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return Repository.GetAll();
        }
    }
}
