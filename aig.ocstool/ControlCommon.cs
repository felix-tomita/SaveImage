using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using mshtml;

namespace aig.ocstool
{

#region Public Logic Class

    /// <summary>
    /// DOM操作を行う際の各種操作を検証する
    /// </summary>
    public static class DomElementValidator
    {
        /// <summary>
        /// 指定された要素に明示的に指定された属性を一覧表示する
        /// </summary>
        /// <param name="targetElement"></param>
        public static void PrintAllAttributes(HtmlElement targetElement)
        {
            Dictionary<string, string> results = ExtractAttributes(targetElement);
            System.Diagnostics.Debug.Print("-- " + targetElement.TagName + " -- Contains ");
            foreach (KeyValuePair<string, string> pair in results)
            { System.Diagnostics.Debug.Print("     " + pair.Key + " : " + pair.Value); }
        }

        /// <summary>
        /// 指定された要素に明示的に指定された属性のうち、HtmlElementで取得可能な属性を一覧表示する
        /// </summary>
        /// <param name="targetElement"></param>
        public static void PrintAllUsableAttributes(HtmlElement targetElement)
        {
            Dictionary<string, string> results = ExtractUsableAttributes(targetElement);
            System.Diagnostics.Debug.Print("-- " + targetElement.TagName + " -- Contains ");
            foreach (KeyValuePair<string, string> pair in results)
            { System.Diagnostics.Debug.Print("     " + pair.Key + " : " + pair.Value); }
        }

        /// <summary>
        /// 指定された属性を用いて一意な要素を取得できるかどうかを調べる
        /// </summary>
        /// <param name="targetCollection">検証対象の要素コレクション</param>
        /// <param name="attributeConditions">属性リスト</param>
        /// <returns>一意な要素を取得できる場合はtrue、それ以外はfalse</returns>
        public static bool AreUniqueCondition(HtmlElementCollection targetCollection, string[] attributeConditions)
        {
            if (targetCollection == null)
            { throw new ArgumentNullException("targetCollectionにnullが指定されています"); }
            else if (attributeConditions == null)
            { throw new ArgumentNullException("attributeConditionsにnullが指定されています"); }
            else if (attributeConditions.Length % 2 != 0)
            { throw new ArgumentException("attributeConditionsがキーと値のペアになっていません"); }
            else if (attributeConditions.Length == 0)
            {
                // 属性が何でも良い場合は、属性が一致するかではなく、
                // ドキュメント内に要素が一つだけであるかにより真偽が変わる。
                // そのため、このメソッドで扱う対象としない
                throw new ArgumentException("attributeConditionsがキーと値のペアは少なくとも1つ指定する必要があります");
            }
            else
            {
                bool isFound = false;
                foreach (HtmlElement he in targetCollection)
                {
                    if (AreEqual(he, attributeConditions))
                    {
                        // すでに条件に一致するものがあった場合、
                        // この要素でふたつ目の要素ということになりUniqueではない。
                        if (isFound) { return false; }
                        else { isFound = true; }
                    }
                }

                // 一致するものがないため、
                // 「唯一の要素を見つけるための要素であるか」ということを判定する目的からいけば
                // 偽ということになる
                if (isFound) {  return true; }
                else { return false; }
            }
        }

        /// <summary>
        /// 指定された要素を強調する
        /// </summary>
        /// <param name="targetElement">強調したい要素</param>
        public static void EmphasizeElement(HtmlElement targetElement)
        { targetElement.Style += "; border: solid 4px black"; }

        /// <summary>
        /// 指定された要素に、指定された属性名と値のペアをすべて含むかどうかを調べる
        /// </summary>
        /// <param name="targetElement">一致するか検証したい要素</param>
        /// <param name="attributeConditions">含むべき属性の名前と値のペアリスト</param>
        /// <returns>一致している場合はtrue、それ以外の場合はfalse</returns>
        public static bool AreEqual(HtmlElement targetElement, string[] attributeConditions)
        {
            if (attributeConditions.Length % 2 != 0)
            { throw new ArgumentException("属性条件がキーと値のペアになっていません"); }
            else
            {
                Dictionary<string, string> extractedAttributes = ExtractUsableAttributes(targetElement);

                for (int i = 0; i < attributeConditions.Length; i = i + 2)
                {
                    string key = attributeConditions[i + 0].ToUpper();
                    string value = attributeConditions[i + 1];

                    if (!extractedAttributes.ContainsKey(key)) { return false; }
                    else { if (!extractedAttributes[key].Equals(value)) { return false; }}
                }

                return true;
            }
        }

        /// <summary>
        /// 要素に対して明示的に指定された属性を取得する
        /// </summary>
        /// <remarks>
        /// HtmlElementが隠ぺいしているMSHTML内のインターフェースから直接取得するため、
        /// HtmlElementでは取得できない属性も含まれる可能性がある。
        /// HtmlElementから取得できるものだけを取得したい場合はExtractUsableAttributesを使用する。
        /// </remarks>
        /// <param name="sourceElement">属性を取り出したい要素</param>
        /// <returns>属性名と属性値のペアリスト</returns>
        public static Dictionary<string, string> ExtractAttributes(HtmlElement sourceElement)
        {
            Dictionary<string, string> extractedAttributes = new Dictionary<string, string>();
            if (sourceElement == null)
            { throw new ArgumentNullException("nullが指定されています"); }
            else if (sourceElement.TagName == "!" || sourceElement.TagName == "?")
            {
                // attributesコレクションを取り出せなくて例外が発生するため
                // 別途処理してしまう。
                return extractedAttributes;
            }
            else
            {
                IHTMLElement2 domElement = (IHTMLElement2)sourceElement.DomElement;
                IHTMLDOMNode node = (IHTMLDOMNode)domElement;
                IHTMLAttributeCollection attributes = (IHTMLAttributeCollection)node.attributes;

                foreach (IHTMLDOMAttribute attribute in attributes)
                {
                    if (attribute.specified)
                    { extractedAttributes.Add(attribute.nodeName.ToUpper(), attribute.nodeValue.ToString()); }
                }

                return extractedAttributes;
            }
        }

        /// <summary>
        /// 要素に対して明示的に指定された属性のうち、HtmlElementで取得可能な属性を取得する
        /// </summary>
        /// <param name="sourceElement">属性を取り出したい要素</param>
        /// <returns>属性名と属性値のペアリスト</returns>
        public static Dictionary<string, string> ExtractUsableAttributes(HtmlElement sourceElement)
        {
            Dictionary<string, string> attributes = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> pair in ExtractAttributes(sourceElement))
            {
                string value = sourceElement.GetAttribute(pair.Key);
                if (pair.Value.Equals(value)) { attributes.Add(pair.Key, pair.Value);}
            }
            return attributes;
        }

        /// <summary>
        /// 指定したメソッドが存在するか調べる
        /// </summary>
        /// <param name="sourceElement">調査対象の要素</param>
        /// <param name="name">メソッド名</param>
        /// <returns>存在する場合はtrue、それ以外の場合はfalse</returns>
        public static bool HasMember(HtmlElement sourceElement, string name)
        {
            if (sourceElement == null)
            { throw new ArgumentNullException("sourceElementがnullです"); }
            else
            {
                Type typeName = sourceElement.DomElement.GetType();
                Object result = typeName.GetMethod("submit");
                if (result == null) { return false; }
                else { return true; }
            }
        }
    }

#endregion Public Logic Class

#region Public Assert Class

    /// <summary>
    /// 実行時にDOM要素やメソッドの検証を行うクラス
    /// </summary>
    public static class DomElementAssert
    { 
        /// <summary>
        /// 指定した要素に指定した属性と値が含まれているかどうかを検証する。検証に失敗した場合は例外を発生させる。
        /// </summary>
        /// <param name="targetElement">検証対象の要素</param>
        /// <param name="attributeConditions">含んでいるべき属性リスト</param>
        public static void AreEqual(HtmlElement targetElement, string[] attributeConditions)
        {
            if (!DomElementValidator.AreEqual(targetElement, attributeConditions))
            { throw new DomElementAssertFailedException("指定された属性と一致しない要素です"); }
        }

        /// <summary>
        /// 指定した要素が指定したメソッドを持つかどうか検証する。検証に失敗した場合は例外を発生させる。
        /// </summary>
        /// <param name="sourceElement">検証対象の要素</param>
        /// <param name="name">持っているべきメソッド名</param>
        public static void HasMember(HtmlElement sourceElement, string name)
        {
            if (!DomElementValidator.HasMember(sourceElement, name))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("{0}要素は{1}メソッドを持っていません", sourceElement.TagName, name);
                throw new DomElementAssertFailedException(sb.ToString());
            }
        }
    }

#endregion Public Assert Class

#region Public Exception Class

    /// <summary>
    /// DOM要素の検証に失敗した時に発生する例外
    /// </summary>
    public class DomElementAssertFailedException : Exception
    {
       public DomElementAssertFailedException(string message) : base(message)
        { DomElementAssert.AreEqual(null, new string[] { "", "" }); }        
    }

#endregion Public Exception Class

}
