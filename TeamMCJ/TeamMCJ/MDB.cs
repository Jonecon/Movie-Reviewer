using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamMCJ
{
    public class MDB
    {
        //Connecting to the MongoDB and getting the db
        public static MongoClient dbClient = new MongoClient("mongodb://127.0.0.1:27017/?compressors=disabled&gssapiServiceName=mongodb");
        public static IMongoDatabase dbTeammcj = dbClient.GetDatabase("TeamMCJ");
        public static IMongoDatabase dbPrac = dbClient.GetDatabase("Practice");
    }
}
