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
    public class ArtistController
    {
        //dump the entire aritist entities
        //this will use Entity Framework access
        //Entity classes will be used to define the data
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Artist> Artist_ListAll()
        {
            //set up transaction area
            using (var context = new ChinookContext())
            {
                return context.Artists.ToList();
            }
        }

        //report a dataset containning data from
        //   multiple entities
        //this will use Linq to Entity access
        //POCO classes will be used to define the data
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ArtistAlbums> Artist_Album_Get()
        {
            //set up transaction area
            using (var context = new ChinookContext())
            {
                //when you bring your query from LinqPad
                //to your program you must change the 
                //references to the data source

                //you may also need to change your
                //navigation referencing use in LinqPad
                //to the navigation properties you stated
                //in the Entity class definitions
                var results = from x in context.Albums
                              where x.ReleaseYear == 2008
                              orderby x.Artists.Name, x.Title
                              select new ArtistAlbums
                              {
                                  //Name and Title are POCO
                                  //Class property names
                                  Name = x.Artists.Name,
                                  Title = x.Title
                              };
                //the following requires the query data in memory
                //ToList()
                //At this point query will actually excute
                return results.ToList();
            }
        }
    }
}
