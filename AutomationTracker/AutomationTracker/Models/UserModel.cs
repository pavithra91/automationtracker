using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutomationTracker.Models
{
    public class UserModel
    {
        public User user { get; set; }
        public bool IsUserActive { get; set; }
        public UserList userList { get; set; }
    }
    public class UserList
    {
        public List<Company> companyList { get; set; }
        public List<Market> marketList { get; set; }
        public List<User> usrList { get; set; }
        public List<UserTitle> titlelist { get; set; }
    }
    public class UserTitle
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public List<UserTitle> GetAllTitles()
        {
            List<UserTitle> titlelist = new List<UserTitle>();
            titlelist.Add(new UserTitle
            {
                ID=1,
                Title = "Mr."
            });
            titlelist.Add(new UserTitle
            {
                ID = 2,
                Title = "Mrs."
            });
            titlelist.Add(new UserTitle
            {
                ID = 3,
                Title = "Miss."
            });
            titlelist.Add(new UserTitle
            {
                ID = 4,
                Title = "Dr."
            });
            titlelist.Add(new UserTitle
            {
                ID = 5,
                Title = "Rev."
            });
            return titlelist;
        }
    }
}