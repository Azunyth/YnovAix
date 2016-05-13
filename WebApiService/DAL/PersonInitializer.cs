using DomainModel;
using System.Collections.Generic;
using System.Data.Entity;

namespace DAL
{
    internal class PersonInitializer : DropCreateDatabaseAlways<PersonContext>
    {
        protected override void Seed(PersonContext context)
        {
            #region Actors
            var actors = new List<Actor>
            {
                new Actor()
                {
                   Firstname = "Ted",
                   Lastname = "Mosby",
                   Age = 41,
                   RealFirstname = "Josh",
                   RealLastname = "Radnor",
                   MainShow = "HIMYM"
                },
                
                new Actor()
                {
                    Firstname = "Walter",
                    Lastname = "White",
                    Age = 60,
                    RealFirstname = "Bryan",
                    RealLastname = "Cranston",
                    MainShow = "Malcolm"
                }
            };
            #endregion

            #region BusinessMan
            var businessmans = new List<BusinessMan>()
            {
                new BusinessMan()
                {
                    Firstname = "Bill",
                    Lastname = "Gates",
                    Age = 60,
                    IsRetired = true,
                    MainCompany = "Microsoft",
                    NetWorth = 77.3
                },
                new BusinessMan()
                {
                    Firstname = "Evan",
                    Lastname = "Spiegel",
                    Age = 25,
                    IsRetired = false,
                    MainCompany = "Snapchat",
                    NetWorth = 2.1
                }
            };
            #endregion

            actors.ForEach(a => context.Actors.Add(a));
            businessmans.ForEach(bm => context.BusinessMans.Add(bm));

            context.SaveChanges();

            base.Seed(context);
        }
    }
}