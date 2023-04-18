using WS2023.Models.Entity;

namespace WS2023.Models.RequestModels.Events
{
    public class DataRegEvent
    {
        public List<Purpose> purpose { get; set; }
        public List<Division> division { get; set; }

        public List<Worker> worker { get; set; }
        
        public DataRegEvent() { }
        public DataRegEvent(List<Purpose> purpose, List<Division> division, List<Worker> worker)
        {
            this.purpose = purpose;
            this.division = division;
            this.worker = worker;
        }
    }
}
