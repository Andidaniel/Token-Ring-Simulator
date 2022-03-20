using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retele_Token_Ring
{
    public class Token
    {
        #region Properties and Fields
        public string SourceAddress { get; set; }
        public string DestinationAddress { get; set; }
        public string Message { get; set; }
        public bool IsBusy { get; set; }
        public bool DestinationReached { get; set; }

        #endregion

        public Token()
        {
            SourceAddress = null;
            DestinationAddress = null;
            Message = null;
            IsBusy = false;
            DestinationReached = false;
        }




    }
}
