using System;
using System.Text;
using System.IO;

namespace FileBrowser
{
    public class FSFileObject : FSBaseObject
    {
        public FileInfo mFile { get; set; }
        public string FileSize
        {
            get
            {
                if (mFile != null)
                {
                    if (mFile.Length < 1024)
                    {
                        return string.Format("{0} B", mFile.Length);
                    }
                    else if (mFile.Length < 1024 * 1024)
                    {
                        return string.Format("{0:0.00} KB", (double)mFile.Length / 1024);
                    }
                    else
                    {
                        return string.Format("{0:0.00} MB", (double)mFile.Length / (1024 * 1024));
                    }
                }
                else
                {
                    return "";
                }
            }
        }

        public override string DisplayType
        {
            get
            {
                return "File";
            }
        }

        public FSFileObject(string path)
        {
            this.Path = path;

            if (File.Exists(path))
            {
                mFile = new FileInfo(path);
                Name = mFile.Name;
            }
        }

        public override string Details()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Type:  file");
            sb.AppendLine("Name: " + Name);
            sb.AppendLine("Size: " + FileSize);

            return sb.ToString();
        }
    }
}