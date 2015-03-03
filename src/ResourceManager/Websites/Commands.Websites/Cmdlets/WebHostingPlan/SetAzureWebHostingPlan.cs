﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.Azure.Commands.Websites;
using Microsoft.Azure.Management.WebSites;
using System.Net.Http;
using System.Threading;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Net;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Websites.Utilities;

namespace Microsoft.Azure.Commands.Websites.Cmdlets.WebHostingPlan
{
    /// <summary>
    /// this commandlet will let you create a new Azure Web Hosting Plan using ARM APIs
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureWebHostingPlan"), OutputType(typeof(WebHostingPlanCreateOrUpdateResponse))]
    public class SetAzureWebHostingPlanCmdlet : WebHostingPlanBaseCmdlet
    {

        [Parameter(Position = 2, Mandatory = true, HelpMessage = "The location of the web hosting plan.")]
        [ValidateNotNullOrEmptyAttribute]
        public string location { get; set; }
        
        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The Sku of the Webhosting plan eg: free, shared, basic, standard.")]
        [ValidateSet("Free", "Shared", "Basic", "Standard", IgnoreCase = true)]
        [ValidateNotNullOrEmptyAttribute]
        public string Sku { get; set; }

        [Parameter(Position = 4, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Number of Workers to be allocated.")]
        [ValidateNotNullOrEmptyAttribute]
        public int NumberofWorkers { get; set; }

        [Parameter(Position = 5, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The size of he workers: eg Small, Medium, Large")]
        [ValidateNotNullOrEmptyAttribute]
        [ValidateSet("Small", "Medium", "Large", IgnoreCase = true)]
        public string WorkerSize { get; set; }

        public override void ExecuteCmdlet()
        {
            //for now not asking admin site name need to implement in future
            string adminSiteName = null;

            //if Sku is not specified assume default to be Standard
            SkuOptions skuInput = SkuOptions.Standard;

            //if workerSize is not specified assume default to be small
            WorkerSizeOptions workerSizeInput = WorkerSizeOptions.Small;

            //if NumberofWorkers is not specified assume default to be 1
            if (NumberofWorkers == 0)
                NumberofWorkers = 1;


            if (WorkerSize != null)
            {
                switch (WorkerSize.ToLower())
                {
                    case "small":
                        workerSizeInput = WorkerSizeOptions.Small;
                        break;
                    case "medium":
                        workerSizeInput = WorkerSizeOptions.Medium;
                        break;
                    case "large":
                        workerSizeInput = WorkerSizeOptions.Large;
                        break;
                    default:
                        workerSizeInput = WorkerSizeOptions.Large;
                        break;
                }
            }

            if (Sku != null)
            {
                switch (Sku.ToLower())
                {
                    case "free":
                        skuInput = SkuOptions.Free;
                        break;
                    case "shared":
                        skuInput = SkuOptions.Shared;
                        break;
                    case "basic":
                        skuInput = SkuOptions.Basic;
                        break;
                    default:
                        skuInput = SkuOptions.Standard;
                        break;
                }
            }
            
            WriteObject(WebsitesClient.CreateWHP(ResourceGroupName, WHPName, location, adminSiteName, NumberofWorkers, skuInput, workerSizeInput));

        }

    }
}
