namespace FarmShopApp.Controllers
{
    public class APIRequest
    {
        const int MIN_PAGE_SIZE = 15;
        int _pageNumber { get; set; } = 0;
        int _pageSize = MIN_PAGE_SIZE;

        public int Page
        { 
            get => _pageNumber;
            set 
            {
                if (value > 0) _pageNumber = value;
            }
        }
        public int PageSize 
        { 
            get => _pageSize;
            set 
            {
                if (value > MIN_PAGE_SIZE) _pageSize = value;
            }
        }
    }
}