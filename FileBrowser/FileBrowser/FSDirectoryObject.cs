using System;
using System.Text;
using System.IO;

namespace FileBrowser
{
    class FSDirectoryObject : FSBaseObject
    {
        public DirectoryInfo mDirectory { get; set; }

        public override string DisplayType
        {
            get
            {
                return "Directory";
            }
        }

        public FSDirectoryObject(string path)
        {
            this.Path = path;
            if (Directory.Exists(path))
            {
                mDirectory = new DirectoryInfo(path);
                Name = mDirectory.Name;
            }
        }

        public override string Details()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Type:  directory");
            sb.AppendLine("Name: " + Name);
            return sb.ToString();
        }
    }
}