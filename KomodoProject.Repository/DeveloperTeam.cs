using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoProject.Repository
{
    public class DeveloperTeam
    {
        public List<DeveloperTeam> developersOnTeam;
        private string v;

        public string TeamName { get; set; }
        public string TeamCategory { get; set; }
        public bool PluralSightAccess { get; set; }

        public DeveloperTeam() { }

        public DeveloperTeam(string teamName, string teamCategory)
        {
            TeamName = teamName;
            TeamCategory = teamCategory;

        }

        public DeveloperTeam(string v)
        {
            this.v = v;
        }

        public static implicit operator DeveloperTeam(string v)
        {
            throw new NotImplementedException();
        }

        public void AddTeamContentToList(DeveloperTeam homeownersTeam)
        {
            throw new NotImplementedException();
        }
    }
}
