namespace Flag_Explorer_App.Dtos.Names
{
    public class NameDto
    {
        public string Common { get; set; }
        public string Official { get; set; }
        public Dictionary<string, NativeNameDto> NativeName { get; set; }
    }
}
