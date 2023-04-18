using WS2023.Models.Entity;

namespace WS2023.Models.RequestModels.Events
{
    public class PersonalVisitModel
    {
        public DateTime? DateStart { get; set; }

        public DateTime? DateFinish { get; set; }

        public int? Visitor { get; set; }

        public int? Purpose { get; set; }

        public int? Division { get; set; }

        public int? Worker { get; set; }

        public string? Surname { get; set; } = null!;

        public string? Name { get; set; } = null!;

        public string? Patronymic { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; } = null!;

        public string? Organization { get; set; }

        public string? Description { get; set; }

        public DateTime? Birthday { get; set; }

        public string? SeriaPassport { get; set; } = null!;

        public string? NumberPassport { get; set; } = null!;

        public byte[]? ScanPassport { get; set; } = null!;

        public PersonalVisitModel(DateTime dateStart, DateTime dateFinish, int visitor, int purpose, int division, int worker, string surname, string name, string? patronymic, string? phoneNumber, string email, string? organization, string? description, DateTime birthday, string seriaPassport, string numberPassport, byte[] scanPassport)
        {
            DateStart = dateStart;
            DateFinish = dateFinish;
            Visitor = visitor;
            Purpose = purpose;
            Division = division;
            Worker = worker;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            PhoneNumber = phoneNumber;
            Email = email;
            Organization = organization;
            Description = description;
            Birthday = birthday;
            SeriaPassport = seriaPassport;
            NumberPassport = numberPassport;
            ScanPassport = scanPassport;
        }

        public PersonalVisitModel() { }

        public PersonalVisit toPersonalVisit()
        {
            PersonalVisit personalVisit = new PersonalVisit();
            personalVisit.DateStart = DateStart;
            personalVisit.DateFinish = DateFinish;
            personalVisit.Visitor = Visitor;
            personalVisit.Purpose = Purpose;
            personalVisit.Worker = Worker;
            personalVisit.Surname = Surname;
            personalVisit.Name = Name;
            personalVisit.Patronymic = Patronymic;
            personalVisit.PhoneNumber = PhoneNumber;
            personalVisit.Email = Email;
            personalVisit.Organization = Organization;
            personalVisit.Description = Description;
            personalVisit.Birthday = Birthday;
            personalVisit.SeriaPassport = SeriaPassport;
            personalVisit.NumberPassport = NumberPassport;
            personalVisit.ScanPassport = ScanPassport;

            return personalVisit;
        }
    }
}
