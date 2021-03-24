using System;
namespace Contact.Domain.Aggregate
{
    public class Contact
    {
        public Guid ID
        {
            get;
            private set;
        }
        public string FirstName
        {
            get;
            private set;
        }
        public string LastName
        {
            get;
            private set;
        }

        public string Organisation
        {
            get;
            private set;
        }

        protected Contact()
        {
        }
        protected Contact(string firstName, string lastName, string organisationName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Organisation = organisationName;
        }

        public static Contact Create(string firstName, string lastName, string organisationName)
        {
            return new Contact(firstName, lastName, organisationName);
        }
    }
}
