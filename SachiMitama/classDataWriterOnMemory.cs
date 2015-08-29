using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;

namespace sachimitama
{
    class classDataWriterOnMemory : classDataWriter
    {
        List<byte[]> dataList_ = null;
        string file_;
        
        public classDataWriterOnMemory(string file)
        {
            file_ = file;
            dataList_  = new List<byte[]>();
        }

        public override void write(byte[] data)
        {
            if (data != null)
            {
                dataList_.Add(data);
            }
        }

        public override void flush()
        {
            fs_ = new FileStream(file_, FileMode.Create, FileAccess.Write);
            bw_ = new BinaryWriter(fs_);
            foreach (byte[] data in dataList_)
            {
                bw_.Write(data);
            }
            bw_.Flush();
            dataList_.Clear();
        }
    }
}
