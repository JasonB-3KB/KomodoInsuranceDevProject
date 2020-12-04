using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoProject.Repository
{
    public class DevTeamRepo
    {
        private List<DeveloperTeam> _listOfTeams = new List<DeveloperTeam>();

        //create
        public void AddTeamContentToList(DeveloperTeam content)
        {
            _listOfTeams.Add(content);
        }


        //read
        public List<DeveloperTeam> GetContentList()
        {
            return _listOfTeams;
        }
        public void PrintContentList()
        {
            foreach (DeveloperTeam content in _listOfTeams)
            {
                Console.WriteLine($"Team Name: {content.TeamName} " +
                    $"Team Category: {content.TeamCategory}");
            }
        }

        //update
        public bool UpdateExistingContent(string originalContent, DeveloperTeam newContent)
        {
            // Find the content
            DeveloperTeam oldContent = (originalContent);

            //Update the content
            if (oldContent != null)
            {
                oldContent.TeamName = newContent.TeamName;
                oldContent.TeamCategory = newContent.TeamCategory;
                oldContent.PluralSightAccess = newContent.PluralSightAccess;
                
                return true;
            }
            else
            {
                return false;
            }
        }



        //delete
        public bool RemoveContentFromList(string team)
        {
            DeveloperTeam content = (team);

            if (content == null)
            {
                return false;
            }

            int initialCount = _listOfTeams.Count;
            _listOfTeams.Remove(content);

            if (initialCount > _listOfTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
