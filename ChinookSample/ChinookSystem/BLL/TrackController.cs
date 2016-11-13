using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel;
using ChinookSystem.Data.Entities;
using ChinookSystem.Data.POCOs;
using ChinookSystem.DAL;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class TrackController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Track> List_Tracks_Get()
        {
            using (var context = new ChinookContext())
            {
                //return all records all attributes
                return context.Tracks.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Track Get_Track(int trackid)
        {
            using (var context = new ChinookContext())
            {
                //return a record all attributes
                return context.Tracks.Find(trackid);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public void Insert_Track(Track trackInfo)
        {
            using (var context = new ChinookContext())
            {
                //any business rules
                if (trackInfo.UnitPrice > 1.0m)
                {
                    throw new Exception("Bob is your uncle");
                }
                //any data refinements
                //review of using iif
                //composer can be a null string
                //we do not wish to store an empty string
                trackInfo.composer = string.IsNullOrEmpty(trackInfo.composer) ? null : trackInfo.composer;

                //add the instance of trackinfo to the database
                context.Tracks.Add(trackInfo);

                //commit of the add
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void Update_Track(Track trackInfo)
        {
            using (var context = new ChinookContext())
            {
                //any business rules

                //any data refinements
                //review of using iif
                //composer can be a null string
                //we do not wish to store an empty string
                trackInfo.composer = string.IsNullOrEmpty(trackInfo.composer) ? null : trackInfo.composer;

                //update the existing instance in the database
                context.Entry(trackInfo).State = System.Data.Entity.EntityState.Modified;

                //commit of the add
                context.SaveChanges();
            }
        }
        //the Delete_Track is an overloaded method 
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void Delete_Track(Track trackInfo)
        {
            Delete_Track(trackInfo.TrackId);
        }

        public void Delete_Track(int trackid)
        {
            using (var context = new ChinookContext())
            {
                //any business rules

                //do the delete
                //find the exising record on the database
                var existingRecord = context.Tracks.Find(trackid);
                //remove the record from the database
                context.Tracks.Remove(existingRecord);
                //commit the transaction
                context.SaveChanges();

            }
        }

    }
}
