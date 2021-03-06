﻿using Asset.DataAccess.Library.AssetSetups;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using System;
using System.Collections.Generic;

namespace Asset.BisnessLogic.Library.AssetSetups
{
    public class AssetManufacturerManager : IRepositoryManager<AssetManufacurer>
    {
        private readonly AssetManufacturerGetway _assetManufacturerGetway;

        public AssetManufacturerManager()
        {
            _assetManufacturerGetway = new AssetManufacturerGetway();
        }

        public AssetManufacurer Get(int id)
        {
            return _assetManufacturerGetway.Get(id);
        }

        public IEnumerable<AssetManufacurer> GetAll()
        {
            return _assetManufacturerGetway.GetAll();
        }

        public IEnumerable<AssetManufacurer> GetManufacurersByGroupId(int groupId)
        {
            return _assetManufacturerGetway.GetManufacurersByGroupId(groupId);
        }

        public int Add(AssetManufacurer entity)
        {
            return _assetManufacturerGetway.Add(entity);
        }

        public int AddRange(IEnumerable<AssetManufacurer> entities)
        {
            throw new NotImplementedException();
        }

        public int Update(AssetManufacurer entity)
        {
            return _assetManufacturerGetway.Update(entity);
        }

        public int Remove(AssetManufacurer entity)
        {
            return _assetManufacturerGetway.Remove(entity);
        }

        public int RemoveRange(IEnumerable<AssetManufacurer> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AssetManufacurer> GetAllManufacturerWithGroup()
        {
            return _assetManufacturerGetway.GetAllManufacturerWithGroup();
        }

        public bool IsShortNameExist(string shortName, int groupId)
        {
            bool isShortNameExist = false;
            var assetManufacturer = _assetManufacturerGetway.GetByGroupIdAndShortName(shortName, groupId);
            if (assetManufacturer != null)
            {
                isShortNameExist = true;
            }
            return isShortNameExist;
        }
    }
}
