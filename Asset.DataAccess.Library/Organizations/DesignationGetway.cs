using System;
using Asset.Infrastucture.Library.UnitOfWorks;
using Asset.Models.Library.EntityModels.OrganizationModels;
using AssetSqlDatabase.Library.DatabaseContext;
using System.Collections.Generic;

namespace Asset.DataAccess.Library.Organizations
{
    public class DesignationGetway : IRepositoryGetway<Designation>
    {
        private readonly DepartmentDesignationUnitOfWork _designationUnitOfWork;

        public DesignationGetway()
        {
            _designationUnitOfWork = new DepartmentDesignationUnitOfWork(new AssetDbContext());
        }
        public int Add(Designation entity)
        {
            _designationUnitOfWork.Designation.Add(entity);
            return _designationUnitOfWork.Complete();
        }

        public int AddRange(IEnumerable<Designation> entities)
        {
            _designationUnitOfWork.Designation.AddRange(entities);
            return _designationUnitOfWork.Complete();
        }

        public Designation Get(int id)
        {
            return _designationUnitOfWork.Designation.Get(id);
        }

        public IEnumerable<Designation> GetAll()
        {
            return _designationUnitOfWork.Designation.GetAll();
        }

        public int Remove(Designation entity)
        {
            _designationUnitOfWork.Designation.Remove(entity);
            return _designationUnitOfWork.Complete();
        }

        public int RemoveRange(IEnumerable<Designation> entities)
        {
            _designationUnitOfWork.Designation.RemoveRange(entities);
            return _designationUnitOfWork.Complete();
        }

        public int Update(Designation entity)
        {
            _designationUnitOfWork.Designation.Update(entity);
            return _designationUnitOfWork.Complete();
        }

        public Designation GetDesignationByShortName(string shortNme)
        {
            return _designationUnitOfWork.Department.GetDesignationByShortName(shortNme);
        }

        public IEnumerable<Designation> Find(int id)
        {
            return _designationUnitOfWork.Designation.Find(c => c.Id == id);
        }

        public Designation SingleDesignation(int id)
        {
            return _designationUnitOfWork.Designation.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Designation> GetDesignationsWithDepartment()
        {
            try
            {
                return _designationUnitOfWork.Designation.GetDesignationsWithDepartment();
            }
            catch (Exception e)
            {

                throw e;
            }

        }
    }
}
