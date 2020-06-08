﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information
#region Usings

using System.Web;
using System.Web.UI.WebControls;

using DotNetNuke.Common.Utilities;

#endregion

namespace DotNetNuke.UI.WebControls
{
    /// -----------------------------------------------------------------------------
    /// Project:    DotNetNuke
    /// Namespace:  DotNetNuke.UI.WebControls
    /// Class:      CheckBoxColumn
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The CheckBoxColumn control provides a Check Box column for a Data Grid
    /// </summary>
    /// -----------------------------------------------------------------------------
    public class CheckBoxColumn : TemplateColumn
    {
		#region "Private Members"

        private bool mAutoPostBack = true;
        private string mDataField = Null.NullString;
        private bool mEnabled = true;
        private string mEnabledField = Null.NullString;
        private bool mHeaderCheckBox = true;
		
		#endregion

		#region "Constructors"

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Constructs the CheckBoxColumn
        /// </summary>
        /// -----------------------------------------------------------------------------
        public CheckBoxColumn() : this(false)
        {
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Constructs the CheckBoxColumn, with an optional AutoPostBack (where each change
        /// of state of a check box causes a Post Back)
        /// </summary>
        /// <param name="autoPostBack">Optional set the checkboxes to postback</param>
        /// -----------------------------------------------------------------------------
        public CheckBoxColumn(bool autoPostBack)
        {
            AutoPostBack = autoPostBack;
        }
		
		#endregion
		
		#region "Public Properties"


        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets and sets whether the column fires a postback when any check box is 
        /// changed
        /// </summary>
        /// <value>A Boolean</value>
        /// -----------------------------------------------------------------------------
        public bool AutoPostBack
        {
            get
            {
                return mAutoPostBack;
            }
            set
            {
                mAutoPostBack = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets and sets whether the checkbox is checked (unless DataBound) 
        /// </summary>
        /// <value>A Boolean</value>
        /// -----------------------------------------------------------------------------
        public bool Checked { get; set; }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// The Data Field that the column should bind to
        /// changed
        /// </summary>
        /// <value>A Boolean</value>
        /// -----------------------------------------------------------------------------
        public string DataField
        {
            get
            {
                return mDataField;
            }
            set
            {
                mDataField = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// An flag that indicates whether the checkboxes are enabled (this is overridden if
        /// the EnabledField is set)
        /// changed
        /// </summary>
        /// <value>A Boolean</value>
        /// -----------------------------------------------------------------------------
        public bool Enabled
        {
            get
            {
                return mEnabled;
            }
            set
            {
                mEnabled = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// The Data Field that determines whether the checkbox is Enabled
        /// changed
        /// </summary>
        /// <value>A String</value>
        /// -----------------------------------------------------------------------------
        public string EnabledField
        {
            get
            {
                return mEnabledField;
            }
            set
            {
                mEnabledField = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// A flag that indicates whether there is a checkbox in the Header that sets all
        /// the checkboxes
        /// </summary>
        /// <value>A Boolean</value>
        /// -----------------------------------------------------------------------------
        public bool HeaderCheckBox
        {
            get
            {
                return mHeaderCheckBox;
            }
            set
            {
                mHeaderCheckBox = value;
            }
        }
		
		#endregion

		#region "Events"

        public event DNNDataGridCheckedColumnEventHandler CheckedChanged;
		
		#endregion

		#region "Private Methods"

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Creates a CheckBoxColumnTemplate
        /// </summary>
        /// <returns>A CheckBoxColumnTemplate</returns>
        /// -----------------------------------------------------------------------------
        private CheckBoxColumnTemplate CreateTemplate(ListItemType type)
        {
            bool isDesignMode = false;
            if (HttpContext.Current == null)
            {
                isDesignMode = true;
            }
            var template = new CheckBoxColumnTemplate(type);
            if (type != ListItemType.Header)
            {
                template.AutoPostBack = AutoPostBack;
            }
            template.Checked = Checked;
            template.DataField = DataField;
            template.Enabled = Enabled;
            template.EnabledField = EnabledField;
            template.CheckedChanged += OnCheckedChanged;
            if (type == ListItemType.Header)
            {
                template.Text = HeaderText;
                template.AutoPostBack = true;
                template.HeaderCheckBox = HeaderCheckBox;
            }
            template.DesignMode = isDesignMode;
            return template;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Centralised Event that is raised whenever a check box is changed.
        /// </summary>
        /// -----------------------------------------------------------------------------
        private void OnCheckedChanged(object sender, DNNDataGridCheckChangedEventArgs e)
        {
            //Add the column to the Event Args
            e.Column = this;
            if (CheckedChanged != null)
            {
                CheckedChanged(sender, e);
            }
        }
		
		#endregion

		#region "Public Methods"

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initialises the Column
        /// </summary>
        /// -----------------------------------------------------------------------------
        public override void Initialize()
        {
            ItemTemplate = CreateTemplate(ListItemType.Item);
            EditItemTemplate = CreateTemplate(ListItemType.EditItem);
            HeaderTemplate = CreateTemplate(ListItemType.Header);
            if (HttpContext.Current == null)
            {
                HeaderStyle.Font.Names = new[] {"Tahoma, Verdana, Arial"};
                HeaderStyle.Font.Size = new FontUnit("10pt");
                HeaderStyle.Font.Bold = true;
            }
            ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
        }
		
		#endregion
    }
}
