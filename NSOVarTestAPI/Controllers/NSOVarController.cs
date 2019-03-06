using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using NSOVarTestAPI.Models;

namespace NSOVarTestAPI.Controllers
{
    [Route("api/[controller]")]
    public class NSOVarController : ControllerBase
    {
        IMongoCollection<model1> UserInfoCollection { get; set; }
        IMongoCollection<model3> SNF1_FSCollection { get; set; }
        IMongoCollection<model4> EA_FSCollection { get; set; }

        public NSOVarController()
        {
            var settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://thes:YeJS7zDuNxxL0RYJpsMnRJNrOvX38wvirS87JCFNeIjfAOnBdJ009gppbpmCbEQbbRiL6SNU6AWxmJiyZ30OVg==@thes.documents.azure.com:10255/?ssl=true&replicaSet=globaldb"));
            var mongoClient = new MongoClient(settings);

            var database = mongoClient.GetDatabase("VSTS");
            settings.SslSettings = new SslSettings()
            {
                EnabledSslProtocols = SslProtocols.Tls12
            };

            UserInfoCollection = database.GetCollection<model1>("Userinfo");
            SNF1_FSCollection = database.GetCollection<model3>("Sn1_fs");
            EA_FSCollection = database.GetCollection<model4>("Ea_fs");

        }

        [HttpGet("userlower_role_area")]
        public List<model1> GetAllUserInfo(string TID,string CWT)
        {
            var data = UserInfoCollection.Find(it => true).ToList();
            return data;
        }

        [HttpGet("sn1_fs")]
        public List<model3> GetAllSN1_FS(string FS_ID)
        {
            var data = SNF1_FSCollection.Find(it => true).ToList();
            return data;
        }

        [HttpGet("sn22_fs")]
        public List<Object> GetAllSN22_FS(string FS_ID)
        {
            return new List<Object>();
        }

        [HttpGet("ea_fs")]
        public List<model4> GetAllEA_FS(string FS)
        {
            var data = EA_FSCollection.Find(it => true).ToList();
            return data;
        }


        [HttpPost("user_id_pwd")]
        public List<model1> LogIn([FromBody]User dataUser)
        {
            var data = UserInfoCollection.Find(it => it.USERID == dataUser.USERID && it.PASSWORD == dataUser.PASSWORD).ToList();
            return data;
        }
    }

}
