using System.ComponentModel;

namespace NimbusWebJob.Web.ViewModels
{
    public class IndexInputModel
    {
        [DisplayName("Given Name")]
        public string GivenName { get; set; }

        [DisplayName("Family Name")]
        public string FamilyName { get; set; }

        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }
    }
}