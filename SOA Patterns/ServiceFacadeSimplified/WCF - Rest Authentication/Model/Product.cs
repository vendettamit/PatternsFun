using System;
using System.Runtime.Serialization;

namespace WcfRestAuthentication.Model
{
    [DataContract]
    public class Product : IEntity<Guid>
    {
        [DataMember]
        public Guid Id { get; protected set; }

        [DataMember]
        public Guid Category { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        public static Product Create(string name, string description, Guid category)
        {
            return new Product()
            {
                Id = Guid.NewGuid(),
                Category = category,
                Name = name,
                Description = description
            };
        }
    }
}