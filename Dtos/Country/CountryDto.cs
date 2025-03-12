using Flag_Explorer_App.Dtos.CapitalInfo;
using Flag_Explorer_App.Dtos.CoatofArms;
using Flag_Explorer_App.Dtos.Currencies;
using Flag_Explorer_App.Dtos.Demonyms;
using Flag_Explorer_App.Dtos.Flags;
using Flag_Explorer_App.Dtos.Idd;
using Flag_Explorer_App.Dtos.Languages;
using Flag_Explorer_App.Dtos.Maps;
using Flag_Explorer_App.Dtos.Names;
using Flag_Explorer_App.Dtos.Translations;

namespace Flag_Explorer_App.Dtos.Country
{
    public class CountryDto
    {
        public NameDto Name { get; set; }
        public string Cca2 { get; set; }
        public string Cca3 { get; set; }
        public string Ccn3 { get; set; }
        public string Cioc { get; set; }
        public bool Independent { get; set; }
        public string Status { get; set; }
        public bool UnMember { get; set; }
        public CurrenciesDto Currencies { get; set; }
        public IddDto Idd { get; set; }
        public List<string> Capital { get; set; }
        public List<string> AltSpellings { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        public LanguagesDto Languages { get; set; }
        public TranslationsDto Translations { get; set; }
        public double? Area { get; set; }
        public DemonymsDto Demonyms { get; set; }
        public string Flag { get; set; }
        public MapsDto Maps { get; set; }
        public int Population { get; set; }
        public List<string> Timezones { get; set; }
        public List<string> Borders { get; set; }
        public string StartOfWeek { get; set; }
        public FlagsDto Flags { get; set; }
        public CoatOfArmsDto CoatOfArms { get; set; }
        public CapitalInfoDto CapitalInfo { get; set; }
    }
}
