namespace Shop.BuisnessLayer
{
    using System.Collections.Generic;
    public enum ErrorCodes : uint
    {
        EDS_ERR_TAKE_PICTURE_CARD_NG = 0x00008D07,
        EDS_ERR_TAKE_PICTURE_CARD_PROTECT_NG = 0x00008D08
    }
    /// <summary>
    /// The Error interface.
    /// </summary>
    public interface IError
    {
        /// <summary>
        /// Gets the code.
        /// </summary>
        ErrorCodes ErrorCode { get; }

        /// <summary>
        /// Gets the errors.
        /// </summary>
        IEnumerable<string> Errors { get; }
    }
}
