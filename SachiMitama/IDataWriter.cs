using System;
using System.Collections.Generic;
using System.Text;

namespace sachimitama
{
    public interface IDataWriter
    {
        //IDataWriter open(string file);
        //IDataWriter open(string file, classDataWriter.MODE mode);
        void write(byte[] data);
        void flush();
        void close();
    }
}
