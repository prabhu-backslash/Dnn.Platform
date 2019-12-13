﻿#region Usings

using Newtonsoft.Json;

#endregion

namespace Dnn.PersonaBar.SiteSettings.Services.Dto
{
    public class UpdateMessagingSettingsRequest
    {
        public int? PortalId { get; set; }

        public string CultureCode { get; set; }

        public bool DisablePrivateMessage { get; set; }

        public double ThrottlingInterval { get; set; }

        public int RecipientLimit { get; set; }

        public bool AllowAttachments { get; set; }

        public bool ProfanityFilters { get; set; }

        public bool IncludeAttachments { get; set; }

        public bool SendEmail { get; set; }
    }
}
