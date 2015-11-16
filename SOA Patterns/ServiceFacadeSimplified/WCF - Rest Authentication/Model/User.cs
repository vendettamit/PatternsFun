using System;
using System.Runtime.Serialization;

namespace WcfRestAuthentication.Model
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