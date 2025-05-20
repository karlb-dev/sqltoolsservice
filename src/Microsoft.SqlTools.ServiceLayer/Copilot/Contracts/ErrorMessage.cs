namespace Microsoft.SqlTools.ServiceLayer.Copilot.Contracts
{
    public class ErrorMessage
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public string ToolName { get; set; }
        public string StackTrace { get; set; }
    }
}
