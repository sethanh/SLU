using System;
using System.Collections.Generic;
using System.Text;

namespace DATA.Enums
{
    public static class STATUS
    {
        public const string ENABLE = "ENABLE";
        public const string DELETED = "DELETED";
    }

    public static class BAD_REQUEST_MESSAGE
    {
        public const string EXISTED_USER = "EXISTED_USER";
        public const string PASSWORD_IS_NOT_VALID = "PASSWORD_IS_NOT_VALID";
        public const string MODEL_IS_NOT_VALID = "MODEL_IS_NOT_VALID";
        public const string EXISTED_CUSTOMER = "EXISTED_CUSTOMER";
    }

    public static class SUCCESS_MESSAGE
    {
        public const string CREATE_USER_SUCCESS = "CREATE_USER_SUCCESS";
    }

    public static class SECURITY_VALUE
    {
        public const string PASSWORD = "********";
    }

}
