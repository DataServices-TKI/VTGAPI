using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VTGWebAPI.ViewModels
{
    public class ReferenceListViewModel
    {        
            public int AppValueListId { get; set; }
            public int AppValueListName { get; set; }
            public Guid UniqueRowId { get; set; }
            public string AppValueListData1 { get; set; }
            public string AppValueListDescription { get; set; }
            public int? SortOrder { get; set; }        
    }
}