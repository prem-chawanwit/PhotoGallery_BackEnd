namespace PhotoGallery_BackEnd.DTOs.Tasks
{
    public class TaskReviewDataDTO
    {
        public string? task_id { get; set; }
        public string? extractData { get; set; }
        public string? product { get; set; }
        public string? stockwafer { get; set; }
        public string? preparedata1 { get; set; }
        public string? preparedata2 { get; set; }
        public string? workorder { get; set; }
        public string? prepareapplan1 { get; set; }
        public string? prepareapplan2 { get; set; }
        public string? coProduct { get; set; }
        public string? boms { get; set; }
        public string? pushview { get; set; } //<--- 20230929
        //Time
        public string? extractStartTime { get; set; }  //<--- 20230929
        public string? extractEndTime { get; set; }  //<--- 20230929
        public string? tranformStartTime { get; set; } //<--- 20230929
        public string? tranformEndTime { get; set; } //<--- 20230929
        public string? loadStartTime { get; set; }     //<--- 20230929
        public string? loadEndTime { get; set; }     //<--- 20230929
        //Progress
        public string? extractPrg { get; set; }     //<--- 20230929
        public string? tranformPrg { get; set; }     //<--- 20230929
        public string? loadPrg { get; set; }     //<--- 20230929
        //Status
        public string? extractSta { get; set; }     //<--- 20230929
        public string? tranformSta { get; set; }     //<--- 20230929
        public string? loadSta { get; set; }     //<--- 20230929
        //Main
        public string? isRunning { get; set; }
        public int status { get; set; }
        public string? remark { get; set; } = string.Empty;
    }
}
