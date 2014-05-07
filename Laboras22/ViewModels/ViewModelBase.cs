using Laboras22.Classes;
using Laboras22.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task Update()
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
            RefreshFields();
        }

        public static ViewModelType Create(ModelType model = null)
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
            }

            return viewModel;
        }

        public static async Task<IEnumerable<ViewModelType>> Enumerate()
        {
            EnsureDataProviderExists();

            var viewModels = new List<ViewModelType>();

            foreach (var model in await dataProvider.Enumerate())
            {
                viewModels.Add(Create(model));
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

            return Create(await dataProvider.LookupAsync(id));
        }

        protected abstract void RefreshFields();

        private static void EnsureDataProviderExists()
        {
            if (dataProvider == null)
            {
                dataProvider = new DataProvider<ModelType>();
            }
        }
    }
}
