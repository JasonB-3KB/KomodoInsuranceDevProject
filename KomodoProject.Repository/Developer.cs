using System;

namespace KomodoProject.Repository
{
    public enum DevTeamType
    {
            Life = 1,
            Automobile = 2,
            Homeowners = 3,
            Business = 4,
     }
    // Plain old C# object -- poco
    public class Developer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IdNumber { get; set; }
        
        public bool PluralSightAccess { get; set; }
        public DevTeamType TeamName { get; set; }

        public Developer() { }

        public Developer(string firstName, string lastName, int idNumber,  bool pluralSightAccess, DevTeamType teamName)
        {
            FirstName = firstName;
            LastName = lastName;
            IdNumber = idNumber;
            PluralSightAccess = pluralSightAccess;
            TeamName = teamName;
        }

        public static implicit operator Developer(string v)
        {
            throw new NotImplementedException();
        }
    }
}
