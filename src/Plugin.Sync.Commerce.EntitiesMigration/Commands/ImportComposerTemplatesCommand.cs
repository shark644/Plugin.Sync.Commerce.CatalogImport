﻿using System;
using System.Threading.Tasks;
using Plugin.Sync.Commerce.EntitiesMigration.Pipelines;
using Plugin.Sync.Commerce.EntitiesMigration.Pipelines.Arguments;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.Core.Commands;

namespace Plugin.Sync.Commerce.EntitiesMigration.Commands
{
    /// <summary>
    /// ImportComposerTemplatesCommand
    /// </summary>
    public class ImportComposerTemplatesCommand : CommerceCommand
    {
        /// <summary>
        /// Import Composer Template Pipeline
        /// </summary>
        private readonly IImportEntitiesPipeline _pipeline;

        /// <summary>
        /// c'tor
        /// </summary>
        /// <param name="pipeline">Import Composer Template Pipeline</param>
        /// <param name="serviceProvider">Service Provider</param>
        public ImportComposerTemplatesCommand(IImportEntitiesPipeline pipeline, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            this._pipeline = pipeline;
        }

        /// <summary>
        /// Process
        /// </summary>
        /// <param name="commerceContext">commerceContext</param>
        /// <returns>true if the process was successful</returns>
        public async Task<bool> Process(CommerceContext commerceContext, ImportEntitiesArgument args)
        {
            using (var activity = CommandActivity.Start(commerceContext, this))
            {                
                var result = await this._pipeline.Run(args, new CommercePipelineExecutionContextOptions(commerceContext));
                return result;
            }
        }
    }
}