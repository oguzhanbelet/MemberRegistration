using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace DevFramework.Core.CrossCuttingConcerns.Security.Web
{
    public class SecurityUtilities
    {
        public Identity FormsAuthTicketToIdentity(FormsAuthenticationTicket ticket)
        {
            var identity = new Identity
            {
                Id=SetId(ticket),
                Name = SetName(ticket),
                Email = SetEmail(ticket),
                Roles = setRoles(ticket),
                FirstName = setFirstName(ticket),
                LastName = setLastName(ticket),
                AuthenticationType = SetAuthType(),
                IsAuthenticated = SetIsAuthenticated()
            };
            return identity;
        }

        private bool SetIsAuthenticated()
        {
            return true;
        }

        private string SetAuthType()
        {
            return "Forms";
        }

        private string setLastName(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[3];
        }

        private string setFirstName(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[2];
        }

        private string[] setRoles(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            string[] roles = data[1].Split(new char[] { ',' },StringSplitOptions.RemoveEmptyEntries);
            return roles;
        }

        private string SetEmail(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[0];
        }

        private string SetName(FormsAuthenticationTicket ticket)
        {
            return ticket.Name;
        }

        private Guid SetId(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return new Guid(data[4]);

        }
    }
}
