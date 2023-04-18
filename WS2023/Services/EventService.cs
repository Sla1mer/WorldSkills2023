using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WS2023.Models.Entity;
using WS2023.Models.RequestModels;
using WS2023.Models.RequestModels.Events;

namespace WS2023.Services
{
    public class EventService
    {
        private Ws2023Context Ws2023Context = new Ws2023Context();

        public async Task<RequestResponse> getDataForRegistrationEvent()
        {
            DataRegEvent dataRegEvent = new DataRegEvent();
            dataRegEvent.purpose = await Ws2023Context.Purposes.ToListAsync();
            dataRegEvent.division = await Ws2023Context.Divisions.ToListAsync();
            dataRegEvent.worker = await Ws2023Context.Workers.ToListAsync();
            return new RequestResponse(200, JsonConvert.SerializeObject(dataRegEvent));
        }

        public async Task<RequestResponse> RegistrationPesonalEvent(PersonalVisitModel personalVisitModel)
        {
            PersonalVisit personalVisit = personalVisitModel.toPersonalVisit();

            await Ws2023Context.PersonalVisits.AddAsync(personalVisit);

            await Ws2023Context.SaveChangesAsync();

            int personalId = Ws2023Context.PersonalVisits
                .Where(u => u.NumberPassport == personalVisit.NumberPassport).ToListAsync().Result.Last().Id;

            StatusesVisit statusesVisit = new StatusesVisit();
            statusesVisit.Status = 0;
            statusesVisit.PersonalVisit = personalId;
            await Ws2023Context.StatusesVisits.AddAsync(statusesVisit);

            await Ws2023Context.SaveChangesAsync();
            return new RequestResponse(201, "Вы успешно записались.");
        }

        public async Task<RequestResponse> RegistrationGroupEvent(GroupEvent groupEvent)
        {
            await Ws2023Context.PersonalVisits.AddAsync(groupEvent.personalVisit.toPersonalVisit());

            await Ws2023Context.SaveChangesAsync();

            int personalId = Ws2023Context.PersonalVisits
                .Where(u => u.NumberPassport == groupEvent.personalVisit.NumberPassport).ToListAsync().Result.Last().Id;

            foreach (GroupVisit groupVisit in groupEvent.groupVisit)
            {
                groupVisit.ParentVisit = personalId;
            }

            await Ws2023Context.GroupVisits.AddRangeAsync(groupEvent.groupVisit);

            StatusesVisit statusesVisit = new StatusesVisit();
            statusesVisit.Status = 0;
            statusesVisit.PersonalVisit = personalId;
            await Ws2023Context.StatusesVisits.AddAsync(statusesVisit);

            await Ws2023Context.SaveChangesAsync();
            return new RequestResponse(201, "Вы успешно записались.");
        }
    }
}
