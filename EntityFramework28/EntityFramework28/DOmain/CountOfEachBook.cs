using System;
using System.Collections.Generic;

namespace EntityFramework28.Domain
{
    public partial class CountOfEachBook
    {
        public int Amount { get; set; }
        public int? Book { get; set; }

        public virtual Book BookNavigation { get; set; }
    }
}
