using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace NSOVarTestAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class NSOVarController : ControllerBase
    {
        // IMongoCollection<PartyList> App1PartyScoreCollection { get; set; }
        public NSOVarController()
        {
            //var settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://guntza22:guntza220938@ds026558.mlab.com:26558/electionmana"));
            var settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://thes:YeJS7zDuNxxL0RYJpsMnRJNrOvX38wvirS87JCFNeIjfAOnBdJ009gppbpmCbEQbbRiL6SNU6AWxmJiyZ30OVg==@thes.documents.azure.com:10255/?ssl=true&replicaSet=globaldb"));
            var mongoClient = new MongoClient(settings);
            // mlab
            //var database = mongoClient.GetDatabase("electionmana");
            // Azure
            var database = mongoClient.GetDatabase("VSTS");
            settings.SslSettings = new SslSettings()
            {
                EnabledSslProtocols = SslProtocols.Tls12
            };
            // Table4Collection = database.GetCollection<ScoreArea>("Table4");

        }
        
    }

}
