using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefeatYourOpponent.Domain.Entities
{
    public class QueueTypeEntity
    {
        public int QueueId { get; private set; }
        public string Map { get; private set; }
        public string Description { get; private set; }
        public string Notes { get; private set; }

        public QueueTypeEntity(int queueId, string map, string description, string notes)
        {
            QueueId = queueId;
            Map = map;
            Description = description;
            Notes = notes;
        }
    }
}
