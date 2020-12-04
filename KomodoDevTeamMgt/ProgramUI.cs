using KomodoProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDevTeamMgt
{
    class ProgramUI
    {
        private KomodoContentRepo _contentRepo = new KomodoContentRepo();
        private DeveloperTeam _teamContentRepo = new DeveloperTeam();
        // Method that runs/starts the application
        public void Run()
        {
            SeedDeveloperList();
            SeedDeveloperTeamList();
            Menu();
        }

       
        // Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display our options to the user
                Console.WriteLine("(This program is a Work In Progress) Select a menu option:\n" +
                    "1. Add New Developer\n" +
                    "2. View All Developers\n" +
                    "3. View a specific Komodo Team\n" +
                    "4. Update Existing Content\n" +
                    "5. Delete Existing Content\n" +
                    "6. Exit");

                // Get the users' input
                string input = Console.ReadLine();

                // Evaluate the users' input and act accordingly
                switch (input)
                {
                    case "1":
                        //Create new content
                        AddNewDeveloper();
                        break;
                    case "2":
                        //View all content
                        DisplayAllDevelopers();
                        break;
                    case "3":
                        //view content by Title
                        DisplayTeams();
                        break;
                    case "4":
                        //update existing content
                        UpdateDeveloperList();
                        break;
                    case "5":
                        //Delete existing content
                        DeleteDeveloper();
                        break;
                    case "6":
                        //Exit
                        Console.WriteLine("Good-bye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        // Create new StreamingContent
        private void AddNewDeveloper()
        {
            Console.Clear();
            Developer newContent = new Developer();

            //First Name
            Console.WriteLine("Enter the first name:");
            newContent.FirstName = Console.ReadLine();
            //Last Name
            Console.WriteLine("Enter the last name:");
            newContent.LastName = Console.ReadLine();

            //Id Number
            Console.WriteLine("Enter the ID number (last 4 of social security number): ");
            newContent.IdNumber = int.Parse(Console.ReadLine());

            //PluralSight Access
            Console.WriteLine("Pluralsight access? (y/n)");
            string PluralSightAccess = Console.ReadLine().ToLower();

            if (PluralSightAccess == "y")
            {
                newContent.PluralSightAccess = true;
             }
            else
            {
                newContent.PluralSightAccess = false;
            }
            
            

            //Teams
            Console.WriteLine("Enter the Team Type:\n" +
                "1. Life Insurance\n" +
                "2. Automobile Insurance\n" +
                "3. Homeowners Insurance\n" +
                "4. Business Insurance\n");
                

            string devTeamAsString = Console.ReadLine();
            int devTeamAsInt = int.Parse(devTeamAsString);
            newContent.TeamName = (DevTeamType)devTeamAsInt;

            _contentRepo.AddContentToList(newContent);
        }

        //View Current StreamContent that is saved
        private void DisplayAllDevelopers()
        {
            List<Developer> listOfContent = _contentRepo.GetContentList();
            
            foreach (Developer content in listOfContent)
            {
                Console.WriteLine($" {content.FirstName} " +
                    $" {content.LastName}" + $" {content.TeamName}" + $"   {content.PluralSightAccess}" );
            }

           // _contentRepo.PrintContentList();
        }
        //View existing pluralsight access
        private void DisplayTeams()
        {
            Console.Clear();
            //prompt the user to give me a name
            Console.WriteLine("Enter the name of the team you would like to see listed:");
            //Get the users' input
            string name = Console.ReadLine();
            //find the content by that title
            Developer content = _contentRepo.GetContentByName(name);

            //Display said content if it isn't null
            if (content != null)
            {
                Console.WriteLine($"First Name: {content.FirstName}\n" +
                    $"Last Name: {content.LastName}\n" +
                    $"Developer ID Number: {content.IdNumber}\n" +
                    $"Has Pluralsight Access: {content.PluralSightAccess}\n" +
                    $"Team Type: {content.TeamName}");
            }
            else
            {
                Console.WriteLine("No team by that name. ");
            }
        }
        //Update Existing content
        private void UpdateDeveloperList()
        {
            //Display all content
            DisplayAllDevelopers();
            //Ask for the name
            Console.WriteLine("Enter the name of the developer you would like to update:");
            //get that developer
            string oldDevName = Console.ReadLine();
            //build a new poco
            Developer newContent = new Developer();

            //First name
            Console.WriteLine("Enter the first name:");
            newContent.FirstName = Console.ReadLine();
            //Last name
            Console.WriteLine("Enter the last name:");
            newContent.LastName = Console.ReadLine();

            //id number
            Console.WriteLine("Enter the ID number (last 4 of social security number): ");
            string idAsString = Console.ReadLine();
            newContent.IdNumber = int.Parse(idAsString);


            
            //Pluralsight access
            Console.WriteLine("Do they have Pluralsight access? (y/n)");
            string pluralSightAccess = Console.ReadLine().ToLower();

            if (pluralSightAccess == "y")
            {
                newContent.PluralSightAccess = true;
            }
            else
            {
                newContent.PluralSightAccess = false;
            }
                        

            //TeamType
            Console.WriteLine("Enter the Team type:\n" +
                "1. Life\n" +
                "2. Automobile\n" +
                "3. Home\n" +
                "4. Business\n");
               

            string nameAsString = Console.ReadLine();
            int nameAsInt = int.Parse(nameAsString);
            newContent.TeamName = (DevTeamType)nameAsInt;
            //verify the update worked
            bool wasUpdated = _contentRepo.UpdateExistingContent(oldDevName, newContent);

            if (wasUpdated)
            {
                Console.WriteLine("Content successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update content.");
            }
        }
        //Delete Existing content
        private void DeleteDeveloper()
        {

            DisplayAllDevelopers();
            //Get the name to remove
            Console.WriteLine("\nEnter the name that you'd like to remove:");
            string input = Console.ReadLine();
            //Call the delete method
            bool wasDeleted = _contentRepo.RemoveContentFromList(input);
            //If the content was deleted, say so
            if (wasDeleted)
            {
                Console.WriteLine("The content was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The content could not be deleted.");
            }
            //Otherwise state it could not be deleted


        }

        // See method
        private void SeedDeveloperList()
        {
            
            Developer jasonBagwill = new Developer("Jason", "Bagwill", 3456 , true, DevTeamType.Automobile);
            Developer tomBrady = new Developer("Tom", "Brady", 1234 , false, DevTeamType.Homeowners);
            Developer peytonManning = new Developer("Peyton", "Manning", 5678 , false, DevTeamType.Life);

            _contentRepo.AddContentToList(jasonBagwill);
            _contentRepo.AddContentToList(tomBrady);
            _contentRepo.AddContentToList(peytonManning);
            
        }
        private void SeedDeveloperTeamLIst()
        {
            DeveloperTeam automobileTeam = new DeveloperTeam("Automobile Team");
            DeveloperTeam homeownersTeam = new DeveloperTeam("Homeowners Team");

            _teamContentRepo.AddTeamContentToList(automobileTeam);
            _teamContentRepo.AddTeamContentToList(homeownersTeam);
        }
    }
}
