using Shop.BuisnessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer
{
    public class NotFoundError : IError
    {
        public ErrorCodes ErrorCode => throw new NotImplementedException();

        public IEnumerable<string> Errors => throw new NotImplementedException();

        public  NotFoundError(string v)
        {
             Console.WriteLine("Error", v);
        }

    }
}
