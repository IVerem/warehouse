using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.AccountManagement;
// Made by Rasmus Overgaard
namespace Auth
{
    public class Auth
    {
        // Opretter metoden "IsUserMemberOfGroup".
        public static bool IsUserMemberOfGroup(string username, string groupname)
        {
            var foundUser = false;
            // Definere at vi skal forbinde til vores Domain.
            var context = new PrincipalContext(ContextType.Domain, "prod.ucnstud.local", "DC=prod, DC=ucnstud,DC=local");
            var group = GroupPrincipal.FindByIdentity(context, groupname);

            // Foreach loop'et gennemgår gruppen defineret længere oppe og tjekker om vores "string username" er en del af den gruppe
            // Hvis brugeren findes, stoppes foreach loopet
            foreach (var member in group.GetMembers(true))
            {
                    if (member.SamAccountName.Equals(username))
                    {
                        foundUser = true;
                        break;
                    }
            }
            group.Dispose();
            context.Dispose();
            return foundUser;
        }

        // Metode der kalder metoden "IsUserMemberOfGroup"
        public static bool UserCheck(string u1, string g1)
        {
            bool found = false;

            if (Auth.IsUserMemberOfGroup(u1, g1))
            {
                found = true;
            }
            return found;
        }
    }
}
