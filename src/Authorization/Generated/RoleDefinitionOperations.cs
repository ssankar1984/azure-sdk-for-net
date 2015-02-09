// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Authorization.Models;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Management.Authorization
{
    /// <summary>
    /// TBD  (see http://TBD for more information)
    /// </summary>
    internal partial class RoleDefinitionOperations : IServiceOperations<AuthorizationManagementClient>, IRoleDefinitionOperations
    {
        /// <summary>
        /// Initializes a new instance of the RoleDefinitionOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal RoleDefinitionOperations(AuthorizationManagementClient client)
        {
            this._client = client;
        }
        
        private AuthorizationManagementClient _client;
        
        /// <summary>
        /// Gets a reference to the
        /// Microsoft.Azure.Management.Authorization.AuthorizationManagementClient.
        /// </summary>
        public AuthorizationManagementClient Client
        {
            get { return this._client; }
        }
        
        /// <summary>
        /// Get role definition by name (GUID).
        /// </summary>
        /// <param name='roleDefinitionName'>
        /// Required. Role definition name (GUID).
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Role definition get operation result.
        /// </returns>
        public async Task<RoleDefinitionGetResult> GetAsync(Guid roleDefinitionName, CancellationToken cancellationToken)
        {
            // Validate
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("roleDefinitionName", roleDefinitionName);
                TracingAdapter.Enter(invocationId, this, "GetAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/subscriptions/";
            if (this.Client.Credentials.SubscriptionId != null)
            {
                url = url + Uri.EscapeDataString(this.Client.Credentials.SubscriptionId);
            }
            url = url + "/providers/Microsoft.Authorization/roleDefinitions/";
            url = url + Uri.EscapeDataString(roleDefinitionName.ToString());
            List<string> queryParameters = new List<string>();
            queryParameters.Add("api-version=2014-10-01-preview");
            if (queryParameters.Count > 0)
            {
                url = url + "?" + string.Join("&", queryParameters);
            }
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-version", "2014-10-01-preview");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    RoleDefinitionGetResult result = null;
                    // Deserialize Response
                    if (statusCode == HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = new RoleDefinitionGetResult();
                        JToken responseDoc = null;
                        if (string.IsNullOrEmpty(responseContent) == false)
                        {
                            responseDoc = JToken.Parse(responseContent);
                        }
                        
                        if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                        {
                            RoleDefinition roleDefinitionInstance = new RoleDefinition();
                            result.RoleDefinition = roleDefinitionInstance;
                            
                            JToken idValue = responseDoc["id"];
                            if (idValue != null && idValue.Type != JTokenType.Null)
                            {
                                string idInstance = ((string)idValue);
                                roleDefinitionInstance.Id = idInstance;
                            }
                            
                            JToken nameValue = responseDoc["name"];
                            if (nameValue != null && nameValue.Type != JTokenType.Null)
                            {
                                Guid nameInstance = Guid.Parse(((string)nameValue));
                                roleDefinitionInstance.Name = nameInstance;
                            }
                            
                            JToken typeValue = responseDoc["type"];
                            if (typeValue != null && typeValue.Type != JTokenType.Null)
                            {
                                string typeInstance = ((string)typeValue);
                                roleDefinitionInstance.Type = typeInstance;
                            }
                            
                            JToken propertiesValue = responseDoc["properties"];
                            if (propertiesValue != null && propertiesValue.Type != JTokenType.Null)
                            {
                                RoleDefinitionProperties propertiesInstance = new RoleDefinitionProperties();
                                roleDefinitionInstance.Properties = propertiesInstance;
                                
                                JToken roleNameValue = propertiesValue["roleName"];
                                if (roleNameValue != null && roleNameValue.Type != JTokenType.Null)
                                {
                                    string roleNameInstance = ((string)roleNameValue);
                                    propertiesInstance.RoleName = roleNameInstance;
                                }
                                
                                JToken descriptionValue = propertiesValue["description"];
                                if (descriptionValue != null && descriptionValue.Type != JTokenType.Null)
                                {
                                    string descriptionInstance = ((string)descriptionValue);
                                    propertiesInstance.Description = descriptionInstance;
                                }
                                
                                JToken scopeValue = propertiesValue["scope"];
                                if (scopeValue != null && scopeValue.Type != JTokenType.Null)
                                {
                                    string scopeInstance = ((string)scopeValue);
                                    propertiesInstance.Scope = scopeInstance;
                                }
                                
                                JToken typeValue2 = propertiesValue["type"];
                                if (typeValue2 != null && typeValue2.Type != JTokenType.Null)
                                {
                                    string typeInstance2 = ((string)typeValue2);
                                    propertiesInstance.Type = typeInstance2;
                                }
                                
                                JToken permissionsArray = propertiesValue["permissions"];
                                if (permissionsArray != null && permissionsArray.Type != JTokenType.Null)
                                {
                                    foreach (JToken permissionsValue in ((JArray)permissionsArray))
                                    {
                                        Permission permissionInstance = new Permission();
                                        propertiesInstance.Permissions.Add(permissionInstance);
                                        
                                        JToken actionsArray = permissionsValue["actions"];
                                        if (actionsArray != null && actionsArray.Type != JTokenType.Null)
                                        {
                                            foreach (JToken actionsValue in ((JArray)actionsArray))
                                            {
                                                permissionInstance.Actions.Add(((string)actionsValue));
                                            }
                                        }
                                        
                                        JToken notActionsArray = permissionsValue["notActions"];
                                        if (notActionsArray != null && notActionsArray.Type != JTokenType.Null)
                                        {
                                            foreach (JToken notActionsValue in ((JArray)notActionsArray))
                                            {
                                                permissionInstance.NotActions.Add(((string)notActionsValue));
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        
                    }
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        TracingAdapter.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Get role definition by name (GUID).
        /// </summary>
        /// <param name='roleDefinitionId'>
        /// Required. Role definition Id
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Role definition get operation result.
        /// </returns>
        public async Task<RoleDefinitionGetResult> GetByIdAsync(string roleDefinitionId, CancellationToken cancellationToken)
        {
            // Validate
            if (roleDefinitionId == null)
            {
                throw new ArgumentNullException("roleDefinitionId");
            }
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("roleDefinitionId", roleDefinitionId);
                TracingAdapter.Enter(invocationId, this, "GetByIdAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/";
            url = url + roleDefinitionId;
            List<string> queryParameters = new List<string>();
            queryParameters.Add("api-version=2014-10-01-preview");
            if (queryParameters.Count > 0)
            {
                url = url + "?" + string.Join("&", queryParameters);
            }
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-version", "2014-10-01-preview");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    RoleDefinitionGetResult result = null;
                    // Deserialize Response
                    if (statusCode == HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = new RoleDefinitionGetResult();
                        JToken responseDoc = null;
                        if (string.IsNullOrEmpty(responseContent) == false)
                        {
                            responseDoc = JToken.Parse(responseContent);
                        }
                        
                        if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                        {
                            RoleDefinition roleDefinitionInstance = new RoleDefinition();
                            result.RoleDefinition = roleDefinitionInstance;
                            
                            JToken idValue = responseDoc["id"];
                            if (idValue != null && idValue.Type != JTokenType.Null)
                            {
                                string idInstance = ((string)idValue);
                                roleDefinitionInstance.Id = idInstance;
                            }
                            
                            JToken nameValue = responseDoc["name"];
                            if (nameValue != null && nameValue.Type != JTokenType.Null)
                            {
                                Guid nameInstance = Guid.Parse(((string)nameValue));
                                roleDefinitionInstance.Name = nameInstance;
                            }
                            
                            JToken typeValue = responseDoc["type"];
                            if (typeValue != null && typeValue.Type != JTokenType.Null)
                            {
                                string typeInstance = ((string)typeValue);
                                roleDefinitionInstance.Type = typeInstance;
                            }
                            
                            JToken propertiesValue = responseDoc["properties"];
                            if (propertiesValue != null && propertiesValue.Type != JTokenType.Null)
                            {
                                RoleDefinitionProperties propertiesInstance = new RoleDefinitionProperties();
                                roleDefinitionInstance.Properties = propertiesInstance;
                                
                                JToken roleNameValue = propertiesValue["roleName"];
                                if (roleNameValue != null && roleNameValue.Type != JTokenType.Null)
                                {
                                    string roleNameInstance = ((string)roleNameValue);
                                    propertiesInstance.RoleName = roleNameInstance;
                                }
                                
                                JToken descriptionValue = propertiesValue["description"];
                                if (descriptionValue != null && descriptionValue.Type != JTokenType.Null)
                                {
                                    string descriptionInstance = ((string)descriptionValue);
                                    propertiesInstance.Description = descriptionInstance;
                                }
                                
                                JToken scopeValue = propertiesValue["scope"];
                                if (scopeValue != null && scopeValue.Type != JTokenType.Null)
                                {
                                    string scopeInstance = ((string)scopeValue);
                                    propertiesInstance.Scope = scopeInstance;
                                }
                                
                                JToken typeValue2 = propertiesValue["type"];
                                if (typeValue2 != null && typeValue2.Type != JTokenType.Null)
                                {
                                    string typeInstance2 = ((string)typeValue2);
                                    propertiesInstance.Type = typeInstance2;
                                }
                                
                                JToken permissionsArray = propertiesValue["permissions"];
                                if (permissionsArray != null && permissionsArray.Type != JTokenType.Null)
                                {
                                    foreach (JToken permissionsValue in ((JArray)permissionsArray))
                                    {
                                        Permission permissionInstance = new Permission();
                                        propertiesInstance.Permissions.Add(permissionInstance);
                                        
                                        JToken actionsArray = permissionsValue["actions"];
                                        if (actionsArray != null && actionsArray.Type != JTokenType.Null)
                                        {
                                            foreach (JToken actionsValue in ((JArray)actionsArray))
                                            {
                                                permissionInstance.Actions.Add(((string)actionsValue));
                                            }
                                        }
                                        
                                        JToken notActionsArray = permissionsValue["notActions"];
                                        if (notActionsArray != null && notActionsArray.Type != JTokenType.Null)
                                        {
                                            foreach (JToken notActionsValue in ((JArray)notActionsArray))
                                            {
                                                permissionInstance.NotActions.Add(((string)notActionsValue));
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        
                    }
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        TracingAdapter.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Get all role definitions.
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Role definition list operation result.
        /// </returns>
        public async Task<RoleDefinitionListResult> ListAsync(CancellationToken cancellationToken)
        {
            // Validate
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                TracingAdapter.Enter(invocationId, this, "ListAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/subscriptions/";
            if (this.Client.Credentials.SubscriptionId != null)
            {
                url = url + Uri.EscapeDataString(this.Client.Credentials.SubscriptionId);
            }
            url = url + "/providers/Microsoft.Authorization/roleDefinitions";
            List<string> queryParameters = new List<string>();
            queryParameters.Add("api-version=2014-10-01-preview");
            if (queryParameters.Count > 0)
            {
                url = url + "?" + string.Join("&", queryParameters);
            }
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-version", "2014-10-01-preview");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    RoleDefinitionListResult result = null;
                    // Deserialize Response
                    if (statusCode == HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = new RoleDefinitionListResult();
                        JToken responseDoc = null;
                        if (string.IsNullOrEmpty(responseContent) == false)
                        {
                            responseDoc = JToken.Parse(responseContent);
                        }
                        
                        if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                        {
                            JToken valueArray = responseDoc["value"];
                            if (valueArray != null && valueArray.Type != JTokenType.Null)
                            {
                                foreach (JToken valueValue in ((JArray)valueArray))
                                {
                                    RoleDefinition roleDefinitionInstance = new RoleDefinition();
                                    result.RoleDefinitions.Add(roleDefinitionInstance);
                                    
                                    JToken idValue = valueValue["id"];
                                    if (idValue != null && idValue.Type != JTokenType.Null)
                                    {
                                        string idInstance = ((string)idValue);
                                        roleDefinitionInstance.Id = idInstance;
                                    }
                                    
                                    JToken nameValue = valueValue["name"];
                                    if (nameValue != null && nameValue.Type != JTokenType.Null)
                                    {
                                        Guid nameInstance = Guid.Parse(((string)nameValue));
                                        roleDefinitionInstance.Name = nameInstance;
                                    }
                                    
                                    JToken typeValue = valueValue["type"];
                                    if (typeValue != null && typeValue.Type != JTokenType.Null)
                                    {
                                        string typeInstance = ((string)typeValue);
                                        roleDefinitionInstance.Type = typeInstance;
                                    }
                                    
                                    JToken propertiesValue = valueValue["properties"];
                                    if (propertiesValue != null && propertiesValue.Type != JTokenType.Null)
                                    {
                                        RoleDefinitionProperties propertiesInstance = new RoleDefinitionProperties();
                                        roleDefinitionInstance.Properties = propertiesInstance;
                                        
                                        JToken roleNameValue = propertiesValue["roleName"];
                                        if (roleNameValue != null && roleNameValue.Type != JTokenType.Null)
                                        {
                                            string roleNameInstance = ((string)roleNameValue);
                                            propertiesInstance.RoleName = roleNameInstance;
                                        }
                                        
                                        JToken descriptionValue = propertiesValue["description"];
                                        if (descriptionValue != null && descriptionValue.Type != JTokenType.Null)
                                        {
                                            string descriptionInstance = ((string)descriptionValue);
                                            propertiesInstance.Description = descriptionInstance;
                                        }
                                        
                                        JToken scopeValue = propertiesValue["scope"];
                                        if (scopeValue != null && scopeValue.Type != JTokenType.Null)
                                        {
                                            string scopeInstance = ((string)scopeValue);
                                            propertiesInstance.Scope = scopeInstance;
                                        }
                                        
                                        JToken typeValue2 = propertiesValue["type"];
                                        if (typeValue2 != null && typeValue2.Type != JTokenType.Null)
                                        {
                                            string typeInstance2 = ((string)typeValue2);
                                            propertiesInstance.Type = typeInstance2;
                                        }
                                        
                                        JToken permissionsArray = propertiesValue["permissions"];
                                        if (permissionsArray != null && permissionsArray.Type != JTokenType.Null)
                                        {
                                            foreach (JToken permissionsValue in ((JArray)permissionsArray))
                                            {
                                                Permission permissionInstance = new Permission();
                                                propertiesInstance.Permissions.Add(permissionInstance);
                                                
                                                JToken actionsArray = permissionsValue["actions"];
                                                if (actionsArray != null && actionsArray.Type != JTokenType.Null)
                                                {
                                                    foreach (JToken actionsValue in ((JArray)actionsArray))
                                                    {
                                                        permissionInstance.Actions.Add(((string)actionsValue));
                                                    }
                                                }
                                                
                                                JToken notActionsArray = permissionsValue["notActions"];
                                                if (notActionsArray != null && notActionsArray.Type != JTokenType.Null)
                                                {
                                                    foreach (JToken notActionsValue in ((JArray)notActionsArray))
                                                    {
                                                        permissionInstance.NotActions.Add(((string)notActionsValue));
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        
                    }
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        TracingAdapter.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
    }
}
