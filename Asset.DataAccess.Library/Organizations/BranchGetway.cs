using Asset.Infrastucture.Library.UnitOfWorks;
using Asset.Models.Library.EntityModels.OrganizationModels;
using AssetSqlDatabase.Library.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asset.DataAccess.Library.Organizations
{
    public class BranchGetway : IRepositoryGetway<Branch>
    {
        private readonly OrganizationUnitOfWork _organizationUnitOfWork;

        public BranchGetway()
        {
            _organizationUnitOfWork = new OrganizationUnitOfWork(new AssetDbContext());
        }
        public int Add(Branch entity)
        {
            _organizationUnitOfWork.Branch.Add(entity);
            return _organizationUnitOfWork.Complete();
        }

        public int AddRange(IEnumerable<Branch> entities)
        {
            _organizationUnitOfWork.Branch.AddRange(entities);
            return _organizationUnitOfWork.Complete();
        }

        public Branch Get(int id)
        {
           return _organizationUnitOfWork.Branch.Get(id);

        }

        public IEnumerable<Branch> GetAll()
        {
            return _organizationUnitOfWork.Branch.GetAll();
        }

        public IEnumerable<Branch> GetBranchWithOrganization()
        {
            return _organizationUnitOfWork.Branch.GetBranchWithOrganization();
        }

        public int Remove(Branch entity)
        {
            _organizationUnitOfWork.Branch.Remove(entity);
            return _organizationUnitOfWork.Complete();
        }

        public int RemoveRange(IEnumerable<Branch> entities)
        {
            _organizationUnitOfWork.Branch.RemoveRange(entities);
            return _organizationUnitOfWork.Complete();
        }

        public int Update(Branch entity)
        {
            _organizationUnitOfWork.Branch.Update(entity);
            return _organizationUnitOfWork.Complete();
        }

        public Branch GetBranchByShortName(string shortName, int orgId)
        {
            return _organizationUnitOfWork.Branch.SingleOrDefault(c=>c.ShortName==shortName&& c.OrganizationId==orgId);
        }

        public IEnumerable<Branch> Find(int id)
        {
            return _organizationUnitOfWork.Branch.Find(c => c.Id == id);
        }

        public Branch SingleBranch(int id)
        {
            return _organizationUnitOfWork.Branch.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Branch> GetBranchByOrgId(int orgId)
        {
            return _organizationUnitOfWork.Branch.Find(c => c.OrganizationId == orgId);
        }
    }
}
