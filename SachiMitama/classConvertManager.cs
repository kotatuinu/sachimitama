using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace sachimitama
{
    class classConvertManager
    {
        // 変換中のリスト
        private Dictionary<string, classFLV2MP3Thread> list_;

        // 変換が済んだときのCallback
        public delegate void delegate_callback(classFLV2MP3Thread.classResult reasult);
        private delegate_callback callback_;
        public delegate_callback callback
        {
            set { callback_ = value; }
        }

        // すべて変換が済んだときのcallback
        public delegate void delegate_completeCallback();
        private delegate_completeCallback completeCallback_;
        public delegate_completeCallback completeCallback
        {
            set { completeCallback_ = value; }
        }

        // 設定
        classParameter parameter_;
        public classParameter parameter
        {
            set { parameter_ = value; }
        }

        public classConvertManager()
        {
            list_ = new Dictionary<string, classFLV2MP3Thread>();
            callback_ = null;
            completeCallback_ = null;
        }

        public void add(string flvFile, string mp3File)
        {
            classFLV2MP3Thread flv2mp3 = new classFLV2MP3Thread();

            flv2mp3.readMode = parameter_.readMode;
            flv2mp3.writeMode = parameter_.writeMode;

            flv2mp3.flvFile = flvFile;
            flv2mp3.mp3File = mp3File;
            flv2mp3.callback = new classFLV2MP3Thread.delegate_callback(this.resultCallback);

            lock (list_)
            {
                if (!list_.ContainsKey(flvFile))
                {
                    list_.Add(flvFile, flv2mp3);
                }
            }
        }

        public void startThread()
        {
            lock (list_)
            {
                foreach (classFLV2MP3Thread flv2mp3 in list_.Values)
                {
                    flv2mp3.run();
                }
            }
        }

        private void resultCallback(classFLV2MP3Thread.classResult result)
        {
            lock (list_)
            {
                if (list_.ContainsKey(result.flvfile))
                {
                    list_.Remove(result.flvfile);
                }
            }

            if (callback_ != null)
            {
                callback_(result);
            }

            if (completeCallback_ != null)
            {
                if (list_.Count == 0)
                {
                    completeCallback_();
                }
            }
        }

        public bool isComplete
        {
            get { return (list_.Count == 0); }
        }
    }
}
