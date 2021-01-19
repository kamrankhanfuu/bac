using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BACAgent.Models.DTO
{
    public class UserHierarchyItem
    {
        public string UserId { get; set; }
        public UserHierarchyItem[] ChildItems { get; set; }
    }
}   