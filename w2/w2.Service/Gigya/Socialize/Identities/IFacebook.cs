using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using w2.Service.Gigya.Socialize.Identities;
using w2.Service.Gigya.Socialize.Identities.Facebook;

namespace w2.Service.Gigya.Socialize.Identities
{
    public class IFacebook : BaseRequest
    {
        [JsonProperty("provider")]
        public string Provider { get; set; }

        [JsonProperty("providerUID")]
        public string ProviderUID { get; set; }

        [JsonProperty("isLoginIdentity")]
        public bool IsLoginIdentity { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("photoURL")]
        public string PhotoURL { get; set; }

        [JsonProperty("thumbnailURL")]
        public string ThumbnailURL { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("age")]
        public string Age { get; set; }

        [JsonProperty("birthDay")]
        public string BirthDay { get; set; }

        [JsonProperty("birthMonth")]
        public string BirthMonth { get; set; }

        [JsonProperty("birthYear")]
        public string BirthYear { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("profileURL")]
        public string ProfileURL { get; set; }

        [JsonProperty("proxiedEmail")]
        public string ProxiedEmail { get; set; }

        [JsonProperty("allowsLogin")]
        public bool AllowsLogin { get; set; }

        [JsonProperty("isExpiredSession")]
        public bool IsExpiredSession { get; set; }

        [JsonProperty("bio")]
        public string Bio { get; set; }

        [JsonProperty("education")]
        public Education Education { get; set; }

        [JsonProperty("favorites")]
        public Favorites Favorites { get; set; }

        [JsonProperty("hometown")]
        public Hometown Hometown { get; set; }

        [JsonProperty("languages")]
        public string Languages { get; set; }

        [JsonProperty("likes")]
        public Like Likes { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("religion")]
        public string Religion { get; set; }

        [JsonProperty("timezone")]
        public int Timezone { get; set; }

        [JsonProperty("work")]
        public Work Work { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("certifications")]
        public Certification Certifications { get; set; }

        [JsonProperty("honors")]
        public string Honors { get; set; }

        [JsonProperty("industry")]
        public string Industry { get; set; }

        [JsonProperty("patents")]
        public Patent Patents { get; set; }

        [JsonProperty("publications")]
        public Publication[] Publications { get; set; }

        [JsonProperty("skills")]
        public Skill Skills { get; set; }

        [JsonProperty("specialties")]
        public string Specialties { get; set; }
    }
}
