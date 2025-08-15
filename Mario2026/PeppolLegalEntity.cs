namespace Mario2026
{
    public sealed class CreateLegalEntityRequest
    {
        public LegalEntityDetails LegalEntityDetails { get; set; } = new();
        public List<PeppolRegistrationX> PeppolRegistrations { get; set; } = [];
    }

    public sealed class LegalEntityDetails
    {
        public bool PublishInPeppolDirectory { get; set; }
        public string? Name { get; set; }
        public string? CountryCode { get; set; }
        public string? GeographicalInformation { get; set; }
        public string? WebsiteURL { get; set; }
        public List<Contact> Contacts { get; set; } = [];
        public string? AdditionalInformation { get; set; }
    }

    public sealed class Contact
    {
        public string? ContactType { get; set; } // e.g., "public"
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }

    public sealed class PeppolRegistrationX
    {
        public PeppolIdentifier PeppolIdentifier { get; set; } = new();
        public List<string> SupportedDocuments { get; set; } = [];
        public bool PeppolRegistration { get; set; }
    }

    public sealed class PeppolIdentifier
    {
        public string? Scheme { get; set; }      // e.g., "0208"
        public string? Identifier { get; set; }  // e.g., "0430094832"
    }

}
