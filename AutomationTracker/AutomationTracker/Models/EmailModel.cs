using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutomationTracker.Models
{
    public class EmailModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public string EmailCC { get; set; }
        public string EmailBCC { get; set; }
        public List<PhoneDongle> DisposeList { get; set; }

        public void SendEmail(EmailModel objEmail)
        {
            dynamic email = new Postal.Email("DisposeEmail");
            email.To = objEmail.To;
            email.From = objEmail.From;

            if (objEmail.EmailBCC != null)
            {
                email.Cc = objEmail.EmailCC;
            }
            if (objEmail.EmailCC != null)
            {
                email.Bcc = objEmail.EmailBCC;
            }

            email.DisposeList = objEmail.DisposeList;

            email.Send();

        }
    }
}