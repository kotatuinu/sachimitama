using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace sachimitama
{
    class classDataWriterFile : classDataWriter
    {
        public classDataWriterFile(string file)
        {
            fs_ = new FileStream(file, FileMode.Create, FileAccess.Write);
            bw_ = new BinaryWriter(fs_);
        }

        public override void write(byte[] data)
        {
            if (data != null)
            {
                bw_.Write(data);
            }
        }

        public override void flush()
        {
            bw_.Flush();
        }

    }
}
