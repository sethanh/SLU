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
    }

    public static class SUCCESS_MESSAGE
    {
        public const string CREATE_USER_SUCCESS = "CREATE_USER_SUCCESS";
    }

}
