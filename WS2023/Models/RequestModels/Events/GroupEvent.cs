using System.Collections;
using System.Collections.Generic;
using WS2023.Models.Entity;

namespace WS2023.Models.RequestModels.Events
{
    public class GroupEvent
    {
        public PersonalVisitModel personalVisit { get; set; }
        public List<GroupVisit> groupVisit { get; set; }

        public GroupEvent() { }

        public GroupEvent(PersonalVisitModel personalVisit, List<GroupVisit> groupVisit)
        {
            this.personalVisit = personalVisit;
            this.groupVisit = groupVisit;
        }
    }
}
