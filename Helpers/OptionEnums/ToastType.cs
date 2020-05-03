using System.ComponentModel;

namespace SchoolsPortal.Models.Helpers.OptionEnums
{
    public enum ToastType
    {
        [Description("success")]
        Success,

        [Description("info")]
        Info,

        [Description("warning")]
        Warning,

        [Description("error")]
        Error,

    }

    public enum ToastPosition
    {
        [Description("toast-top-right")]
        TopRight,

        [Description("toast-bottom-righ")]
        BottomRight,

        [Description("toast-bottom-left")]
        BottomLeft,

        [Description("toast-top-left")]
        TopLeft,

        [Description("toast-top-full-width")]
        TopFullWidth,

        [Description("toast-bottom-full-width")]
        BottomFullWidth,

        [Description("toast-top-center")]
        TopCenter,

        [Description("toast-bottom-center")]
        BottomCenter
    }


}
