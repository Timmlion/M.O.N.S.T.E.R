using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace MONSTER.Services
{
    public class DbService
    {
        private string _authSecret;
        private string _basePath;
        private IFirebaseClient _client;
        private IFirebaseConfig _config;
        public DbService()
        {
            //_authSecret = configuration["Database:ApiSecret"];
            _basePath = "https://monster-9c6b6-default-rtdb.europe-west1.firebasedatabase.app/";
            _config = new FirebaseConfig
            {
                AuthSecret = _authSecret,
                BasePath = _basePath
            };
            _client = new FireSharp.FirebaseClient(_config);

        }

        public async Task SendDataAsync()
        {
            try
            {
                _ = await _client.PushAsync("/data", new { Name = "Test", Trolo = "Trolo" });
            }
            catch (Exception ex)
            {
                var exception = ex.ToString();
            }
        }
        public FirebaseResponse GetApiKey()
        {
            var task =  _client.GetAsync("/config/-NUVU6ZUx-DQbhmfUw4m/ApiKey");
            task.Wait();
            return task.Result;
        }
    }
}
