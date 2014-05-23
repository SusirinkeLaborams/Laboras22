using Laboras22.Interfaces;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Laboras22.Classes
{
    internal partial class DataProvider<DataItem> where DataItem : IDataItem
    {
        private static MobileServiceClient s_AzureService;
        private static bool s_IsConnected;

        private IMobileServiceTable<DataItem> m_Table;

        public static void Connect()
        {
            s_AzureService = new MobileServiceClient(kLogin, kPassword);
            s_IsConnected = false;
        }

        public static void Disconnect()
        {
            s_AzureService.Logout();
            s_AzureService.Dispose();
            s_AzureService = null;

            s_IsConnected = false;
        }

        public DataProvider()
        {
            if (!s_IsConnected)
            {
                throw new InvalidOperationException("You are not connected to the service!");
            }

            m_Table = s_AzureService.GetTable<DataItem>();
        }

        public IMobileServiceTableQuery<T> Select<T>(Expression<Func<DataItem, T>> selector)
        {
            return m_Table.Select(selector);
        }

        public IMobileServiceTableQuery<DataItem> Where(Expression<Func<DataItem, bool>> predicate)
        {
            return m_Table.Where(predicate);
        }

        public async Task InsertAsync(DataItem item)
        {
            await m_Table.InsertAsync(item);
        }

        public async Task<DataItem> LookupAsync(int id)
        {
            return await m_Table.LookupAsync(id);
        }

        public async Task UpdateAsync(DataItem item)
        {
            await m_Table.UpdateAsync(item);
        }

        public async Task DeleteAsync(DataItem item)
        {
            await m_Table.DeleteAsync(item);
        }

        public async Task<IEnumerable<DataItem>> Enumerate()
        {
            return await m_Table.ToEnumerableAsync();
        }
    }
}
