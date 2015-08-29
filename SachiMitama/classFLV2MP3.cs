using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace sachimitama
{
    class classFLV2MP3
    {
        private classDataReader.MODE readMode_ = classDataReader.MODE.ONMEMORY;
        private classDataWriter.MODE writeMode_ = classDataWriter.MODE.ONMEMORY;
        private IDataReader reader_ = null;
        private IDataWriter writer_ = null;

        private string flvFile_;
        private string mp3File_;

        private classResult result_;

        public enum ERROR_NO
        {
            UNKNOWN,
            SUCCESS,
            NOEXISTFILE,
            NOTFLVFILE,
            UNKNOWN_DATATYPE,
            CONVERTERROR
        }

        public classDataReader.MODE readMode
        {
            set { readMode_ = value; }
        }

        public classDataWriter.MODE writeMode
        {
            set { writeMode_ = value; }
        }
        public string flvFile
        {
            set { flvFile_ = value; }
        }
        public string mp3File
        {
            set { mp3File_ = value; }
        }

        public classResult convert(string flvFile, string mp3File)
        {
            this.flvFile = flvFile;
            this.mp3File = mp3File;

            return convert();
        }

        public classResult convert()
        {
            bool bIsError = false;
            int dataType;
            int dataSize;
            byte[] mp3Data;
            byte[] data;

            result_ = new classResult();
            result_.flvfile = flvFile_;

            if (!File.Exists(flvFile_))
            {
                result_.errorno = ERROR_NO.NOEXISTFILE;
                return result_;
            }
            FileInfo mp3FileInfo = new FileInfo(mp3File_);
            if (!Directory.Exists(mp3FileInfo.DirectoryName))
            {
                //ディレクトリがないのなら作ればいいのよ
                mp3FileInfo.Directory.Create();
            }
            reader_ = (IDataReader)classDataReader.open(flvFile_, readMode_);
            writer_ = (IDataWriter)classDataWriter.open(mp3File_, writeMode_);

            // header
            // FLVファイルか判定
            mp3Data = reader_.read(3);
            if (Encoding.ASCII.GetString(mp3Data).ToLower() != "flv")
            {
                result_.errorno = ERROR_NO.NOTFLVFILE;
                bIsError = true;
            }

            if (!bIsError)
            {
                mp3Data = reader_.read(6);

                try
                {
                    while (reader_.eof)
                    {
                        // previous tag size(4)
                        data = reader_.read(4);

                        // DataType(1)
                        data = reader_.read(1);
                        if (data.Length != 1)
                        {
                            //result_.errorno = ERROR_NO.CONVERTERROR;
                            //bIsError = true;
                            break;
                        }
                        dataType = (int)data[0];

                        // DataSize(3)
                        data = reader_.read(3);
                        if (data.Length != 3)
                        {
                            //result_.errorno = ERROR_NO.CONVERTERROR;
                            //bIsError = true;
                            break;
                        }
                        dataSize = (int)data[0] * 0x10000 + (int)data[1] * 0x100 + (int)data[2];
                        Debug.WriteLine("classFLV2MP3::convert() data[0,1,2] = [" + Convert.ToString(data[0], 16) + "," + Convert.ToString(data[1], 16) + "," + Convert.ToString(data[2], 16) + "]: dataSize = " + Convert.ToString(dataSize, 16));

                        // time stamp(3),time stamp extended(1), stream id(3)
                        // 読み飛ばし
                        data = reader_.read(7);
                        //Debug.WriteLine("classFLV2MP3::convert() dataType = " + Convert.ToString(dataType, 16) + " : dataSize = " + Convert.ToString(dataSize, 16));

                        switch (dataType)
                        {
                            case 8: // Audio Data
                                // Audio Info(1)
                                mp3Data = reader_.read(1);

                                // mp3data
                                writer_.write(reader_.read(dataSize - 1));
                                break;

                            case 9: // Video Data
                            case 18:    // META
                            default:
                                data = reader_.read(dataSize);
                                break;
                        }
                    }
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            if (!bIsError)
            {
                writer_.flush();
                writer_.close();
                reader_.close();
                result_.errorno = ERROR_NO.SUCCESS;
                result_.result = true;
            }
            else
            {
                writer_.close();
                reader_.close();
                // エラーとなったからには不要なMP3ファイルは削除
                mp3FileInfo.Delete();
                result_.result = false;
            }

            return result_;
        }

        public class classResult
        {
            private string flvFile_;
            private bool result_;
            private classFLV2MP3.ERROR_NO errorNo_;

            public classResult()
            {
                flvFile_ = "";
                result_ = false;
                errorNo_ = ERROR_NO.UNKNOWN;
            }

            public string flvfile
            {
                get { return flvFile_; }
                set { flvFile_ = value; }
            }
            public bool result
            {
                get { return result_; }
                set { result_ = value; }
            }
            public classFLV2MP3.ERROR_NO errorno
            {
                get { return errorNo_; }
                set { errorNo_ = value; }
            }
        }

    }
}
