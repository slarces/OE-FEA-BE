using Flag_Explorer_App.Domain.Entities.Base;

namespace Flag_Explorer_App.Domain.Entities.Country
{
    public class CountryLocation : AuditableEntity
    {
        public Guid CountryDetailId { get; set; }
        public virtual CountryDetail CountryDetail { get; set; }

        public string Region { get; set; }

        public string SubRegion { get; set; }

        public List<string> Capital { get; set; }

        public Maps MapAddresses { get; set; }

    }

    public class Maps : AuditableEntity
    {
        public Guid CountryLocationId { get; set; }
        public virtual CountryLocation CountryLocation { get; set; }

        public string GoogleMaps { get; set; }
        public string OpenStreetMaps { get; set; }
    }
}
