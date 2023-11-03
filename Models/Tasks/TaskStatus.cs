namespace PhotoGallery_BackEnd.Models.Tasks
{
    [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TaskStatus
    {
        [EnumMember(Value = "In Queue")]
        InQueue,
        [EnumMember(Value = "Running")]
        Running,
        [EnumMember(Value = "Error")]
        Error,
        [EnumMember(Value = "Completed")]
        Completed,
        [EnumMember(Value = "Cancelled")]
        Cancelled,
        [EnumMember(Value = "Pending")]
        Pending,
        [EnumMember(Value = "Paused")]
        Paused,
        [EnumMember(Value = "Suspended")]
        Suspended,
        [EnumMember(Value = "Waiting")]
        Waiting,
        [EnumMember(Value = "Unknown")]
        Unknown
    }
    //"In Queue": Indicates that the task is in the queue and waiting to be processed.
    //"Running": Indicates that the task is currently being processed or executed.
    //"Error": Indicates that an error occurred while processing the task.
    //"Completed": Indicates that the task has been successfully completed.
    //"Cancelled": Indicates that the task has been cancelled or aborted.
    //"Pending": Indicates that the task is pending and has not started yet.
    //"Paused": Indicates that the task is temporarily paused and will resume later.
    //"Suspended": Indicates that the task has been suspended or put on hold.
    //"Waiting": Indicates that the task is waiting for a specific condition or event to occur before it can proceed.
    //"Unknown": Indicates that the status of the task is unknown or not specified.
}
