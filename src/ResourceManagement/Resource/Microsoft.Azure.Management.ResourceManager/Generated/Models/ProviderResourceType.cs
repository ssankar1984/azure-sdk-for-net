// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.14.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.ResourceManager.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Resource type managed by the resource provider.
    /// </summary>
    public partial class ProviderResourceType
    {
        /// <summary>
        /// Initializes a new instance of the ProviderResourceType class.
        /// </summary>
        public ProviderResourceType() { }

        /// <summary>
        /// Initializes a new instance of the ProviderResourceType class.
        /// </summary>
        public ProviderResourceType(string resourceType = default(string), IList<string> locations = default(IList<string>), IList<AliasType> aliases = default(IList<AliasType>), IList<string> apiVersions = default(IList<string>), IDictionary<string, string> properties = default(IDictionary<string, string>))
        {
            ResourceType = resourceType;
            Locations = locations;
            Aliases = aliases;
            ApiVersions = apiVersions;
            Properties = properties;
        }

        /// <summary>
        /// The resource type.
        /// </summary>
        [JsonProperty(PropertyName = "resourceType")]
        public string ResourceType { get; set; }

        /// <summary>
        /// The collection of locations where this resource type can be
        /// created in.
        /// </summary>
        [JsonProperty(PropertyName = "locations")]
        public IList<string> Locations { get; set; }

        /// <summary>
        /// The aliases that are supported by this resource type.
        /// </summary>
        [JsonProperty(PropertyName = "aliases")]
        public IList<AliasType> Aliases { get; set; }

        /// <summary>
        /// The api version.
        /// </summary>
        [JsonProperty(PropertyName = "apiVersions")]
        public IList<string> ApiVersions { get; set; }

        /// <summary>
        /// The properties.
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public IDictionary<string, string> Properties { get; set; }

    }
}
