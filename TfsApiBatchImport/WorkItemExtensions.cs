using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;


namespace WorkItemMigration.Extensions
{
    public static class WorkItemExtensions
    {
        public static string GetTitle(this WorkItem workItem) => workItem.GetField(Constants.Fields.Title);

        public static string GetCreatedBy(this WorkItem workItem) => workItem.GetField(Constants.Fields.CreatedBy);

        public static string GetHistory(this WorkItem workItem) => workItem.GetField(Constants.Fields.History);

        public static string GetReproSteps(this WorkItem workItem) => workItem.GetField(Constants.Fields.ReproSteps)??"";

        public static string GetTags(this WorkItem workItem) => workItem.GetField(Constants.Fields.Tags);

        public static string GetAreaPath(this WorkItem workItem) => workItem.GetField(Constants.Fields.AreaPath);

        public static string GetTeamProject(this WorkItem workItem) => workItem.GetField(Constants.Paths.TeamProject);

        public static string GetWorkItemType(this WorkItem workItem) => workItem.GetField(Constants.Paths.WorkItemType);

        public static string GetSeverity(this WorkItem workItem) => workItem.GetField(Constants.Fields.Severity);
        public static string GetPriority(this WorkItem workItem) => workItem.GetField(Constants.Fields.Priority);

        public static DateTime GetCreatedDate(this WorkItem workItem) => DateTime.Parse(workItem.GetField(Constants.Fields.CreatedDate));

        public static DateTime GetChangedDate(this WorkItem workItem) => DateTime.Parse(workItem.GetField(Constants.Fields.ChangedDate));

        public static string GetField(this WorkItem workItem, string field)
        {
            return workItem.Fields.GetValueOrDefault(field)?.ToString();
        }

        //public static IEnumerable<TfsWorkItemAttachment> GetAttachments(this WorkItem workitem)
        //{
        //    if (workitem.Relations == null || !workitem.Relations.Any()) //no attachments
        //    {
        //        return new List<TfsWorkItemAttachment>();
        //    }

        //    return workitem.Relations.Where(r => r.IsAttachment()).Select(r => new TfsWorkItemAttachment
        //    {
        //        Url = r.Url,
        //        FileName = r.Attributes.GetValueOrDefault("name", "").ToString()
        //    });
        //}


    }
}
