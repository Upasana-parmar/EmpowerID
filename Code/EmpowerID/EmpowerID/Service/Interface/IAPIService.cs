namespace EmpowerID.Service.Interface
{
    public interface IAPIService
    {
        Task<T> Post<T>(string url, HttpContent content);
        Task<T> Post<T>(string url, object param);
        Task<T> Get<T>(string url, params object[] param);
        Task<T> Delete<T>(string url, params object[] param);
        Task Get(string url, params object[] param);
    }
}
