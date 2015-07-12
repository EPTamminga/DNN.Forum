//
// DotNetNuke® - http://www.dotnetnuke.com
// Copyright (c) 2002-2011
// by DotNetNuke Corporation
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text;
using DotNetNuke.Modules.Forums.Components.Entities;

namespace DotNetNuke.Modules.Forums.Services {
    /// <summary>
    /// Summary description for Forums
    /// </summary>
    [WebService(Namespace = "http://dnnforums.dotnetnuke.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Forums : System.Web.Services.WebService {

        [WebMethod]
        public List<ForumInfo> ForumsList(int ModuleId) {
            Modules.Forums.Components.Controllers.ForumsController fc = new Modules.Forums.Components.Controllers.ForumsController();
            List<ForumInfo> fl = fc.GetModuleForums(ModuleId);
            return fl;
            
        }
        [WebMethod]
        public ForumInfo ForumGet(int ForumId) {
            Modules.Forums.Components.Controllers.ForumsController fc = new Modules.Forums.Components.Controllers.ForumsController();
            ForumInfo fi = fc.GetForum(ForumId); 
            return fi;

        }
        [WebMethod]
        public ForumInfo ForumSave(int PortalId, int ModuleId, int ForumId, int ParentId, bool AllowTopics, string Name, string Description, int SortOrder, bool Active, 
            bool Hidden, int TopicCount, int ReplyCount, int LastPostId, string Slug, int PermissionId, int SettingId, string EmailAddress, float SiteMapPriority) {
            Modules.Forums.Components.Controllers.ForumsController fc = new Modules.Forums.Components.Controllers.ForumsController();
            ForumInfo fi = new ForumInfo();
            if (ForumId > 0) {
                fi = fc.GetForum(ForumId);
            }
            if (fi == null) {
                fi = new ForumInfo();
                fi.TopicCount = 0;
                fi.ReplyCount = 0;
                fi.LastPostId = 0;
            }
            fi.ForumId = ForumId;
            fi.PortalId = PortalId;
            fi.ModuleId = ModuleId;
            fi.ParentId = ParentId;
            fi.AllowTopics = AllowTopics;
            fi.Name = Name;
            fi.Description = Description;
            fi.SortOrder = SortOrder;
            fi.Active = Active;
            fi.Hidden = Hidden;
            fi.Slug = Slug;
            fi.PermissionId = PermissionId;
            fi.SettingId = SettingId;
            fi.EmailAddress = EmailAddress;
            fi.SiteMapPriority = SiteMapPriority;
            fi.CreatedByUserId = -1;
            fi.LastModifiedByUserId = -1;
            fc.SaveForum(fi);
            return fi;
        }
        [WebMethod]
        public bool ForumDelete(int portalId, int moduleId, int forumId) {
            Modules.Forums.Components.Controllers.ForumsController fc = new Modules.Forums.Components.Controllers.ForumsController();
            try {
                fc.DeleteForum(forumId, moduleId, portalId);
                return true;
            } catch {
                return false;
            }
        }

    }
}
