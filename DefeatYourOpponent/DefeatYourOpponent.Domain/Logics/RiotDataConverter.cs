using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefeatYourOpponent.Domain.Logics
{
    public static class RiotDataConverter
    {
        public static string QueueIdToString(long queueId)
        {
            switch (queueId)
            {
                case 420: return "Ranked Solo";
                case 490: return "Normal";
                default: throw new ArgumentException("QueueId不正");
            }
        }

        public static string WinToString(bool win)
        {
            if (win)
            {
                return "WIN";
            }
            else
            {
                return "LOSE";
            }
        }
    }
}
