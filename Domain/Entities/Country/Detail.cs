using Flag_Explorer_App.Domain.Entities.Base;

namespace Flag_Explorer_App.Domain.Entities.Country
{
    public class CountryDetail : AuditableEntity
    {
        public string CommonName { get; set; }

        public string OfficialName { get; set; }

        public string Alpha2Code { get; set; }

        public string Alpha3Code { get; set; }

        public int Population { get; set; }

    }
}
