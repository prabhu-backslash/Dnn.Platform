﻿#region Usings

using System;

#endregion

namespace DotNetNuke.UI.WebControls
{
    /// -----------------------------------------------------------------------------
    /// Project:    DotNetNuke
    /// Namespace:  DotNetNuke.UI.WebControls
    /// Class:      PropertyEditorItemEventArgs
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The PropertyEditorItemEventArgs class is a cusom EventArgs class for
    /// handling Event Args
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// -----------------------------------------------------------------------------
    public class PropertyEditorItemEventArgs : EventArgs
    {
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Constructs a new PropertyEditorItemEventArgs
        /// </summary>
        /// <param name="editor">The editor created</param>
        /// -----------------------------------------------------------------------------
        public PropertyEditorItemEventArgs(EditorInfo editor)
        {
            Editor = editor;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets and sets whether the proeprty has changed
        /// </summary>
        /// <value>A String</value>
        /// -----------------------------------------------------------------------------
        public EditorInfo Editor { get; set; }
    }
}
