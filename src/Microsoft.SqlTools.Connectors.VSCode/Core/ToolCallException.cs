namespace Microsoft.SqlTools.Connectors.VSCode
{
    public class ToolCallException : System.Exception
    {
        public string ToolName { get; }

        public ToolCallException(string toolName, System.Exception inner)
            : base($"Tool {toolName} failed with exception {inner.Message}", inner)
        {
            ToolName = toolName;
        }
    }
}
