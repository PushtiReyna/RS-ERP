namespace WebApi.ViewModel.ReqViewModel
{
    public class GetLeaveReqViewModel
    {
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
        public bool OrderBy { get; set; }
        public string? SearchString { get; set; }
    }
}
