﻿namespace WebApi.ViewModel.ReqViewModel
{
    public class GetEmployeeReqViewModel
    {
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
        public bool OrderBy { get; set; }
    }
}
