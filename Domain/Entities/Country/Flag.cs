using Flag_Explorer_App.Domain.Entities.Base;

namespace Flag_Explorer_App.Domain.Entities.Country
{
    public class CountryFlag : AuditableEntity
    {
        public Guid CountryDetailId { get; set; }
        public virtual CountryDetail CountryDetail { get; set; }

        public string FlagCode { get; set; }

        public string Png {  get; set; }

        public string Svg { get; set; }
    }
}
