using System;


namespace FileBrowser
{
    public abstract class FSBaseObject
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public virtual string DisplayType
        {
            get
            {
                return "";
            }
        }

        public abstract string Details();

    }
}