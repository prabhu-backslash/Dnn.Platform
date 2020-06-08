﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information
#region Usings

using System;
using System.Collections;
using System.Web;
using Microsoft.Extensions.DependencyInjection;

using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Host;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Users;
using DotNetNuke.Entities.Users.Membership;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Instrumentation;
using DotNetNuke.Security;
using DotNetNuke.Security.Membership;
using DotNetNuke.Services.Localization;
using DotNetNuke.Services.Log.EventLog;
using DotNetNuke.Services.Mail;
using DotNetNuke.UI.Skins.Controls;
using DotNetNuke.Services.UserRequest;
using DotNetNuke.Abstractions;

#endregion

namespace DotNetNuke.Modules.Admin.Security
{

    using Host = DotNetNuke.Entities.Host.Host;

    /// <summary>
    /// The SendPassword UserModuleBase is used to allow a user to retrieve their password
    /// </summary>
    /// <remarks>
    /// </remarks>
    public partial class SendPassword : UserModuleBase
    {
    	private static readonly ILog Logger = LoggerSource.Instance.GetLogger(typeof (SendPassword));
        private readonly INavigationManager _navigationManager;
        public SendPassword()
        {
            _navigationManager = DependencyProvider.GetRequiredService<INavigationManager>();
        }

        #region Private Members

        private UserInfo _user;
        private int _userCount = Null.NullInteger;
        private string _ipAddress;

        #endregion

        #region Protected Properties

        /// <summary>
        /// Gets the Redirect URL (after successful sending of password)
        /// </summary>
        protected string RedirectURL
        {
            get
            {
                var _RedirectURL = "";

                object setting = GetSetting(PortalId, "Redirect_AfterRegistration");

                if (Convert.ToInt32(setting) > 0) //redirect to after registration page
                {
                    _RedirectURL = _navigationManager.NavigateURL(Convert.ToInt32(setting));
                }
                else
                {

                if (Convert.ToInt32(setting) <= 0)
                {
                    if (Request.QueryString["returnurl"] != null)
                    {
                        //return to the url passed to register
                        _RedirectURL = HttpUtility.UrlDecode(Request.QueryString["returnurl"]);

                        //clean the return url to avoid possible XSS attack.
                        _RedirectURL = UrlUtils.ValidReturnUrl(_RedirectURL);

                        if (_RedirectURL.Contains("?returnurl"))
                        {
                            string baseURL = _RedirectURL.Substring(0,
                                _RedirectURL.IndexOf("?returnurl", StringComparison.Ordinal));
                            string returnURL =
                                _RedirectURL.Substring(_RedirectURL.IndexOf("?returnurl", StringComparison.Ordinal) + 11);

                            _RedirectURL = string.Concat(baseURL, "?returnurl", HttpUtility.UrlEncode(returnURL));
                        }
                    }
                    if (String.IsNullOrEmpty(_RedirectURL))
                    {
                        //redirect to current page
                        _RedirectURL = _navigationManager.NavigateURL();
                    }
                }
                else //redirect to after registration page
                {
                    _RedirectURL = _navigationManager.NavigateURL(Convert.ToInt32(setting));
                }
                }

                return _RedirectURL;
            }

		}

        /// <summary>
        /// Gets whether the Captcha control is used to validate the login
        /// </summary>
        protected bool UseCaptcha
        {
            get
            {
                var setting = GetSetting(PortalId, "Security_CaptchaRetrivePassword");
                return Convert.ToBoolean(setting);
            }
        }

	    protected bool UsernameDisabled
	    {
		    get
		    {
				return PortalController.GetPortalSettingAsBoolean("Registration_UseEmailAsUserName", PortalId, false);
		    }
	    }

	    private bool ShowEmailField
	    {
		    get
		    {
			    return MembershipProviderConfig.RequiresUniqueEmail || UsernameDisabled;
		    }
	    }

        #endregion

        #region Private Methods

        private void GetUser()
        {
            ArrayList arrUsers;
			if (ShowEmailField && !String.IsNullOrEmpty(txtEmail.Text.Trim()) && (String.IsNullOrEmpty(txtUsername.Text.Trim()) || divUsername.Visible == false))
            {
                arrUsers = UserController.GetUsersByEmail(PortalSettings.PortalId, txtEmail.Text, 0, Int32.MaxValue, ref _userCount);
                if (arrUsers != null && arrUsers.Count == 1)
                {
                    _user = (UserInfo)arrUsers[0];
                }
            }
            else
            {
                _user = UserController.GetUserByName(PortalSettings.PortalId, txtUsername.Text);
            }
        }

        #endregion

        #region Event Handlers

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            var isEnabled = true;

            //both retrieval and reset now use password token resets
            if (MembershipProviderConfig.PasswordRetrievalEnabled || MembershipProviderConfig.PasswordResetEnabled)
            {
                lblHelp.Text = Localization.GetString("ResetTokenHelp", LocalResourceFile);
                cmdSendPassword.Text = Localization.GetString("ResetToken", LocalResourceFile);
            }
            else
            {
                isEnabled = false;
                lblHelp.Text = Localization.GetString("DisabledPasswordHelp", LocalResourceFile);
                divPassword.Visible = false;
            }

			if (!MembershipProviderConfig.PasswordResetEnabled)
            {
                isEnabled = false;
                lblHelp.Text = Localization.GetString("DisabledPasswordHelp", LocalResourceFile);
                divPassword.Visible = false;
            }

            if (MembershipProviderConfig.RequiresUniqueEmail && isEnabled && !PortalController.GetPortalSettingAsBoolean("Registration_UseEmailAsUserName", PortalId, false))
            {
                lblHelp.Text += Localization.GetString("RequiresUniqueEmail", LocalResourceFile);
            }

            if (MembershipProviderConfig.RequiresQuestionAndAnswer && isEnabled)
            {
                lblHelp.Text += Localization.GetString("RequiresQuestionAndAnswer", LocalResourceFile);
            }


        }

        /// <summary>
        /// Page_Load runs when the control is loaded
        /// </summary>
        /// <remarks>
        /// </remarks>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            cmdSendPassword.Click += OnSendPasswordClick;
            lnkCancel.NavigateUrl = _navigationManager.NavigateURL();

            _ipAddress = UserRequestIPAddressController.Instance.GetUserRequestIPAddress(new HttpRequestWrapper(Request));

			divEmail.Visible = ShowEmailField;
			divUsername.Visible = !UsernameDisabled;
            divCaptcha.Visible = UseCaptcha;

            if (UseCaptcha)
            {
                ctlCaptcha.ErrorMessage = Localization.GetString("InvalidCaptcha", LocalResourceFile);
                ctlCaptcha.Text = Localization.GetString("CaptchaText", LocalResourceFile);
            }
        }

        /// <summary>
        /// cmdSendPassword_Click runs when the Password Reminder button is clicked
        /// </summary>
        /// <remarks>
        /// </remarks>
        protected void OnSendPasswordClick(Object sender, EventArgs e)
        {
            //pretty much alwasy display the same message to avoid hinting on the existance of a user name
            var message = Localization.GetString("PasswordSent", LocalResourceFile);
            var moduleMessageType = ModuleMessage.ModuleMessageType.GreenSuccess;
            var canSend = true;

            if ((UseCaptcha && ctlCaptcha.IsValid) || (!UseCaptcha))
            {
                if (String.IsNullOrEmpty(txtUsername.Text.Trim()))
                {
                    //No UserName provided
                    if (ShowEmailField)
                    {
                        if (String.IsNullOrEmpty(txtEmail.Text.Trim()))
                        {
                            //No email address either (cannot retrieve password)
                            canSend = false;
                            message = Localization.GetString("EnterUsernameEmail", LocalResourceFile);
                            moduleMessageType = ModuleMessage.ModuleMessageType.RedError;
                        }
                    }
                    else
                    {
                        //Cannot retrieve password
                        canSend = false;
                        message = Localization.GetString("EnterUsername", LocalResourceFile);
                        moduleMessageType = ModuleMessage.ModuleMessageType.RedError;
                    }
                }

                if (string.IsNullOrEmpty(Host.SMTPServer))
                {
                    //SMTP Server is not configured
                    canSend = false;
                    message = Localization.GetString("OptionUnavailable", LocalResourceFile);
                    moduleMessageType = ModuleMessage.ModuleMessageType.YellowWarning;

                    var logMessage = Localization.GetString("SMTPNotConfigured", LocalResourceFile);

                    LogResult(logMessage);
                }

                if (canSend)
                {
                    GetUser();
                    if (_user != null)
                    {
                        if (_user.IsDeleted)
                        {
                            canSend = false;
                        }
                        else
                        {
                            if (_user.Membership.Approved == false)
                            {
                                Mail.SendMail(_user, MessageType.PasswordReminderUserIsNotApproved, PortalSettings);
                                canSend = false;
                            }
                            if (MembershipProviderConfig.PasswordRetrievalEnabled || MembershipProviderConfig.PasswordResetEnabled)
                            {
                                UserController.ResetPasswordToken(_user);
                            }
                            if (canSend)
                            {
                                if (Mail.SendMail(_user, MessageType.PasswordReminder, PortalSettings) != string.Empty)
                                {
                                    canSend = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (_userCount > 1)
                        {
                            message = Localization.GetString("MultipleUsers", LocalResourceFile);
                        }

                        canSend = false;
                    }

                    if (canSend)
                    {
                        LogSuccess();
                        lnkCancel.Attributes["resourcekey"] = "cmdClose";
                    }
                    else
                    {
                        LogFailure(message);
                    }

					//always hide panel so as to not reveal if username exists.
                    pnlRecover.Visible = false;
                    UI.Skins.Skin.AddModuleMessage(this, message, moduleMessageType);
                    liSend.Visible = false;
                    liCancel.Visible = true;
                }
                else
                {
                    UI.Skins.Skin.AddModuleMessage(this, message, moduleMessageType);
                }
            }
        }

        private void LogSuccess()
        {
            LogResult(string.Empty);
        }

        private void LogFailure(string reason)
        {
            LogResult(reason);
        }

        private void LogResult(string message)
        {
            var portalSecurity = PortalSecurity.Instance;

			var log = new LogInfo
            {
                LogPortalID = PortalSettings.PortalId,
                LogPortalName = PortalSettings.PortalName,
                LogUserID = UserId,
                LogUserName = portalSecurity.InputFilter(txtUsername.Text, PortalSecurity.FilterFlag.NoScripting | PortalSecurity.FilterFlag.NoAngleBrackets | PortalSecurity.FilterFlag.NoMarkup)
            };

            if (string.IsNullOrEmpty(message))
            {
                log.LogTypeKey = "PASSWORD_SENT_SUCCESS";
            }
            else
            {
                log.LogTypeKey = "PASSWORD_SENT_FAILURE";
                log.LogProperties.Add(new LogDetailInfo("Cause", message));
            }

			log.AddProperty("IP", _ipAddress);

            LogController.Instance.AddLog(log);

        }

        #endregion

    }
}
