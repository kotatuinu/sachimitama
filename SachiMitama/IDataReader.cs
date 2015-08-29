using System;
using System.Collections.Generic;
using System.Text;

namespace sachimitama
{
    public interface IDataReader
    {
        //classDataReader open(string file);
        //classDataReader open(string file, classDataReader.MODE mode);
        byte[] read(int length);
        bool eof { get; }
        int length { get; }
        void close();
    }
}
