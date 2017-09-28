using System.Collections.Generic;
using Asset.DataAccess.Library.Organizations;
using Asset.Models.Library.EntityModels.OrganizationModels;

namespace Asset.BisnessLogic.Library.Organizations
{
    public class BranchManager:IRepositoryManager<Branch>
    {
        private readonly BranchGetway _branchGetway;

        public BranchManager()
        {
            _branchGetway=new BranchGetway();
        }

        public Branch Get(int id)
        {
            return _branchGetway.Get(id);
        }

        public IEnumerable<Branch> GetAll()
        {
            return _branchGetway.GetAll();
        }

        public IEnumerable<Branch> GetBranchWithOrganization()
        {
            return _branchGetway.GetBranchWithOrganization();
        }

        public bool IsBranchShortNameExist(string shortName)
        {
            bool isShortNameExist = false;
            var branch = GetBranchByShortName(shortName);
            if (branch != null)
            {
                isShortNameExist = true;
            }
            return isShortNameExist;
        }

        private Branch GetBranchByShortName(string shortName)
        {
            return _branchGetway.GetBranchByShortName(shortName);
        }

        public IEnumerable<Branch> FindById(int id)
        {
            return _branchGetway.Find(id);
        }

        public Branch SingleBranch(int id)
        {
            return _branchGetway.SingleBranch(id);
        }

        public int Add(Branch entity)
        {
            return _branchGetway.Add(entity);
        }

        public int AddRange(IEnumerable<Branch> entities)
        {
            return _branchGetway.AddRange(entities);
        }

        public int Update(Branch entity)
        {
            return _branchGetway.Update(entity);
        }

        public int Remove(Branch entity)
        {
            return _branchGetway.Remove(entity);
        }

        public int RemoveRange(IEnumerable<Branch> entities)
        {
            return _branchGetway.RemoveRange(entities);
        }
    }
}
