namespace WorkItemMigration
{
    public static class Constants
    {
        public static class Fields
        {
            public const string Title = "System.Title";
            public const string Priority = "Microsoft.VSTS.Common.Priority";
            public const string AreaPath = "System.AreaPath";
            public const string AreaId = "System.AreaId";
            public const string IterationId = "System.IterationId";
            public const string ReproSteps = "Microsoft.VSTS.TCM.ReproSteps";
            public const string Tags = "System.Tags";
            public const string CreatedBy = "System.CreatedBy";
            public const string Severity = "Microsoft.VSTS.Common.Severity";
            public const string State = "System.State";
            public const string CreatedDate = "System.CreatedDate";
            public const string ChangedDate = "System.ChangedDate";
            public const string History = "System.History";
            public const string TeamProject = "System.TeamProject";
            public const string WorkItemType = "System.WorkItemType";
        }

        public static class Paths
        {
            public static readonly string Title = $"{Pfx}{Fields.Title}";
            public static readonly string WorkItemType = $"{Pfx}{Fields.WorkItemType}";
            public static readonly string AreaPath = $"{Pfx}{Fields.AreaPath}";
            public static readonly string ReproSteps = $"{Pfx}{Fields.ReproSteps}";
            public static readonly string Tags = $"{Pfx}{Fields.Tags}";
            public static readonly string CreatedBy = $"{Pfx}{Fields.CreatedBy}";
            public static readonly string ChangedDate = $"{Pfx}{Fields.ChangedDate}";
            public static readonly string Severity = $"{Pfx}{Fields.Severity}";
            public static readonly string History = $"{Pfx}{Fields.History}";
            public static readonly string Priority = $"{Pfx}{Fields.Priority}";
            public static readonly string TeamProject = $"{Pfx}{Fields.TeamProject}";

            public const string Relations = "/relations/";

            private const string Pfx = "/fields/";
           
        }

        public static readonly string DefaultSelect =
            $@"SELECT 
                *
                FROM WorkItems";
    }
}