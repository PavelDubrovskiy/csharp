using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Common
{
    public enum OperationCode : short
    {
        Ok = 1,
        UnhandledError = 2,
        ValidationError = 3,
        UserBlocked = 4,
        EntityWasNotFound = 5,
        SendEmailError = 6
    }
}
