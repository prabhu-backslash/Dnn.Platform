﻿#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace DotNetNuke.Entities.Portals
{
    public interface IPortalGroupController
    {
        int AddPortalGroup(PortalGroupInfo portalGroup);

        void AddPortalToGroup(PortalInfo portal, PortalGroupInfo portalGroup, UserCopiedCallback callback);

        void DeletePortalGroup(PortalGroupInfo portalGroup);

        IEnumerable<PortalGroupInfo> GetPortalGroups();

        IEnumerable<PortalInfo> GetPortalsByGroup(int portalGroupId);

        void RemovePortalFromGroup(PortalInfo portal, PortalGroupInfo portalGroup, bool copyUsers, UserCopiedCallback callback);

        void UpdatePortalGroup(PortalGroupInfo portalGroup);

        bool IsModuleShared(int moduleId, PortalInfo portal);
    }
}
