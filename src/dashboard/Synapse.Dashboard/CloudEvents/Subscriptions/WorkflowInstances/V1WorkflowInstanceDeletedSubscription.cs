﻿/*
 * Copyright © 2022-Present The Synapse Authors
 * <p>
 * Licensed under the Apache License, Version 2.0(the "License");
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
 */

using Neuroglia.Data.Flux;
using Neuroglia.Mapping;
using Synapse.Integration.Events.WorkflowInstances;
using Synapse.Integration.Models;

namespace Synapse.Dashboard.CloudEvents.Subscriptions.WorkflowInstances
{
    class V1WorkflowInstanceDeletedSubscription
        : CloudEventSubscription<V1WorkflowInstance, V1WorkflowInstanceDeletedIntegrationEvent>
    {

        public V1WorkflowInstanceDeletedSubscription(ILoggerFactory loggerFactory, IDispatcher dispatcher, IMapper mapper)
            : base(loggerFactory, dispatcher, mapper)
        {

        }

        public override void Handle(V1WorkflowInstanceDeletedIntegrationEvent e)
        {
            try
            {
                this.Dispatcher.Dispatch(new DeleteV1WorkflowInstance(e.AggregateId));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }

}
