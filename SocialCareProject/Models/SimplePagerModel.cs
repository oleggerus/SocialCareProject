using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataRepository;

namespace SocialCareProject.Models
{
    public class SimplePagerModel
    {
        public SimplePagerModel()
        {
            this.TotalCount = 0;
            this.TotalPages = 0;
            this.PageSize = Constants.Paging.DefaultPageSize;
            this.PageIndex = 0;
            this.HasNextPage = false;
            this.HasPreviousPage = false;
        }

        /// <summary>
        ///  Gets or sets zero based page index
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        ///  Gets or sets the page size
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        ///  Gets or sets the total number of pages
        /// </summary>
        public int TotalPages { get; set; }
        /// <summary>
        ///  Gets or sets the has next page idicator
        /// </summary>
        public bool HasNextPage { get; set; }
        /// <summary>
        ///  Gets or sets the has previous page indicator
        /// </summary>
        public bool HasPreviousPage { get; set; }
        /// <summary>
        ///  Gets or sets the total number of records
        /// </summary>
        public int TotalCount { get; set; }
    }
}