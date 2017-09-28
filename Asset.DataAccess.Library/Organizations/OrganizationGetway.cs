
using Asset.Infrastucture.Library.UnitOfWorks;
using Asset.Models.Library.EntityModels.OrganizationModels;
using AssetSqlDatabase.Library.DatabaseContext;
using System.Collections.Generic;

namespace Asset.DataAccess.Library.Organizations
{
    public class OrganizationGetway : IRepositoryGetway<Organization>
    {
        private readonly OrganizationUnitOfWork _organizationUnitOfWork;

        public OrganizationGetway()
        {
            _organizationUnitOfWork = new OrganizationUnitOfWork(new AssetDbContext());
        }


        public Organization Get(int id)
        {
            return _organizationUnitOfWork.Orgnation.Get(id);
        }

        public IEnumerable<Organization> GetAll()
        {
            return _organizationUnitOfWork.Orgnation.GetAll();
        }

        public int Add(Organization entity)
        {
            _organizationUnitOfWork.Orgnation.Add(entity);
            return _organizationUnitOfWork.Complete();
        }

        public int AddRange(IEnumerable<Organization> entities)
        {
            _organizationUnitOfWork.Orgnation.AddRange(entities);
            return _organizationUnitOfWork.Complete();
        }

        public int Update(Organization entity)
        {
            _organizationUnitOfWork.Orgnation.Update(entity);
            return _organizationUnitOfWork.Complete();
        }

        public int Remove(Organization entity)
        {
            _organizationUnitOfWork.Orgnation.Remove(entity);
            return _organizationUnitOfWork.Complete();
        }

        public int RemoveRange(IEnumerable<Organization> entities)
        {
            _organizationUnitOfWork.Orgnation.RemoveRange(entities);
            return _organizationUnitOfWork.Complete();
        }

        public IEnumerable<Organization> Find(int id)
        {
            return _organizationUnitOfWork.Orgnation.Find(c => c.Id == id);
        }

        public Organization SingleOrganization(int id)
        {
            return _organizationUnitOfWork.Orgnation.SingleOrDefault(c => c.Id == id);
        }

        public Organization GetOrganizationByShortName(string shortName)
        {
            return _organizationUnitOfWork.Orgnation.GetOrganizationByShortName(shortName);
        }
    }
}
