using System.Collections.Generic;

namespace ServiceFileCreator.Model
{
    public class Service
    {
        public string Name { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public ProjectType ProjectType { get; set; } = ProjectType.None;
        public List<string> Dependencies { get; set; } = [];
    }
}
