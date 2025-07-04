﻿namespace ProjectEntityManagementWithCRUD.Models.DTO
{
    public class PagedResult<T>
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
