using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace sachimitama
{
    class classFLV2MP3Thread : classFLV2MP3
    {
        delegate classResult threadMethod();
        public delegate void delegate_callback(classResult reasult);
        private delegate_callback callback_;
        //threadMethod thread_;
        // ThreadMethodをスレッドプールで実行できるように
        // WaitCallbackデリゲートを作成
        WaitCallback waitCallback_;

        public classFLV2MP3Thread()
        {
            waitCallback_ = new WaitCallback(convertThread);
        }


        public delegate_callback callback
        {
            set { callback_ = value; }
        }

        public void run()
        {
            //thread_ = new threadMethod(this.convert);
            //thread_.BeginInvoke(new AsyncCallback(flv2mp3_callback), null); 
            // スレッドプールに登録
            ThreadPool.QueueUserWorkItem(waitCallback_);
        }

        public void convertThread(object obj)
        {
            classResult result = base.convert();
            callback_(result);
        }
/*
        public void flv2mp3_callback(IAsyncResult ar)
        {
            classResult result = thread_.EndInvoke(ar);
            callback_(result);
        }
*/
    }
}
