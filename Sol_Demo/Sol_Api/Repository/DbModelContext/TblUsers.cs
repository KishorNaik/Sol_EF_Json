﻿using System;
using System.Collections.Generic;

namespace Sol_Api.Repository.DbModelContext
{
    public partial class TblUsers
    {
        public decimal UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
