﻿/*
 * Copyright © 2022-Present The Synapse Authors
 * <p>
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * <p>
 * http://www.apache.org/licenses/LICENSE-2.0
 * <p>
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using Synapse.Integration.Commands.WorkflowActivities;
using Synapse.Integration.Commands.WorkflowInstances;
using Synapse.Integration.Models;
using System.ServiceModel;

namespace Synapse.Apis.Runtime
{

    /// <summary>
    /// Defines the fundamentals of the Synapse Runtime API
    /// </summary>
    [ServiceContract]
    public interface ISynapseRuntimeApi
    {

        /// <summary>
        /// Connects to the Synapse Runtime API
        /// </summary>
        /// <param name="runtimeId">The id of the runtime to connect</param>
        /// <returns>A new <see cref="IAsyncEnumerable{T}"/></returns>
        [OperationContract]
        IAsyncEnumerable<RuntimeSignal> Connect(string runtimeId);

        /// <summary>
        /// Starts the specified workflow instance
        /// </summary>
        /// <param name="workflowInstanceId">The id of the workflow instance to start</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
        /// <returns>The started workflow instance</returns>
        [OperationContract]
        Task<V1WorkflowInstance> StartAsync(string workflowInstanceId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets all the activities (including non-operative ones) of the specified workflow instance
        /// </summary>
        /// <param name="workflowInstanceId">The id of the workflow instance to get the activities of</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
        /// <returns>A new <see cref="List{T}"/> containing all the activities (including non-operative ones) of the specified workflow instance</returns>
        [OperationContract]
        Task<List<V1WorkflowActivity>> GetActivitiesAsync(string workflowInstanceId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the operative activities of the specified workflow instance
        /// </summary>
        /// <param name="workflowInstanceId">The id of the workflow instance to get the activities of</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
        /// <returns>The operative activities of the specified workflow instance</returns>
        [OperationContract]
        Task<List<V1WorkflowActivity>> GetOperativeActivitiesAsync(string workflowInstanceId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the all the child activities (including non-operative ones) of the specified activity
        /// </summary>
        /// <param name="workflowInstanceId">The id of the workflow instance to get the activities of</param>
        /// <param name="activityId">The id of the activity to get the child activities of</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
        /// <returns>The child activities (including non-operative ones) of the specified activity</returns>
        [OperationContract]
        Task<List<V1WorkflowActivity>> GetActivitiesAsync(string workflowInstanceId, string activityId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the operative child activities of the specified activity
        /// </summary>
        /// <param name="workflowInstanceId">The id of the workflow instance to get the activities of</param>
        /// <param name="activityId">The id of the activity to get the child activities of</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
        /// <returns>The operative child activities of the specified activity</returns>
        [OperationContract]
        Task<List<V1WorkflowActivity>> GetOperativeActivitiesAsync(string workflowInstanceId, string activityId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new workflow activity
        /// </summary>
        /// <param name="command">The object that describes the command to execute</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
        /// <returns>The newly created activity</returns>
        [OperationContract]
        Task<V1WorkflowActivity> CreateActivityAsync(V1CreateWorkflowActivityCommand command, CancellationToken cancellationToken = default);

        /// <summary>
        /// Starts the specified activity
        /// </summary>
        /// <param name="activityId">The workflow activity to start</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
        /// <returns>The started activity</returns>
        [OperationContract]
        Task<V1WorkflowActivity> StartActivityAsync(string activityId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Suspends the specified activity
        /// </summary>
        /// <param name="activityId">The workflow activity to suspend</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
        /// <returns>The suspended activity</returns>
        [OperationContract]
        Task<V1WorkflowActivity> SuspendActivityAsync(string activityId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Skips the specified activity
        /// </summary>
        /// <param name="activityId">The workflow activity to skip</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
        /// <returns>The skipped activity</returns>
        [OperationContract]
        Task<V1WorkflowActivity> SkipActivityAsync(string activityId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Faults the specified activity
        /// </summary>
        /// <param name="command">The object that describes the command to execute</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
        /// <returns>The faulted activity</returns>
        [OperationContract]
        Task<V1WorkflowActivity> FaultActivityAsync(V1FaultWorkflowActivityCommand command, CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancels the specified activity
        /// </summary>
        /// <param name="activityId">The id of the activity to cancel</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
        /// <returns>The faulted activity</returns>
        [OperationContract]
        Task<V1WorkflowActivity> CancelActivityAsync(string activityId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sets the output of the specified workflow activity
        /// </summary>
        /// <param name="command">The object that describes the command to execute</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
        /// <returns>The completed workflow activity</returns>
        [OperationContract]
        Task<V1WorkflowActivity> SetActivityOutputAsync(V1SetWorkflowActivityOutputCommand command, CancellationToken cancellationToken = default);

        /// <summary>
        /// Faults the specified workflow instance
        /// </summary>
        /// <param name="command">The object that describes the command to execute</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
        /// <returns>The faulted activity</returns>
        [OperationContract]
        Task<V1WorkflowInstance> FaultAsync(V1FaultWorkflowInstanceCommand command, CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancels the specified workflow instance
        /// </summary>
        /// <param name="workflowInstanceId">The id of the workflow instance that has been cancelled</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
        /// <returns>The cancelled workflow instance</returns>
        [OperationContract]
        Task<V1WorkflowInstance> CancelAsync(string workflowInstanceId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sets the output of the specified workflow instance
        /// </summary>
        /// <param name="command">The object that describes the command to execute</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
        /// <returns>The completed workflow instance</returns>
        [OperationContract]
        Task<V1WorkflowInstance> SetOutputAsync(V1SetWorkflowInstanceOutputCommand command, CancellationToken cancellationToken = default);

    }

}
