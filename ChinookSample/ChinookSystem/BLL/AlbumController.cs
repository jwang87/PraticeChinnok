using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel; //ODS
using ChinookSystem.Data.Entities;
using ChinookSystem.Data.POCOs;
using ChinookSystem.DAL;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class AlbumController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<AlbumReleaseYear> AlbumReleaseYear_Get()
        {
            using (var context = new ChinookContext())
            {
                var results = (from x in context.Albums
                               orderby x.ReleaseYear ascending
                               select new AlbumReleaseYear
                               {
                                   //AlbumId = x.AlbumId,
                                   ReleaseYear = x.ReleaseYear
                               }).Distinct();
                return results.ToList();

            }
        }


    }
}
