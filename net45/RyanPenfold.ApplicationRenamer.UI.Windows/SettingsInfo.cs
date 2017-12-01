// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingsInfo.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.ApplicationRenamer.UI.Windows
{
    /// <summary>
    /// Provides settings information
    /// </summary>
    public class SettingsInfo : ISettingsInfo
    {
        /// <summary>
        /// Gets or sets a value indicating whether
        /// the search and replace strings are case-sensitive
        /// </summary>
        public bool? CaseSensitive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// the files' content should be searched and replaced.
        /// </summary>
        public bool FileContent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// the objects' names should be searched and replaced.
        /// </summary>
        public bool FileNames { get; set; }

        /// <summary>
        /// Gets or sets the "from" string.
        /// </summary>
        public string FromText { get; set; }

        /// <summary>
        /// Gets or sets the path to the root directory.
        /// </summary>
        public string RootDirectoryPath { get; set; }

        /// <summary>
        /// Gets or sets the "to" string.
        /// </summary>
        public string ToText { get; set; }
    }
}
