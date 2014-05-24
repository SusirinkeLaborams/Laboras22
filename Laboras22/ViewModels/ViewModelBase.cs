using Laboras22.Classes;
using Laboras22.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels
{
    public abstract class ViewModelBase<ModelType, ViewModelType>
        where ModelType : class, IDataItem, new() 
        where ViewModelType : ViewModelBase<ModelType, ViewModelType>, new()
    {
        private static DataProvider<ModelType> dataProvider;
        private static Dictionary<int, ViewModelType> dataCache = new Dictionary<int, ViewModelType>();

        protected ModelType model;
        public int Id { get { return model.Id; } }

        protected ViewModelBase()
        {
        }
        
        public async Task Insert()
        {
            EnsureDataProviderExists();

            await dataProvider.InsertAsync(model);
            dataCache[model.Id] = (ViewModelType)this;
        }

        public virtual async Task Update()
        {
            EnsureDataProviderExists();

            await dataProvider.UpdateAsync(model);
        }

        public async Task Delete()
        {
            EnsureDataProviderExists();

            await dataProvider.DeleteAsync(model);
            dataCache.Remove(model.Id);
            model = null;
        }

        public async Task Revert()
        {
            EnsureDataProviderExists();

            model = await dataProvider.LookupAsync(model.Id);
            await RefreshFields();
        }

        public static async Task<ViewModelType> Create(ModelType model = null)
        {
            if (model == null)
            {
                model = new ModelType();
            }
            else if (model.Id != 0 && dataCache.ContainsKey(model.Id))
            {
                return dataCache[model.Id];
            }

            var viewModel = new ViewModelType();
            viewModel.model = model;

            if (model.Id != 0)
            {
                dataCache[model.Id] = viewModel;
                await viewModel.RefreshFields();
            }

            return viewModel;
        }

        public static async Task<IEnumerable<ViewModelType>> Enumerate()
        {
            EnsureDataProviderExists();

            var viewModels = new List<ViewModelType>();
            var tasks = new List<Task<ViewModelType>>();
            
            foreach (var model in await dataProvider.Enumerate())
            {
                tasks.Add(Create(model));
            }

            foreach (var task in tasks)
            {
                viewModels.Add(await task);
            }

            return viewModels;
        }

        public static async Task<ViewModelType> Get(int id)
        {
            if (dataCache.ContainsKey(id))
            {
                return dataCache[id];
            }

            EnsureDataProviderExists();

            return await Create(await dataProvider.LookupAsync(id));
        }

        public static async Task<IEnumerable<ViewModelType>> Where(Expression<Func<ModelType, bool>> predicate)
        {
            var predicateMethod = predicate.Compile();
            var cached = dataCache.Where(x => predicateMethod(x.Value.model));

            if (cached.Count() > 0)
            {
                return cached.Select(x => x.Value);
            }

            EnsureDataProviderExists();

            var matchingModels = await dataProvider.Where(predicate).ToEnumerableAsync();
            var tasks = matchingModels.Select(x => Create(x));
            var viewModels = new List<ViewModelType>();

            foreach (var task in tasks)
            {
                viewModels.Add(await task);
            }

            return viewModels;
        }

        protected abstract Task RefreshFields();

        private static void EnsureDataProviderExists()
        {
            if (dataProvider == null)
            {
                dataProvider = new DataProvider<ModelType>();
            }
        }
    }
}
