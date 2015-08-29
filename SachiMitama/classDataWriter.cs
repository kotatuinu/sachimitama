using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace sachimitama
{
    abstract public class classDataWriter : IDataWriter
    {
        protected FileStream fs_ = null;
        protected BinaryWriter bw_ = null;

        public enum MODE : int 
        {
            ONMEMORY,
            FILE
        }

        public static IDataWriter open(string file)
        {
            return open(file, MODE.ONMEMORY);
        }

        public static IDataWriter open(string file, classDataWriter.MODE mode)
        {
            IDataWriter incetance = null;

            switch (mode)
            {
                case MODE.FILE:
                    incetance = (IDataWriter)new classDataWriterFile(file);
                    break;
                case MODE.ONMEMORY:
                    incetance = (IDataWriter)new classDataWriterOnMemory(file);
                    break;
            }

            return incetance;
        }

        abstract public void write(byte[] data);
        abstract public void flush();

        public void close()
        {
            if (bw_ != null)
            {
                bw_.Close();
            }
            if (fs_ != null)
            {
                fs_.Close();
            }
        }
    }
}
