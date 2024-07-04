using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Interfaces
{
    public interface IapiLogger<T> 
    {
        void loadInformation(string message,params object[] args);
        void loadWarning(string message,params object[] args);
        void loadError(string message,params object[] args);
    }
}
