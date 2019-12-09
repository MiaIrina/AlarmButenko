using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Tools.Exceptions
{
    class UserExistsException:FormatException
    {
        public UserExistsException() : base("This user already exists")
    {

    }

}
}
