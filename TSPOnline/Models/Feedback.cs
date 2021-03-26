using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TSPOnline.Extensions;

namespace TSPOnline.Models
{
    public class Feedback : IValidatableObject
    {
        /// <summary>
        /// 使用者名稱
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// 電子郵件信箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 回應類型
        /// </summary>
        public int Type { get; set; } = -1;

        /// <summary>
        /// 回應內容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 回應日期時間
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// 回應識別碼
        /// </summary>
        public string Guid { get; set; } = System.Guid.NewGuid().ToString();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Email))
                yield return new ValidationResult("電子郵件信箱禁止為空");
            if (Email.GetUTF8BytesCount() > 450)
                yield return new ValidationResult("電子郵件信箱長度限制為 450 半形字元以內，請縮短後再重新提交");
            if (Type < 0 || Enum.GetNames(typeof(FeedbackType)).Length < Type)
                yield return new ValidationResult("錯誤的回應類型");
            if (string.IsNullOrWhiteSpace(Content))
                yield return new ValidationResult("回應內容禁止為空");
            if (Content.GetUTF8BytesCount() > 1000)
                yield return new ValidationResult("回應內容長度限制為 1000 半形字元以內，請縮短後再重新提交");
        }
    }

    public enum FeedbackType
    {
        Bugs,
        Suggestion,
        Question,
        Others
    }
}