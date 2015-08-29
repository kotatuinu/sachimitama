using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace sachimitama
{
    abstract public class classDataReader : IDataReader
    {
        protected FileStream fs_ = null;
        protected BinaryReader br_ = null;

        public enum MODE : int
        {
            ONMEMORY,
            FILE
        }

        static public IDataReader open(string file)
        {
            return open(file, MODE.ONMEMORY);
        }

        static public IDataReader open(string file, classDataReader.MODE mode)
        {
            IDataReader instance = null;

            switch(mode)
            {
                case MODE.FILE:
                    instance = (IDataReader)new classDataReaderFile(file);
                    break;
                case MODE.ONMEMORY:
                    instance = (IDataReader)new classDataReaderOnMemory(file);
                    break;
            }

            return instance;
        }

        abstract public byte[] read(int length);
        abstract public bool eof { get; }
        abstract public int length { get; }

        public void close()
        {
            if (br_ != null)
            {
                br_.Close();
            }
            if (fs_ != null)
            {
                fs_.Close();
            }

        }
    }
}
