using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace sachimitama
{
    class classDataReaderOnMemory : classDataReader
    {
        private byte[] data_;
        private int index_ = 0;

        public classDataReaderOnMemory (string file)
        {
            if (File.Exists(file))
            {
                // ファイルが存在する
                fs_ = new FileStream(file, FileMode.Open);
                br_ = new BinaryReader(fs_);

                // ファイルを一気読み
                data_ = new byte[fs_.Length];
                data_ = br_.ReadBytes((int)fs_.Length);

                index_ = 0;
            }
        }

        override public byte[] read(int length)
        {
            // 引数か残りデータ長のどちらか小さい方が戻り値のデータ長となる。
            // 0バイトのときは？
            //Debug.WriteLine("classDataReaderOnMemory::read data_.Length = " + Convert.ToString(data_.Length, 16) + " : index=" + Convert.ToString(index_, 16) + "  length=" + Convert.ToString(length, 16));

            int retLength = ((data_.Length - index_) > length) ? length : (data_.Length - index_);
            if (retLength == 0 || length == 0 || length < 0)
            {
                return null;
            }

            byte[] retData = new byte[retLength];
            Array.Copy(data_, index_, retData, 0, retLength);
            index_ += retLength;

            return retData;
        }

        override public bool eof
        {
            get { return this.length >= index_; }
        }

        public override int length
        {
            get { return data_.Length; }
        }
    }
}
