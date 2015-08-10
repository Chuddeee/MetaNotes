using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaNotes.Common
{
    public static class LengthConstants
    {
        /// <summary>Минимально допустимый размер пароля (именно пароля, а не хэша пароля)</summary>
        public const int PasswordMin = 6;

        /// <summary>Максимально допустимый размер пароля (именно пароля, а не хэша пароля)</summary>
        public const int PasswordMax = 30;
    }
}
