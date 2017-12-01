// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISettingsInfo.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.ApplicationRenamer.UI.Windows
{
    /// <summary>
    /// Provides an interface for types that provide settings information.
    /// </summary>
    public interface ISettingsInfo
    {
        /// <summary>
        /// Gets or sets a value indicating whether
        /// the search and replace strings are case-sensitive
        /// </summary>
        bool? CaseSensitive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// the files' content should be searched and replaced.
        /// </summary>
        bool FileContent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// the objects' names should be searched and replaced.
        /// </summary>
        bool FileNames { get; set; }

        /// <summary>
        /// Gets or sets the "from" string.
        /// </summary>
        string FromText { get; set; }

        /// <summary>
        /// Gets or sets the path to the root directory.
        /// </summary>
        string RootDirectoryPath { get; set; }

        /// <summary>
        /// Gets or sets the "to" string.
        /// </summary>
        string ToText { get; set; }
    }
}
