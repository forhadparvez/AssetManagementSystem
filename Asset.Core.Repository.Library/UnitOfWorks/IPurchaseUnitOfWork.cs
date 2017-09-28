using Asset.Core.Repository.Library.Repositorys.Purchases;
using Core.Repository.Library.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asset.Core.Repository.Library.UnitOfWorks
{
    public interface IPurchaseUnitOfWork:IUnitOfWork
    {
        IVendorRepository Vendors { get; set; }
    }
}
