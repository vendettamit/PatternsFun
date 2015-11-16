using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Domain.Base;

namespace Domain
{
    [DataContract]
    public class User : IEntity<Guid>
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }

        public static User Create(Guid id, string userName, string firstName, string lastName)
        {
            return new User()
            {
                Id = id,
                UserName = userName,
                FirstName = firstName,
                LastName = lastName
            };
        }
    }
}
