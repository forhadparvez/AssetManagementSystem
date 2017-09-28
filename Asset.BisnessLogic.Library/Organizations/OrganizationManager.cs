
using Asset.DataAccess.Library.Organizations;
using Asset.Models.Library.EntityModels.OrganizationModels;
using System.Collections.Generic;

namespace Asset.BisnessLogic.Library.Organizations
{
    public class OrganizationManager : IRepositoryManager<Organization>
    {
        private readonly OrganizationGetway _organizationGetway;

        public OrganizationManager()
        {
            _organizationGetway = new OrganizationGetway();
        }

        public bool IsShortNameExist(string shortName)
        {
            bool isShortNameExist = false;
            var organization = GetOrganizationByShortName(shortName);
            if (organization != null)
            {
                isShortNameExist = true;
            }
            return isShortNameExist;
        }


        public IEnumerable<Organization> FindById(int id)
        {
            return _organizationGetway.Find(id);
        }

        public Organization SingleOrganization(int id)
        {
            return _organizationGetway.SingleOrganization(id);
        }

        public Organization Get(int id)
        {
            return _organizationGetway.Get(id);
        }

        public IEnumerable<Organization> GetAll()
        {
            return _organizationGetway.GetAll();
        }

        public int Add(Organization entity)
        {
            return _organizationGetway.Add(entity);
        }

        public int AddRange(IEnumerable<Organization> entities)
        {
            return _organizationGetway.AddRange(entities);
        }

        public int Update(Organization entity)
        {
            return _organizationGetway.Update(entity);
        }

        public int Remove(Organization entity)
        {
            return _organizationGetway.Remove(entity);
        }

        public int RemoveRange(IEnumerable<Organization> entities)
        {
            return _organizationGetway.RemoveRange(entities);
        }


        public Organization GetOrganizationByShortName(string shortName)
        {
            return _organizationGetway.GetOrganizationByShortName(shortName);
        }
    }
}
