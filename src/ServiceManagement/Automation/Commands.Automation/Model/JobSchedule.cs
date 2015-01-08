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

using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Properties;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Automation.Model
{
    /// <summary>
    /// The Job Schedule.
    /// </summary>
    public class JobSchedule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JobSchedule"/> class.
        /// </summary>
        /// <param name="jobSchedule">
        /// The job schedule.
        /// </param>
        public JobSchedule(string automationAccountName, Azure.Management.Automation.Models.JobSchedule jobSchedule)
        {
            Requires.Argument("jobSchedule", jobSchedule).NotNull();
            this.AutomationAccountName = automationAccountName;
            this.Id = jobSchedule.Properties.Id;
            this.RunbookName = jobSchedule.Properties.Runbook.Name;
            this.ScheduleName = jobSchedule.Properties.Schedule.Name;
            this.Parameters = jobSchedule.Properties.Parameters ?? new Dictionary<string, string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HourlySchedule"/> class.
        /// </summary>
        public JobSchedule()
        {
        }

        /// <summary>
        /// Gets or sets the automation account name.
        /// </summary>
        public string AutomationAccountName { get; set; }
        
        /// <summary>
        /// Gets or sets the job schedule id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the runbook name.
        /// </summary>
        public string RunbookName { get; set; }

        /// <summary>
        /// Gets or sets the schedule name.
        /// </summary>
        public string ScheduleName { get; set; }

        /// <summary>
        /// Gets or sets the runbook parameters.
        /// </summary>
        public IDictionary<string, string> Parameters { get; set; }
    }
}
