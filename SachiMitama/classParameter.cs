using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace sachimitama
{
    public class classParameter
    {
        public classParameter()
        {
        }

        public classParameter(classParameter param)
        {
            this.clone(param);
        }

        public void clone(classParameter param)
        {
            Type t = typeof(classParameter);
            PropertyInfo[] members = t.GetProperties();

            foreach (PropertyInfo p in members)
            {
                if (p.CanWrite && p.CanRead)
                {
                    t.InvokeMember(p.Name, BindingFlags.SetProperty, null, this, new object[] { t.InvokeMember(p.Name, BindingFlags.GetProperty, null, param, null) });
                }
            }
        }

        public string parameterFileName
        {
            get { return "sachimitama.ini"; }
        }
        public string version
        {
            get { return "00-00-000"; }
        }

        // 処理方式
        // ファイルの読み込み方法
        private classDataReader.MODE readMode_ = classDataReader.MODE.ONMEMORY;
        public classDataReader.MODE readMode
        {
            get { return readMode_; }
            set { readMode_ = value; }
        }

        // ファイルの書き込み方法
        private classDataWriter.MODE writeMode_ = classDataWriter.MODE.ONMEMORY;
        public classDataWriter.MODE writeMode
        {
            get { return writeMode_; }
            set { writeMode_ = value; }
        }

        // ファイル
        // MP3ファイルの出力先
        public enum OUTPUTDIR_MODE : int 
        {
            SAMEDIR,    // FLVファイルと同じディレクトリ
            SETTINGDIR  // 指定したディレクトリ
        }
        private OUTPUTDIR_MODE outputdirmode_ = OUTPUTDIR_MODE.SAMEDIR;
        private string outputDir_ = ""; // MP3出力ディレクトリ
        public OUTPUTDIR_MODE outoutdir_mode
        {
            get { return outputdirmode_; }
            set { outputdirmode_ = value; }
        }

        public string outputDir
        {
            get { return outputDir_; }
            set { outputDir_ = value; }
        }

        // 出力ファイル
        public enum OUTPUTFILE_MODE : int 
        {
            OVERWRITE,  // 上書き保存
            SKIP        // スキップ
        }
        private OUTPUTFILE_MODE outputfilemode_ = OUTPUTFILE_MODE.OVERWRITE;
        public OUTPUTFILE_MODE outputfile_mode
        {
            get { return outputfilemode_; }
            set { outputfilemode_ = value; }
        }

        // ドラッグ＆ドロップ時の処理
        public enum DROP_MODE
        {
            IMMEDIATE,
            BUNDLE
        }
        private DROP_MODE dropmode_ = DROP_MODE.BUNDLE;
        public DROP_MODE dorp_mode
        {
            get { return dropmode_; }
            set { dropmode_ = value; }
        }

        // 変換完了時の処理
        public enum FINISHEDCONVERT_MODE
        {
            DISPLAYDIALOG,
            SUSPEND,
            SHUTDOWN,
            NONOTICE
        }
        private FINISHEDCONVERT_MODE finishedmode_ = FINISHEDCONVERT_MODE.DISPLAYDIALOG;
        public FINISHEDCONVERT_MODE finished_mode
        {
            get { return finishedmode_; }
            set { finishedmode_ = value; }
        }

        // ダブルクリック時の処理
        public enum DOBULCLICK_MODE
        {
            CHANGEMP3FILENAME,
            STARTCONVERT
        }
        private DOBULCLICK_MODE doubleclikmode_ = DOBULCLICK_MODE.STARTCONVERT;
        public DOBULCLICK_MODE doubleclick_mode
        {
            get { return doubleclikmode_; }
            set { doubleclikmode_ = value; }
        }

        // FLVファイル名からMP3ファイルの出力ファイル名を取得する。
        public string getMP3File(string flvFileName)
        {
            string mp3File = "";

            FileInfo info = new FileInfo(flvFileName);
            if (outoutdir_mode == OUTPUTDIR_MODE.SAMEDIR ||
                outputDir_ == "")
            {
                // FLVとおなじディレクトリに出力する
                mp3File = info.DirectoryName + "\\";
            }
            else
            {
                mp3File = outputDir_ + "\\";
            }

            mp3File += info.Name.Substring(0,info.Name.Length - info.Extension.Length) + ".mp3";

            return mp3File;
        }

        public void save()
        {
            this.save(this.parameterFileName);
        }

        public void save(string file)
        {
            bool isFirst = true;

            FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            Type t = typeof(classParameter);
            PropertyInfo[] properties = t.GetProperties();

            sw.Write("{");
            foreach (PropertyInfo p in properties)
            {
                if (!isFirst)
                {
                    sw.WriteLine(",");
                }
                else
                {
                    isFirst = false;
                }

                Type propertType = p.PropertyType;
                String typeName = propertType.FullName;
                if (typeName == "int")
                {
                    sw.Write("\"" + p.Name + "\":" + (string)t.InvokeMember(p.Name, BindingFlags.GetProperty, null, this, null).ToString());
                }
                else if (typeName == "bool")
                {
                    sw.Write("\"" + p.Name + "\":" + (string)t.InvokeMember(p.Name, BindingFlags.GetProperty, null, this, null).ToString());
                }
                else
                {
                    sw.Write("\"" + p.Name + "\":\"" + (string)t.InvokeMember(p.Name, BindingFlags.GetProperty, null, this, null).ToString() + "\"");
                }
                
            }
            sw.WriteLine("}");

            sw.Close();
            fs.Close();
        }

        public void load()
        {
            this.load(this.parameterFileName);
        }

        public void load(string file)
        {
            string data;
            // ファイルが存在するときパラメタファイルを読み込む
            if (File.Exists(file))
            {
                FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);

                data = sr.ReadToEnd();

                sr.Close();
                fs.Close();

                classJSONConverter.classJSONValue jsonValue = classJSONConverter.getJSONData(data);
                if (jsonValue == null)
                {
                    return;
                }

                classJSONConverter.classJSONObject obj = (classJSONConverter.classJSONObject)jsonValue.value;

                Type t = typeof(classParameter);
                PropertyInfo[] members = t.GetProperties();
                foreach (PropertyInfo p in members)
                {
                    if (p.CanWrite)
                    {
                        jsonValue = obj.jsonValue(p.Name);
                        if (jsonValue != null)
                        {
                            switch (p.Name)
                            {
                                case "readMode":
                                    switch((string)jsonValue.value)
                                    {
                                        case "FILE":
                                            this.readMode = classDataReader.MODE.FILE;
                                            break;
                                        default:
                                            this.readMode = classDataReader.MODE.ONMEMORY;
                                            break;
                                    }
                                    break;
                                case "writeMode":
                                    switch ((string)jsonValue.value)
                                    {
                                        case "FILE":
                                            this.writeMode = classDataWriter.MODE.FILE;
                                            break;
                                        default:
                                            this.writeMode = classDataWriter.MODE.ONMEMORY;
                                            break;
                                    }
                                    break;
                                case "outoutdir_mode":
                                    switch ((string)jsonValue.value)
                                    {
                                        case "SETTINGDIR":
                                            this.outoutdir_mode = OUTPUTDIR_MODE.SETTINGDIR;
                                            break;
                                        default:
                                            this.outoutdir_mode = OUTPUTDIR_MODE.SAMEDIR;
                                            break;
                                    }
                                    break;
                                case "outputDir":
                                    this.outputDir = (string)jsonValue.value;
                                    break;
                                case "outputfile_mode":
                                    switch ((string)jsonValue.value)
                                    {
                                        case "OVERWRITE":
                                            this.outputfile_mode = OUTPUTFILE_MODE.OVERWRITE;
                                            break;
                                        default:
                                            this.outputfile_mode = OUTPUTFILE_MODE.SKIP;
                                            break;
                                    }
                                    break;
                                case "dorp_mode":
                                    switch ((string)jsonValue.value)
                                    {
                                        case "IMMEDIATE":
                                            this.dorp_mode = DROP_MODE.IMMEDIATE;
                                            break;
                                        default:
                                            this.dorp_mode = DROP_MODE.BUNDLE;
                                            break;
                                    }
                                    break;
                                case "finished_mode":
                                    switch ((string)jsonValue.value)
                                    {
                                        case "NONOTICE":
                                            this.finished_mode = FINISHEDCONVERT_MODE.NONOTICE;
                                            break;
                                        case "SHUTDOWN":
                                            this.finished_mode = FINISHEDCONVERT_MODE.SHUTDOWN;
                                            break;
                                        case "SUSPEND":
                                            this.finished_mode = FINISHEDCONVERT_MODE.SUSPEND;
                                            break;
                                        default:
                                            this.finished_mode = FINISHEDCONVERT_MODE.DISPLAYDIALOG;
                                            break;
                                    }
                                    break;
                                case "doubleclick_mode":
                                    switch ((string)jsonValue.value)
                                    {
                                        case "STARTCONVERT":
                                            this.doubleclick_mode = DOBULCLICK_MODE.STARTCONVERT;
                                            break;
                                        default:
                                            this.doubleclick_mode = DOBULCLICK_MODE.CHANGEMP3FILENAME;
                                            break;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
