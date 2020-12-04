using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoProject.Repository
{
    public class KomodoContentRepo
    {
        private List<Developer> _listOfNames = new List<Developer>();

        // Create
        public void AddContentToList(Developer content)
        {
            _listOfNames.Add(content);
        }

        // Read
        public List<Developer> GetContentList()
        {
            return _listOfNames;
        }

        public void PrintContentList()
        {
            foreach (Developer content in _listOfNames)
            {
                Console.WriteLine($"First Name: {content.FirstName} " +
                    $"Last Name: {content.LastName}");
            }
        }

        // Update
        public bool UpdateExistingContent(string originalName, Developer newContent)
        {
            // Find the content
            Developer oldContent = GetContentByName(originalName);

            //Update the content
            if (oldContent != null)
            {
                oldContent.FirstName = newContent.FirstName;
                oldContent.LastName = newContent.LastName;
                oldContent.IdNumber = newContent.IdNumber;
                oldContent.PluralSightAccess = newContent.PluralSightAccess;
                oldContent.TeamName = newContent.TeamName;

                return true;
            }
            else
            {
                return false;
            }
        }

        // Delete
        public bool RemoveContentFromList(string name)
        {
            Developer content = GetContentByName(name);

            if (content == null)
            {
                return false;
            }

            int initialCount = _listOfNames.Count;
            _listOfNames.Remove(content);

            if (initialCount > _listOfNames.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper method
        public Developer GetContentByName(string name)
        {
            foreach (Developer content in _listOfNames)
            {
                if (content.FirstName.ToLower() == name.ToLower())
                {
                    return content;
                }
            }

            return null;
        }
    }
}
