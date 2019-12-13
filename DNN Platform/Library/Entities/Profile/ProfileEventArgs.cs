﻿using System;
using DotNetNuke.Entities.Users;

namespace DotNetNuke.Entities.Profile
{    
    public class ProfileEventArgs : EventArgs
    {
        /// <summary>
        /// The user whom's profile has been changed. This includes the Profile property with the updated profile
        /// </summary>
        public UserInfo User { get; set; }

        /// <summary>
        /// The user's profile, as it was before the change
        /// </summary>
        public UserProfile OldProfile { get; set; }
    }
}
