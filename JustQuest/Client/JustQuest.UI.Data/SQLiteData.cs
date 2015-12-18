namespace JustQuest.UI.Data
{
    using SQLite.Net;
    using SQLite.Net.Async;
    using SQLite.Net.Platform.WinRT;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Windows.Storage;

    public static class SQLiteData
    {
        public static SQLiteAsyncConnection GetDbConnectionAsync()
        {
            var dbFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "app.sqlite");

            var connectionFactory =
                new Func<SQLiteConnectionWithLock>(
                    () =>
                    new SQLiteConnectionWithLock(
                        new SQLitePlatformWinRT(),
                        new SQLiteConnectionString(dbFilePath, storeDateTimeAsTicks: false)));

 
            var asyncConnection = new SQLiteAsyncConnection(connectionFactory);

            return asyncConnection;
        }

        public static async void InitAsync()
        {
            var connection = GetDbConnectionAsync();
            await connection.CreateTableAsync<UserCredentials>();
        }

        public static async void AddUserCredentials(UserCredentials user)
        {
            var connection = GetDbConnectionAsync();

            RemoveUserCredentials(connection);

            await connection.InsertAsync(user);
        }

        public static async void RemoveUserCredentials(SQLiteAsyncConnection connection)
        {
            var result = await GetUserCredentials();

            if (result != null)
            {
                await connection.DeleteAllAsync<UserCredentials>();
            }
        }

        public static async Task<UserCredentials> GetUserCredentials()
        {
            var connection = GetDbConnectionAsync();

            AsyncTableQuery<UserCredentials> query = connection.Table<UserCredentials>();
            var result = await query.FirstOrDefaultAsync(); //ToListAsync();

            return result;
        }
       
    }
}
