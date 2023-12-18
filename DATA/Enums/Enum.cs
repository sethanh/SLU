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

    public static class EXCEPTION_TYPE
    {
        public const string NOT_FOUND = "NOT_FOUND";
        public const string NO_CONTENT = "NO_CONTENT";
        public const string FORBID = "FORBID";
        public const string BAD_REQUEST = "BAD_REQUEST";
    }

    public static class BAD_REQUEST_MESSAGE
    {
        public const string EXISTED_USER = "EXISTED_USER";
        public const string PASSWORD_IS_NOT_VALID = "PASSWORD_IS_NOT_VALID";
        public const string MODEL_IS_NOT_VALID = "MODEL_IS_NOT_VALID";
        public const string EXISTED_CUSTOMER = "EXISTED_CUSTOMER";
        public const string NOT_EXIST_CUSTOMER = "NOT_EXIST_CUSTOMER";
    }

    public static class SUCCESS_MESSAGE
    {
        public const string CREATE_USER_SUCCESS = "CREATE_USER_SUCCESS";
    }

    public static class SECURITY_VALUE
    {
        public const string PASSWORD = "********";
    }

    public static class TIME_UNIT
    {
        public const string MINUTE = "MINUTE";
        public const string HOUR = "HOUR";
        public const string SECOND = "SECOND";
    }

    public static class BOOKING_FROM
    {
        public const string CUSTOMER_APP = "CUSTOMER_APP";
        public const string MAIN_APP = "MAIN_APP";
    }

    public static class BOOKING_STATUS
    {
        public const string NEW = "NEW";
        public const string CONFIRM = "CONFIRM";
        public const string CHECK_IN = "CHECK_IN";
        public const string CHECK_OUT = "CHECK_OUT";
    }

}
