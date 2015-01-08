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
using System.Collections;
using System.Collections.Generic;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.WindowsAzure.Commands.Common.Models;

namespace Microsoft.Azure.Commands.Automation.Common
{
    public interface IAutomationClient
    {
        AzureSubscription Subscription { get; }

        #region JobStreams

        IEnumerable<JobStream> GetJobStream(string automationAccountname, Guid jobId, DateTime? time, string streamType);

        #endregion

        #region Variables

        Variable GetVariable(string automationAccountName, string variableName);

        IEnumerable<Variable> ListVariables(string automationAccountName);

        Variable CreateVariable(string automationAccountName, Variable variable);

        void DeleteVariable(string automationAccountName, string variableName);

        Variable UpdateVariable(string automationAccountName, Variable variable);

        #endregion

        #region Scedules

        Schedule CreateSchedule(string automationAccountName, Schedule schedule);

        void DeleteSchedule(string automationAccountName, string scheduleName);

        Schedule GetSchedule(string automationAccountName, string scheduleName);

        IEnumerable<Schedule> ListSchedules(string automationAccountName);

        Schedule UpdateSchedule(string automationAccountName, string scheduleName, bool? isEnabled, string description);

        #endregion

        #region Runbooks

        Runbook GetRunbook(string automationAccountName, string runbookName);

        IEnumerable<Runbook> ListRunbooks(string automationAccountName);

        Runbook CreateRunbookByName(string automationAccountName, string runbookName, string description, IDictionary<string, string> tags);

        Runbook CreateRunbookByPath(string automationAccountName, string runbookPath, string description, IDictionary<string, string> tags);
        
        void DeleteRunbook(string automationAccountName, string runbookName);

        Runbook PublishRunbook(string automationAccountName, string runbookName);

        Runbook UpdateRunbook(string automationAccountName, string runbookName, string description, IDictionary<string, string> tags, bool? logProgress, bool? logVerbose);

        RunbookDefinition UpdateRunbookDefinition(string automationAccountName, string runbookName, string runbookPath, bool overwrite);

        IEnumerable<RunbookDefinition> ListRunbookDefinitionsByRunbookName(string automationAccountName, string runbookName, bool? isDraft);

        Job StartRunbook(string automationAccountName, string runbookName, IDictionary parameters);

        #endregion

        #region Credentials

        Credential CreateCredential(string automationAccountName, string name, string userName, string password, string description);

        Credential UpdateCredential(string automationAccountName, string name, string userName, string password, string description);

        Credential GetCredential(string automationAccountName, string name);

        IEnumerable<Credential> ListCredentials(string automationAccountName);

        void DeleteCredential(string automationAccountName, string name);

        #endregion

        #region Modules

        Module CreateModule(string automationAccountName, Uri contentLink, string moduleName, IDictionary<string, string> tags);

        Module GetModule(string automationAccountName, string name);

        Module UpdateModule(string automationAccountName, IDictionary<string, string> tags, string name, Uri contentLink);

        IEnumerable<Module> ListModules(string automationAccountName);

        void DeleteModule(string automationAccountName, string name);
        
        #endregion

        #region Jobs

        Job GetJob(string automationAccountName, Guid id);

        IEnumerable<Job> ListJobsByRunbookName(string automationAccountName, string runbookName, DateTime? startTime, DateTime? endTime);

        IEnumerable<Job> ListJobs(string automationAccountName, DateTime? startTime, DateTime? endTime);

        void ResumeJob(string automationAccountName, Guid id);

        void StopJob(string automationAccountName, Guid id);

        void SuspendJob(string automationAccountName, Guid id);

        #endregion
    }
}