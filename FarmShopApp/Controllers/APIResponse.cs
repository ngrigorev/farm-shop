namespace FarmShopApp.Controllers
{
    public interface IResponse { }
    public class APIResponse<T> : IResponse
    {
        private bool _isSuccess;

        public bool IsError
        { 
            get => !_isSuccess;
            set => _isSuccess = !value;
        }
        public bool IsSuccess
        { 
            get => _isSuccess;
            set => _isSuccess = value;
        }
        public T Data { get; set; }
        public string Error { get; set; }
    }
}