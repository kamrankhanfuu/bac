using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BACAgent.Models.DBTable
{
    public class UserHierarchy
    {
        public string Id { get; set; }
        public string ParentUserId { get; set; }
        public string ChildUserId { get; set; }
    }
}