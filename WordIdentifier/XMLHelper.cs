using System;
using System.Windows.Forms;
using System.Xml;

namespace WordIdentifier
{
    /// <summary>
    /// Lớp tiện ích với cây XML
    /// </summary>
    class XMLHelper
    {
        /// <summary>
        /// Thêm thẻ vào cây XML
        /// </summary>
        /// <param name="tagName"></param>
        /// <param name="textContent"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static XmlNode AddElement(string tagName, string textContent, XmlNode parent)
        {
            try
            {
                if (parent.OwnerDocument == null)
                    throw new PRDEditorException("0001");

                XmlNode node = parent.OwnerDocument.CreateElement(tagName);
                parent.AppendChild(node);

                if (textContent != null)
                {
                    XmlNode content = parent.OwnerDocument.CreateTextNode(textContent);
                    node.AppendChild(content);
                }

                return node;
            }
            catch (PRDEditorException err)
            {
                MessageBox.Show(err.ToString());
                return null;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return null;
            }
        }

        /// <summary>
        /// Thêm thuộc tính cho 1 thẻ trong cây XML
        /// </summary>
        /// <param name="attributeName"></param>
        /// <param name="textContent"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static XmlNode AddAttribute(string attributeName, string textContent, XmlNode parent)
        {
            try
            {
                if (string.IsNullOrEmpty(textContent))
                    return null;

                if (parent.OwnerDocument == null)
                    throw new PRDEditorException("0001");

                XmlAttribute attribute = parent.OwnerDocument.CreateAttribute(attributeName);
                attribute.Value = textContent;
                parent.Attributes.Append(attribute);

                return attribute;
            }
            catch (PRDEditorException err)
            {
                MessageBox.Show(err.ToString());
                return null;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return null;
            }
        }
    }
}
