using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatejCervelinMvcProjekt.DAL
{
    public class RepoFactory
    {
        public static IRepo GetRepo()
        {
            return new Repository();
        }
    }
}