using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace sachimitama
{
    class classDataReaderFile : classDataReader
    {
        public classDataReaderFile(string file)
        {
            if (File.Exists(file))
            {
                // ƒtƒ@ƒCƒ‹‚ª‘¶Ý‚·‚é
                fs_ = new FileStream(file, FileMode.Open);
                br_ = new BinaryReader(fs_);
            }
        }

        override public byte[] read(int length)
        {
            byte[] readData = null;

            if (length > 0)
            {
                readData = br_.ReadBytes(length);
            }

            return readData;
        }

        override public bool eof
        {
            get { return this.length >= fs_.Position; }
        }

        public override int length
        {
            get { return (int)fs_.Length; }
        }
    }
}
