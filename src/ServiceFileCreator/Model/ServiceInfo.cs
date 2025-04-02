namespace ServiceFileCreator.Model
{
    public class ServiceInfo
    {
        public Service Services { get; set; } = new();
        public ExecutionOptions ExecutionOptions { get; set; } = new();
        public CompilerOptions CompilerOptions { get; set; } = new();
        public SystemdOption Systemd { get; set; } = new();
    }
}
