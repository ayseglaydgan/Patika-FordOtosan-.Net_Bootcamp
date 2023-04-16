using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceAPI.BaseClass.Types
{
    public enum RoleEnum
    {
        [Description(Role.Admin)]
        Admin = 1,

        [Description(Role.EditorQTNS)]
        EditorQTNS = 2,

        [Description(Role.EditorQTDA)]
        EditorQTDA = 3,

        [Description(Role.Viewer)]
        Viewer = 4
    }

    public class Role
    {
        public const string Admin = "admin";
        public const string EditorQTNS = "editor-qtns";
        public const string EditorQTDA = "editor-qtda";
        public const string Viewer = "viewer";
        public const string RolesExceptAdmin = Role.Viewer + "," + Role.EditorQTNS + "," + Role.EditorQTDA;
    }
}
