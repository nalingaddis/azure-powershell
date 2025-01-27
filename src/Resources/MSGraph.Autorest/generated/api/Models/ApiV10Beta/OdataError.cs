// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10Beta
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Extensions;

    public partial class OdataError :
        Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10Beta.IOdataError,
        Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10Beta.IOdataErrorInternal
    {

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10Beta.IOdataErrorMain _error;

        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Origin(Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10Beta.IOdataErrorMain Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10Beta.OdataErrorMain()); set => this._error = value; }

        /// <summary>Creates an new <see cref="OdataError" /> instance.</summary>
        public OdataError()
        {

        }
    }
    public partial interface IOdataError :
        Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.IAssociativeArray<global::System.Object>
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"",
        SerializedName = @"error",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10Beta.IOdataErrorMain) })]
        Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10Beta.IOdataErrorMain Error { get; set; }

    }
    internal partial interface IOdataErrorInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10Beta.IOdataErrorMain Error { get; set; }

    }
}