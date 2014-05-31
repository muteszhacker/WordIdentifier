using System;
using System.Collections.Generic;

namespace WordIdentifier
{
    /// <summary>
    /// Lớp ngoại lệ tự định nghĩa
    /// </summary>
    class PRDEditorException : Exception
    {
        private string reason;          // Lý do xảy ra ngoại lệ

        // Phương thức khởi tạo
        public PRDEditorException(string reasonType)
        {
            SetReason(reasonType);
        }

        // Lấy lý do xảy ra ngoại lệ
        public string GetReason()
        {
            return reason;
        }

        // Thiết lập lý do xảy ra ngoại lệ
        public void SetReason(string reasonType)
        {
            Dictionary<string, string> map = new Dictionary<string, string>
                {
                    {"0001", "Parent XmlNode is null."},
                    {"0002", "File cannot be opened."}
                };

            map.TryGetValue(reasonType, out reason);
            if (string.IsNullOrEmpty(reason))
                reason = "Undefined";
        }

        // Lấy thông tin ngoại lệ
        public string GetMessage()
        {
            return reason;
        }

        // Trả về mô tả ngoại lệ
        public override string ToString()
        {
            return this.GetType() + ":\n" + this.StackTrace + "\n" + GetMessage();
        }
    }
}
