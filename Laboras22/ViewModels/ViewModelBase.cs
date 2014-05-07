using Laboras22.Classes;
using Laboras22.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.ViewModels
{
    public class ViewModelBase<ModelType, ViewModelType>
        where ModelType : class, IDataItem, new() 
        where ViewModelType : ViewModelBase<ModelType, ViewModelType>, new()
    {
        private static DataProvider<ModelType> dataProvider;
        protected ModelType model;

        protected ViewModelBase()
        {
        }
        
        public async Task Insert()
        {
            EnsureDataProviderExists();

            await dataProvider.InsertAsync(model);
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
            model = null;
        }

        public static ViewModelType Create(ModelType model = null)
        {
            if (model == null)
            {
                model = new ModelType();
            }

            var viewModel = new ViewModelType();
            viewModel.model = model;

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

        private static void EnsureDataProviderExists()
        {
            if (dataProvider == null)
            {
                dataProvider = new DataProvider<ModelType>();
            }
        }
    }
}
