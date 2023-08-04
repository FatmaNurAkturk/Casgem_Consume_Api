using EntityLayer.Abstract;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment:IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public string UserTitle { get; set; }

        public Comment()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }
    }
}
