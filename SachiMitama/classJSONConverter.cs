using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Collections;

namespace sachimitama
{
    static class classJSONConverter
    {
        private enum ANALYZE_KIND
        {
            NONE,
            OBJECT,
            ARRAY,
            MEMBERS,
            PAIR,
            PAIR_NAME,
            PAIR_VALUE,
            VALUE_STRING,
            VALUE_NUMBER,
            VALUE_BOOL,
            VALUE_NULL
        }

        // JSON形式の文字列を入力
        // classJSONObjectをトップノードにして、格納したものを出力
        // JSON形式のデータは、必ずObject（"{"と"}"でくくられているもの）とする
        public static classJSONValue getJSONData(string json)
        {
            int index = 0;

            if (json != "")
            {
                return getJSONValue(json, ref index);
            }
            else
            {
                return null;
            }
        }

        // JSONのValueを取得
        // PAIRの":"以降、ARRAYの","以降の文字列を入れる
        // <value>は、<string>,<number>,<object>,<array>,true,false,null
        // <string>は、先頭が'\"'のとき
        // <number>は、先頭が'-'か数字(0～9)のとき（e表記はとりあえず無視)
        private static classJSONValue getJSONValue(string json, ref int index)
        {
            classJSONValue result = new classJSONValue();
            char charData;
            bool isEnd = false;

            // 先頭の空白を削除
            while (!isEnd && json.Length > index)
            {
                charData = json[index];
                switch (charData)
                {
                    case '\n':  //空白類文字は無視
                    case '\r':
                    case '\t':
                    case ' ':
                        index++;
                        break;
                    default:
                        isEnd = true;
                        break;
                }
            }

            // 値の取得
            charData = json[index];
            switch (charData)
            {
                case '\"':  // <string>の処理
                    string str = getString(json, ref index);
                    if (str != "")
                    {
                        result.value = str;
                    }
                    isEnd = true;
                    break;
                case 'n':   // nullの処理
                    // 文字列が"null"ならnullと取り出す
                    if (json.Substring(index, "null".Length) == "null")
                    {
                        result.setNull();
                        index += "null".Length;
                    }
                    else
                    {
                        // エラー
                    }
                    isEnd = true;
                    break;
                case 't':   // trueの処理
                    if (json.Substring(index, "true".Length) == "true")
                    {
                        result.value = true;
                        index += "true".Length;
                    }
                    else
                    {
                        // エラー
                    }
                    isEnd = true;
                    break;
                case 'f':   // falseの処理
                    if (json.Substring(index, "false".Length) == "false")
                    {
                        result.value = false;
                        index += "false".Length;
                    }
                    else
                    {
                        // エラー
                    }
                    isEnd = true;
                    break;
                case '{':   // OBJECT START
                    result.value = getJSONObject(json, ref index);
                    break;
                case '[':   // ARRAY
                    result.value = getJSONArray(json, ref index);
                    break;
                case ',':   // OBJECTの中かARRAYの中。どちらにしても、上に返す。
                    index++;
                    isEnd = true;
                    break;
                case '-':   // <number>の処理
                    result.value = getNumber(json, ref index);
                    isEnd = true;
                    break;
                default:
                    if (Char.IsDigit(charData))
                    {
                        //  数値
                        result.value = getNumber(json, ref index);
                    }
                    else
                    {
                        // エラー
                    }
                    isEnd = true;
                    break;
            }

            return result;
        }

        // <object> = {<string>:<value>}
        // 上位レベルで'{'が見つかったら'{'の位置からこの関数に放りこむ
        //自分のレベルで'}'が見つかったらOBJECTの閉じる
        private static classJSONObject getJSONObject(string json, ref int index)
        {
            classJSONObject obj = null;
            classJSONPair pair = null;
            classJSONValue value = null;
            bool isEnd = false;
            char charData;
            ANALYZE_KIND state = ANALYZE_KIND.PAIR;

            // 初めの文字は'{'であることが必須
            if (json[index] != '{')
            {
                return null;
            }
            index++;

            obj = new classJSONObject();
            while (!isEnd && json.Length > index)
            {
                charData = json[index];

                switch (state)
                {
                    case ANALYZE_KIND.PAIR: // PAIRの開始
                        // まずはname(string)が来るので、ダブルクォーテーションで囲まれている文字列を取得
                        switch (charData)
                        {
                            case '\"':
                                state = ANALYZE_KIND.PAIR_NAME;
                                //stringの開始
                                //index++;
                                string str = getString(json, ref index);
                                if (str != "")
                                {
                                    pair = new classJSONPair();
                                    pair.name = str;
                                    state = ANALYZE_KIND.PAIR_VALUE;    //  次はVALUE
                                }
                                else
                                {
                                    // エラー
                                    return null;
                                }
                                break;
                            case '\n':  //空白類文字は無視
                            case '\r':
                            case '\t':
                            case ' ':
                                index++;
                                break;
                            case ',':
                                // 初回以外に出たらOBJECT中の次のPAIRが出現.
                                index++;
                                break;
                            case '}':   // Objectの終わり
                                index++;
                                isEnd = true;
                                break;
                            default:
                                // エラー
                                isEnd = true;
                                break;
                        }
                        break;
                    case ANALYZE_KIND.PAIR_VALUE: // PAIRのnameは取得済のはず
                        // ':'が出たら次から値
                        switch(charData)
                        {
                            case '\n':  //空白類文字は無視
                            case '\r':
                            case '\t':
                            case ' ':
                                index++;
                                break;
                            case ':':
                                // 空白を除き次にDQが出たらstring
                                // '-'、数値が出てきたらnumber
                                // "true"/"false" は bool
                                // "null" は null
                                index++;
                                if (pair != null)
                                {
                                    value = getJSONValue(json, ref index);
                                    pair.value = value;
                                    obj.set(pair);
                                    state = ANALYZE_KIND.PAIR;
                                }
                                break;
                            default:
                                // 空白以外はエラー
                                isEnd = true;
                                break;
                        }
                        break;
                }
            }
            return obj;
        }

        // <array> = [<value>,<value>,…]
        // 上位レベルで'['が出たらこれに放りこむ
        // ']'が出たらARRAYを閉じる
        private static classJSONArray getJSONArray(string json, ref int index)
        {
            classJSONArray result = new classJSONArray();
            classJSONValue value = null;
            char charData;
            bool isEnd = false;

            // 初めの文字は'['であることが必須
            if (json[index] != '[')
            {
                return null;
            }
            index++;

            while (!isEnd && json.Length > index)
            {
                charData = json[index];
                switch (charData)
                {
                    case '\n':  //空白類文字は無視
                    case '\r':
                    case '\t':
                    case ' ':
                        index++;
                        break;
                    case ']':   // ARRAYの終わり
                        isEnd = true;
                        index++;
                        break;
                    case '{':   // OBJECT START
                    case '\"':  // PAIRの始まり
                        value = getJSONValue(json, ref index);
                        if(value != null)
                        {
                            result.add(value);
                        }
                        break;
                    case ',':
                        index++;
                        value = getJSONValue(json, ref index);
                        if(value != null)
                        {
                            result.add(value);
                        }
                        break;
                    default:
                        if (Char.IsDigit(charData))
                        {
                            //  数値
                            value = getJSONValue(json, ref index);
                            if (value != null)
                            {
                                result.add(value);
                            }
                        }
                        else
                        {
                            // エラー
                            isEnd = true;
                        }
                        break;
                }
            }
            return result;
        }

        // DQの後の文字列を渡す
        // 文字列最後のDQまでの文字列を返す。(indexは、DQの次を指す)
        // <string> = "<文字列>"
        private static string getString(string json, ref int index)
        {
            string result = "";
            int indexStart = index;
            int indexDQ;
            int indexESC;

            if (json[index] != '\"')
            {
                return result;
            }
            index++;

            while (json.Length > index)
            {
                indexDQ = json.IndexOf('\"', index);
                indexESC = json.IndexOf('\\', index);

                // ダブルクォーテーションかエスケープシーケンスの'\"'を探す
                if (indexDQ > 0)
                {
                    if (indexESC > 0)
                    {
                        // 文字列としてのDQはない→'\"'の次の文字列から検索
                    }
                    else
                    {
                        // DQはstringを閉じるDQ
                        result = json.Substring(indexStart+1, indexDQ - indexStart - 1);
                        index = indexDQ + 1;
                        break;
                    }
                    index = indexDQ + 1;
                }
                else
                {
                    //エラー:DQなし
                    //TODO:エラー処理はどうする？
                    break;
                }
            }            
            return result;
        }

        // 数字文字から数値を取得(手抜き版)
        // e表記は（とりあえず）エラーとする
        // intで表記できる範囲のみ(数字が続いている範囲を取得)
        // <number> = digits
        private static int getNumber(string json, ref int index)
        {
            int result = 0;
            string digit = "";
            char charData = '\0';
            bool isEnd = false;

            // 先頭の空白文字類は飛ばす
            while(!isEnd && json.Length > index)
            {
                charData = json[index];
                switch(charData)
                {
                    case '\n':  //空白類文字は無視
                    case '\r':
                    case '\t':
                    case ' ':
                        index++;
                        break;
                    default:
                        isEnd = true;
                        break;
                }
            }

            if (charData == '-' ||
                char.IsDigit(charData))
            {
                digit += charData;
                index++;
            }
            else
            {
                // 先頭が'-'または数字文字以外のときは、0を返す。
                return result;
            }

            isEnd = false;
            // 先頭のみ'-'が許される（空白文字列類は除く)
            while(!isEnd && json.Length > index)
            {
                charData = json[index];
                if(char.IsDigit(charData))
                {
                    index++;
                    digit += charData;
                }
                else
                {
                    isEnd = true;
                    //数字以外の文字列が出た場合、そこで数値の終わりとする
                    // "-"だけのときは、０にしちゃう
                    // 参照カウンタはインクリメントしない
                    if (digit == "-")
                    {
                        result = 0;
                    }
                    else
                    {
                        result = int.Parse(digit);
                    }
                }
            }

            return result;
        }

        public class classJSONObject
        {
            private Dictionary<string, classJSONPair> list_;
            public classJSONObject()
            {
                list_ = new Dictionary<string, classJSONPair>();
            }
            public void set(classJSONPair pair)
            {
                if (!list_.ContainsKey(pair.name))
                {
                    list_.Add(pair.name, pair);
                }
                else
                {
                    list_.Add(pair.name, pair);
                }
            }
            public classJSONValue jsonValue(string key)
            {
                if(list_.ContainsKey(key))
                {
                    return list_[key].value;
                }
                else
                {
                    return null;
                }
            }
            public Dictionary<string, classJSONPair> list
            {
                get { return list_; }
            }
        }
        public class classJSONPair
        {
            private string name_;
            public string name
            {
                get { return name_; }
                set { name_ = value; }
            }
            private classJSONValue value_;
            public classJSONValue value
            {
                get { return value_; }
                set { value_ = value; }
            }
        }
        public class classJSONArray
        {
            private List<classJSONValue> list_;
            public classJSONArray()
            {
                list_ = new List<classJSONValue>();
            }
            public void add(classJSONValue obj)
            {
                list_.Add(obj);
            }
        }
        public class classJSONValue
        {
            public enum VALUE_TYPE
            {
                STRING,
                number,
                BOOL,
                ARRAY,
                OBJECT,
                NULL
            }
            private VALUE_TYPE type_ = VALUE_TYPE.NULL;
            public VALUE_TYPE type
            {
                get { return type_; }
                set { type_ = value; }
            }

            private object value_ = null;
            public object value
            {
                get { return value_; }
                set { 
                    // コピーしないよ
                    value_ = value;

                    if (value_ is string)
                    {
                        type_ = VALUE_TYPE.STRING;
                    }
                    else if (value_ is int)
                    {
                        type_ = VALUE_TYPE.number;
                    }
                    else if (value_ is classJSONArray)
                    {
                        type_ = VALUE_TYPE.ARRAY;
                    }
                    else if (value_ is classJSONObject)
                    {
                        type_ = VALUE_TYPE.OBJECT;
                    }
                    else if (value_ is bool)
                    {
                        type_ = VALUE_TYPE.BOOL;
                    }
                    else
                    {
                        // 不正な型はNULLにする
                        type_ = VALUE_TYPE.NULL;
                    }
                }
            }
            public void setNull()
            {
                type_ = VALUE_TYPE.NULL;
                value_ = null;
            }
        }
    }
}
